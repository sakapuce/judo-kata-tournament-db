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
    
        /// <summary>
        /// Create a new instance of DataTableHelper initialized with a default DbDataAdapter.
        /// </summary>
        /// <param name="dataTable">Returns a new instance of DataTableHelper</param>
        public DataTableHelper(DataTable dataTable)
        {
            Table = dataTable;
            _adapter = CreateDefaultAdapter();
        }

        /// <summary>
        /// Returns the DbDataAdapter instance used by the current DataTableHelper object
        /// </summary>
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

        /// <summary>
        /// Set the DbCommand for the SELECT, UPDATE, INSERT and DELETE statements used by the current instance of DataTableHelper. 
        /// </summary>
        /// <param name="selectCommand">a DbCommand for the SELECT statement</param>
        /// <param name="updateCommand">a DbCommand for the SELECT statement</param>
        /// <param name="insertCommand">a DbCommand for the SELECT statement</param>
        /// <param name="deleteCommand">a DbCommand for the SELECT statement</param>
        /// <returns>a DbDataAdapter instance initialized with the specified DbCommands.</returns>
        public DbDataAdapter SetAdapter(DbCommand selectCommand, DbCommand updateCommand, DbCommand insertCommand, DbCommand deleteCommand)
        {
            if (_adapter == null) 
                _adapter = DbHelper.CreateAdapter();

            _adapter.SelectCommand = selectCommand;
            _adapter.InsertCommand = insertCommand;
            _adapter.UpdateCommand = updateCommand;
            _adapter.DeleteCommand = deleteCommand;

            return _adapter;
        }

        /// <summary>
        /// Create and Set the inner DbDataAdapter by using the selectCommand provided.
        /// This function will automaticaly generates the INSERT, UPDATE and DELETE commands
        /// based on the schema returned by the SELECT command.
        /// </summary>
        /// <param name="selectCommand">a DBCommand used to generates automatically the INSERT, UPDATE and DELETE commands of the inner DbDataAdapter</param>
        /// <returns>the instance of the inner DbDataAdapter initialiezed from the SELECT DbCommand provided in parameter.</returns>
        public DbDataAdapter SetAdapter(DbCommand selectCommand)
        {
            _adapter = CreateDefaultAdapter(selectCommand);

            return _adapter;
        }

        /// <summary>
        /// Create and Set the inner DbDataAdapter by using the select query provided.
        /// This function will automaticaly generates the INSERT, UPDATE and DELETE commands
        /// based on the schema returned by the SELECT query.
        /// </summary>
        /// <param name="selectQuery">a String used to generates automatically the INSERT, UPDATE and DELETE commands of the inner DbDataAdapter</param>
        /// <returns>the instance of the inner DbDataAdapter initialiezed from the SELECT query provided in parameter.</returns>
        public DbDataAdapter SetAdapter(string selectQuery)
        {
            _adapter = CreateDefaultAdapter(DbHelper.CreateCommand(selectQuery));
            return _adapter;
        }

        /// <summary>
        /// Set the queries for the SELECT, UPDATE, INSERT and DELETE statements used by the current instance of DataTableHelper. 
        /// </summary>
        /// <param name="selectQuery">a string with the SELECT statement</param>
        /// <param name="updateQuery">a string with the SELECT statement</param>
        /// <param name="insertQuery">a string with the SELECT statement</param>
        /// <param name="deleteQuery">a string with the SELECT statement</param>
        /// <returns>a DbDataAdapter instance initialized with the specified queries.</returns>
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

            dbAdapter.SelectCommand = DbHelper.CreateCommand(DefaultSelectQuery);

            dbCommandBuilder.DataAdapter = dbAdapter;

            
            dbAdapter.InsertCommand = dbCommandBuilder.GetInsertCommand();
            dbAdapter.UpdateCommand = dbCommandBuilder.GetUpdateCommand();
            dbAdapter.DeleteCommand = dbCommandBuilder.GetDeleteCommand();
            
            return dbAdapter;
        }


        private static DbDataAdapter CreateDefaultAdapter(DbCommand selectCommand)
        {
            // WHY A STATIC METHOD ?
            //This method has been set as static because it does not change any instance properties or field.
            //After doing so, the compiler will emit non-virtual call sites to these members which will prevent
            //a check at runtime for each call that insures the current object pointer is non-null. This can result 
            //in a measurable performance gain for performance-sensitive code.

            DbDataAdapter dbAdapter = DbHelper.CreateAdapter();
            DbCommandBuilder dbCommandBuilder = DbHelper.CreateDbCommandBuilder();

            dbAdapter.SelectCommand = selectCommand;

            dbCommandBuilder.DataAdapter = dbAdapter;


            dbAdapter.InsertCommand = dbCommandBuilder.GetInsertCommand();
            dbAdapter.UpdateCommand = dbCommandBuilder.GetUpdateCommand();
            dbAdapter.DeleteCommand = dbCommandBuilder.GetDeleteCommand();

            return dbAdapter;
        }

        public virtual string DefaultSelectQuery
        {
            get
            {
                if (Table.Columns.Count == 0)
                {
                    throw new InvalidOperationException("The current Table contains no DataColumn. The 'SELECT' command cannot be created.");
                }
                string fields = string.Join(", ", GetColumnNames());
                return string.Format("SELECT {0} FROM {1}", fields, Table.TableName);   
            }
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
