using System.Data;
using System.Data.Common;

namespace DALHelper
{
    public class DataTableHelper
    {
        private DataTable _dataTable;

        public DataTable DataTable
        {
            get { return _dataTable; }
            private set { _dataTable = value; }
        }
    
        public DataTableHelper(DataTable dataTable)
        {
            DataTable = dataTable;
        }

        public DbDataAdapter CreateDefaultAdapter()
        {
            DBHelper dbHelper = DBHelper.Instance;
            DbDataAdapter dbAdapter = dbHelper.CreateAdapter();

            dbAdapter.SelectCommand = dbHelper.CreateCommand(CreateSelectQuery());
            dbAdapter.InsertCommand = dbHelper.CreateCommand(CreateInsertQuery());
            dbAdapter.UpdateCommand = dbHelper.CreateCommand(CreateUpdateQuery());

            return dbAdapter;
        }

        public virtual string CreateSelectQuery()
        {
            if (DataTable.Columns.Count == 0)
            {
                throw new System.InvalidOperationException("The current DataTable contains no DataColumn. The 'SELECT' command cannot be created.");
            }
            string fields = string.Join(", ", GetColumnNames());
            return string.Format("SELECT {0} FROM {1}", fields, DataTable.TableName);
        }

        public virtual string CreateUpdateQuery()
        {
            if (DataTable.Columns.Count == 0)
            {
                throw new System.InvalidOperationException("The current DataTable contains no DataColumn. The 'UPDATE' command cannot be created.");
            }
            
            string[] columnNames = GetColumnNames();
            string[] inputParameters = GetInputParameters();
            string[] updates = new string[columnNames.Length];
            int i = 0;
            foreach (string columnName in columnNames)
            {
                updates[i] = columnName + "=" + inputParameters[i];
                i++;
            }

            if (DataTable.PrimaryKey.Length == 0)
            {
                throw new System.InvalidOperationException("The current DataTable contains no primary key. No 'WHERE' clause for the 'UPDATE' command can be provided without primary key.");
            }

            //create default filters based on the primary keys
            string[] filters = new string[DataTable.PrimaryKey.Length];
            i = 0;
            foreach (DataColumn column in DataTable.PrimaryKey)
            {
                filters[i++] = column.ColumnName + "=" + "@Original_" + column.ColumnName;
            }

            string strUpdates = string.Join(", ", updates);
            string strFilters = string.Join(" AND ", filters);

            return string.Format(@"UPDATE {0} SET {1} WHERE ({2})", DataTable.TableName, strUpdates, strFilters);
        }

        public virtual string CreateInsertQuery()
        {
            return CreateInsertQuery(true);
        }

        public virtual string CreateInsertQuery(bool InsertIdentity)
        {
            if (DataTable.Columns.Count == 0)
            {
                throw new System.InvalidOperationException("The current DataTable contains no DataColumn. The 'INSERT' command cannot be created.");
            }
            string fields;
            string inputParameters;

            if (InsertIdentity) //identities are provided
            {
                fields = string.Join(", ", GetColumnNames());
                inputParameters = string.Join(", ", GetInputParameters());
            }
            else //no identities are provided, system will use auto-increment mechanism
            {
                fields = string.Join(", ", GetColumnNames(true));
                inputParameters = string.Join(", ", GetInputParameters(true));
            }
            return string.Format("INSERT INTO {0} ({1}) VALUES ({2})", DataTable.TableName, fields, inputParameters);
        }

        public virtual string[] GetColumnNames()
        {
            int i = 0;
            string[] columnNames = new string[DataTable.Columns.Count];

            foreach (DataColumn column in DataTable.Columns)
            {
                columnNames[i++] = column.ColumnName;
            }

            return columnNames;
        }

        public virtual string[] GetColumnNames(bool IgnoreIdentityFields)
        {
            if (IgnoreIdentityFields)
            {
                if (DataTable.Columns.Count == DataTable.PrimaryKey.Length)
                {
                    throw new System.InvalidOperationException("No column name can be returned because all columns are primary keys and IgnorePrimaryKeys is set to true.");
                }

                int i = 0;
                string[] columnNames = new string[DataTable.Columns.Count - DataTable.PrimaryKey.Length];
                foreach (DataColumn column in DataTable.Columns)
                {
                    bool IsAnIdentity = false;
                    foreach (DataColumn idColumn in DataTable.PrimaryKey)
                    {
                        if (column.ColumnName == idColumn.ColumnName)
                        {
                            IsAnIdentity = true; 
                            break;
                        }
                    }
                    if (IsAnIdentity == false)
                    {
                        columnNames[i++] = column.ColumnName;
                    }
                }
                return columnNames;
            }
            return GetColumnNames();
        }

        public virtual string[] GetInputParameters(bool IgnoreIdentityFields)
        {
            if (IgnoreIdentityFields)
            {
                if (DataTable.PrimaryKey.Length == DataTable.Columns.Count)
                {
                    throw new System.InvalidOperationException("No input paramaters can be returned because all columns are primary keys and IgnorePrimaryKeys is set to true.");
                }

                string[] columnNames = GetColumnNames(true);
                string[] inputParameters = new string[columnNames.Length];
                int i = 0;
                foreach (string str in columnNames)
                {
                    inputParameters[i++] = '@' + str;
                }
                return inputParameters;
            }
            return GetInputParameters();
        }

        public virtual string[] GetInputParameters()
        {
            string[] columnNames = GetColumnNames();
            string[] inputParameters = new string[columnNames.Length];
            int i=0;
            foreach (string str in columnNames)
            {
                inputParameters[i++] = '@' + str;
            }
            return inputParameters;
        }

        public DataColumn AddColumn(string columnName)
        {
            DataColumn column = new DataColumn(columnName);
            DataTable.Columns.Add(column);
            return column;
        }
    }
}
