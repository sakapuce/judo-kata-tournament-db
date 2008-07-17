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
            DbCommandBuilder dbCommandBuilder = DbHelper.CreateDbCommandBuilder();

            dbAdapter.SelectCommand = DbHelper.CreateCommand(CreateSelectQuery());

            dbCommandBuilder.DataAdapter = dbAdapter;

            
            dbAdapter.InsertCommand = dbCommandBuilder.GetInsertCommand();
            dbAdapter.UpdateCommand = dbCommandBuilder.GetUpdateCommand();
            dbAdapter.DeleteCommand = dbCommandBuilder.GetDeleteCommand();
            
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

        public void Update()
        {
            _adapter.Update(Table);
        }

        public void Fill(DataSet dataset)
        {
            _adapter.Fill(dataset, Table.TableName);
        }

        public void Fill(DataSet dataset, Int32[] ids)
        {
            //TODO: fill the inner DataTable by executing a SELECT statement filtered on a set of IDs
            throw new NotImplementedException("This function has not been implemented yet.");
        }
    }
}
