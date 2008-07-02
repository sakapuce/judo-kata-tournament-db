using System.Configuration;
using System.Data.Common;
using System;
using System.Data;
using System.Diagnostics;

namespace DALHelper
{
    /// <summary>
    /// This class implements the Singleton Design patterns and  provides functions to simplify interaction with database.
    /// Read http://www.yoda.arachsys.com/csharp/singleton.html to learn more about Singleton design pattern.
    /// </summary>
    public sealed class DBHelper
    {

#region Private Fields
        private string _connectionString;
        private DbProviderFactory _dbFactory;
        private string _providerName;
        private bool _isInitialized;
        private string _connectionName;
#endregion


#region Properties
        /// <summary>
        /// Get the DbProviderFactory object instance of the currernt DBHelper
        /// </summary>
        public DbProviderFactory DbFactory
        {
            get { return _dbFactory; }
            private set { _dbFactory = value; }
        }

        /// <summary>
        /// Get the ConnectionString used by the current DBHelper object
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            private set { _connectionString = value; }
        }

        /// <summary>
        /// Get the provider name of the currernt DBHelper instance
        /// </summary>
        public string ProviderName
        {
            get { return _providerName; }
            private set { _providerName = value; }
        }

        public bool IsInitialized
        {
            get { return _isInitialized; }
            private set { _isInitialized = value; }
        }

        public string ConnectionName
        {
            get { return _connectionName; }
            private set { _connectionName = value; }
        }

#endregion


#region Constructor based on Singleton design pattern
        /// <summary>
        /// Get an instance of DBHelper.
        /// 
        /// IMPORTANT:
        /// After creating the first instance, invoke the Init() function
        /// to provide the connection name which will be used to identify the entry
        /// in the ConnectionStrings section of the application config file. 
        /// </summary>
        DBHelper()
        {
            IsInitialized = false;
            Debug.Write("DBHelper singleton instance created but not yet initialized.");
        }

        public void Init(string connectionName)
        {
            Debug.WriteLine(String.Format("DBHelper.Init(connectionName:{0}) is invoked", connectionName));
            if (IsInitialized == false)
            {
                ConnectionName = connectionName;
                ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;
                ProviderName = ConfigurationManager.ConnectionStrings[ConnectionName].ProviderName;
                DbFactory = DbProviderFactories.GetFactory(ProviderName);
                IsInitialized = true;
            }
            else if (connectionName == ConnectionName)
            {

                    Debug.WriteLine(String.Format("DBHelper can't be initialized twice with the same connection name ({0}). This Init call is ignored.", connectionName));
            }
            else
            {
                    throw new InvalidOperationException("The DBHelper instance has already been initialized previously. the call to the Init() function can't be completed.");
            }
        }

        public static DBHelper Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        class Nested
        {
            /**********************************************
             * Empty static constructor is redundant... 
             * It can be removed followings Resharper
             * *******************************************/
            //static Nested()
            //{
            //}

            internal static readonly DBHelper instance = new DBHelper();
        }

#endregion
        
        public DbConnection CreateConnection()
        {
            DbConnection dbConnection = DbFactory.CreateConnection();
            dbConnection.ConnectionString = ConnectionString;
            dbConnection.Open();
            return dbConnection;
        }

        public DbCommand CreateCommand(string query)
        {
            DbCommand dbCommand = CreateConnection().CreateCommand();
            dbCommand.CommandText = query;

            return dbCommand;
        }

        /// <summary>
        /// Create a new DbDataAdapter
        /// </summary>
        /// <returns>returns an instance of DbDataAdapter for the current DBHelper</returns>
        public DbDataAdapter CreateAdapter()
        {
            return DbFactory.CreateDataAdapter();
        }

        public DbDataReader CreateDataReader(string query)
        {
            return CreateCommand(query).ExecuteReader(CommandBehavior.CloseConnection);
        }

        public DataSet GetDataSet(string query)
        {
            DataSet ds = new DataSet();
            DbDataAdapter adapter = CreateAdapter();
            DbCommand command = CreateCommand(query);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            return ds;
        }

        public void ExecuteScript(string script)
        {
            string[] sqlcommands = script.Split(new string[] {"GO\r\n", "GO ", "GO\t"}, StringSplitOptions.RemoveEmptyEntries);
            DbCommand cmd = CreateCommand("");
            foreach (string sql in sqlcommands)
            {
                //Remove blank spaces
                cmd.CommandText = sql.Trim();
                cmd.CommandType = CommandType.Text;
                
                if(cmd.CommandText != String.Empty)
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
