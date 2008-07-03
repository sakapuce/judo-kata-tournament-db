using System;
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
            DbCommand selectCommand = DbHelper.CreateCommand(selectQuery);
            DbCommand updateCommand = DbHelper.CreateCommand(selectQuery);
            DbCommand insertCommand = DbHelper.CreateCommand(insertQuery);
            DbCommand deleteCommand = DbHelper.CreateCommand(deleteQuery);

            return SetAdapter(selectCommand, updateCommand, insertCommand, deleteCommand);
        }


        private DbDataAdapter CreateDefaultAdapter()
        {
            DbDataAdapter dbAdapter = DbHelper.CreateAdapter();

            dbAdapter.SelectCommand = DbHelper.CreateCommand(CreateSelectQuery());
            dbAdapter.InsertCommand = DbHelper.CreateCommand(CreateInsertQuery());
            dbAdapter.UpdateCommand = DbHelper.CreateCommand(CreateUpdateQuery());
            dbAdapter.DeleteCommand = DbHelper.CreateCommand(CreateDeleteQuery());

            //create default parameters for update and delete queries
            foreach (DataColumn column in Table.PrimaryKey)
            {
                DbParameter paramUpdate = dbAdapter.UpdateCommand.CreateParameter();
                DbParameter paramDelete = dbAdapter.DeleteCommand.CreateParameter();
                
                paramUpdate.Direction = ParameterDirection.Input;
                paramUpdate.ParameterName = string.Format("@Original_{0}", column.ColumnName);
                paramUpdate.DbType = (DbType)Enum.Parse(typeof(DbType), column.DataType.Name);

                paramDelete.Direction = ParameterDirection.Input;
                paramDelete.ParameterName = string.Format("@Original_{0}", column.ColumnName);
                paramDelete.DbType = (DbType)Enum.Parse(typeof(DbType), column.DataType.Name);
                paramDelete.SourceColumn = column.ColumnName;
                paramDelete.SourceVersion = DataRowVersion.Original;
                
                
                dbAdapter.UpdateCommand.Parameters.Add(paramUpdate);
                dbAdapter.DeleteCommand.Parameters.Add(paramDelete);
            }

            return dbAdapter;
        }

        public virtual string CreateSelectQuery()
        {
            if (Table.Columns.Count == 0)
            {
                throw new InvalidOperationException("The current Table contains no DataColumn. The 'SELECT' command cannot be created.");
            }
            string fields = string.Join(", ", GetColumnNames());
            return string.Format("SELECT {0} FROM {1}", fields, Table.TableName);
        }

        public virtual string CreateUpdateQuery()
        {
            if (Table.Columns.Count == 0)
            {
                throw new InvalidOperationException("The current Table contains no DataColumn. The 'UPDATE' command cannot be created.");
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
                throw new InvalidOperationException("The current Table contains no primary key. No 'WHERE' clause for the 'UPDATE' command can be provided without primary key.");
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
                throw new InvalidOperationException("The current Table contains no DataColumn. The 'INSERT' command cannot be created.");
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

        public virtual string CreateDeleteQuery()
        {
            if (Table.Columns.Count == 0)
            {
                throw new InvalidOperationException("The current Table contains no DataColumn. The 'DELETE' command cannot be created.");
            }

            //create default filters based on the primary keys
            string[] filters = new string[Table.PrimaryKey.Length];
            int i = 0;
            foreach (DataColumn column in Table.PrimaryKey)
            {
                filters[i++] = column.ColumnName + "=" + "@Original_" + column.ColumnName;
            }
            string strFilters = string.Join(" AND ", filters);

            return string.Format("DELETE FROM {0} WHERE ({1})", Table.TableName, strFilters);
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
                    throw new InvalidOperationException("No column name can be returned because all columns are primary keys and IgnorePrimaryKeys is set to true.");
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
                    throw new InvalidOperationException("No input paramaters can be returned because all columns are primary keys and IgnorePrimaryKeys is set to true.");
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

        public void Update()
        {
            _adapter.Update(Table);
        }

        public void Fill(DataSet dataset)
        {
            _adapter.Fill(dataset, Table.TableName);
        }
    }
}
