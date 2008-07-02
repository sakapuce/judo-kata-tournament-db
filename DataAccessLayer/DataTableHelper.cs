using System.Data;
using System.Data.Common;

namespace DALHelper
{
    public class DataTableHelper
    {
        private DataTable _dataTable;
        private DbDataAdapter _adapter;

        public DataTable Table
        {
            get { return _dataTable; }
            private set { _dataTable = value; }
        }
    
        public DataTableHelper(DataTable dataTable)
        {
            Table = dataTable;
            _adapter = CreateDefaultAdapter();
        }

        public DbDataAdapter Adapter
        {
            get
            {
                return _adapter;
            }

            set
            {
                _adapter = value;
            }
        }

        public DbDataAdapter SetAdapter(DbCommand selectCommand, DbCommand updateCommand, DbCommand insertCommand, DbCommand deleteCommand)
        {
            _adapter.SelectCommand = selectCommand;
            _adapter.InsertCommand = insertCommand;
            _adapter.UpdateCommand = updateCommand;
            _adapter.DeleteCommand = deleteCommand;

            return _adapter;
        }

        public DbDataAdapter SetAdapter(string selectQuery, string updateQuery, string insertQuery, string deleteQuery)
        {
            DbCommand selectCommand = DBHelper.Instance.CreateCommand(selectQuery);
            DbCommand updateCommand = DBHelper.Instance.CreateCommand(selectQuery);
            DbCommand insertCommand = DBHelper.Instance.CreateCommand(insertQuery);
            DbCommand deleteCommand = DBHelper.Instance.CreateCommand(deleteQuery);

            return SetAdapter(selectCommand, updateCommand, insertCommand, deleteCommand);
        }


        private DbDataAdapter CreateDefaultAdapter()
        {
            DbDataAdapter dbAdapter = DBHelper.Instance.CreateAdapter();

            dbAdapter.SelectCommand = DBHelper.Instance.CreateCommand(CreateSelectQuery());
            dbAdapter.InsertCommand = DBHelper.Instance.CreateCommand(CreateInsertQuery());
            dbAdapter.UpdateCommand = DBHelper.Instance.CreateCommand(CreateUpdateQuery());

             return dbAdapter;
        }

        public virtual string CreateSelectQuery()
        {
            if (Table.Columns.Count == 0)
            {
                throw new System.InvalidOperationException("The current Table contains no DataColumn. The 'SELECT' command cannot be created.");
            }
            string fields = string.Join(", ", GetColumnNames());
            return string.Format("SELECT {0} FROM {1}", fields, Table.TableName);
        }

        public virtual string CreateUpdateQuery()
        {
            if (Table.Columns.Count == 0)
            {
                throw new System.InvalidOperationException("The current Table contains no DataColumn. The 'UPDATE' command cannot be created.");
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

            if (Table.PrimaryKey.Length == 0)
            {
                throw new System.InvalidOperationException("The current Table contains no primary key. No 'WHERE' clause for the 'UPDATE' command can be provided without primary key.");
            }

            //create default filters based on the primary keys
            string[] filters = new string[Table.PrimaryKey.Length];
            i = 0;
            foreach (DataColumn column in Table.PrimaryKey)
            {
                filters[i++] = column.ColumnName + "=" + "@Original_" + column.ColumnName;
            }

            string strUpdates = string.Join(", ", updates);
            string strFilters = string.Join(" AND ", filters);

            return string.Format(@"UPDATE {0} SET {1} WHERE ({2})", Table.TableName, strUpdates, strFilters);
        }

        public virtual string CreateInsertQuery()
        {
            return CreateInsertQuery(true);
        }

        public virtual string CreateInsertQuery(bool InsertIdentity)
        {
            if (Table.Columns.Count == 0)
            {
                throw new System.InvalidOperationException("The current Table contains no DataColumn. The 'INSERT' command cannot be created.");
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
            return string.Format("INSERT INTO {0} ({1}) VALUES ({2})", Table.TableName, fields, inputParameters);
        }

        public virtual string[] GetColumnNames()
        {
            int i = 0;
            string[] columnNames = new string[Table.Columns.Count];

            foreach (DataColumn column in Table.Columns)
            {
                columnNames[i++] = column.ColumnName;
            }

            return columnNames;
        }

        public virtual string[] GetColumnNames(bool IgnoreIdentityFields)
        {
            if (IgnoreIdentityFields)
            {
                if (Table.Columns.Count == Table.PrimaryKey.Length)
                {
                    throw new System.InvalidOperationException("No column name can be returned because all columns are primary keys and IgnorePrimaryKeys is set to true.");
                }

                int i = 0;
                string[] columnNames = new string[Table.Columns.Count - Table.PrimaryKey.Length];
                foreach (DataColumn column in Table.Columns)
                {
                    bool IsAnIdentity = false;
                    foreach (DataColumn idColumn in Table.PrimaryKey)
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
                if (Table.PrimaryKey.Length == Table.Columns.Count)
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
            Table.Columns.Add(column);
            return column;
        }

        public void Update(DataSet dataset)
        {
            _adapter.Update(dataset, Table.TableName);
        }

        public void Fill(DataSet dataset)
        {
            _adapter.Fill(dataset, Table.TableName);
        }
    }
}
