using System.Configuration;
using System.Data.Common;
using System;
using System.Diagnostics;

namespace DALHelper
{
    /// <summary>
    /// This class implements the Singleton Design patterns and  provides functions to simplify interaction with database.
    /// Read http://www.yoda.arachsys.com/csharp/singleton.html to learn more about Singleton design pattern.
    /// </summary>
    internal sealed class DbConnector
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
        /// Get the DbProviderFactory object instance of the currernt DbConnector
        /// </summary>
        public DbProviderFactory DbFactory
        {
            get { return _dbFactory; }
            private set { _dbFactory = value; }
        }

        /// <summary>
        /// Get the ConnectionString used by the current DbConnector object
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            private set { _connectionString = value; }
        }

        /// <summary>
        /// Get the provider name of the currernt DbConnector instance
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
        /// Get an instance of DbConnector.
        /// 
        /// IMPORTANT:
        /// After creating the first instance, invoke the Init() function
        /// to provide the connection name which will be used to identify the entry
        /// in the ConnectionStrings section of the application config file. 
        /// </summary>
        DbConnector()
        {
            IsInitialized = false;
            Debug.WriteLine("DbConnector singleton instance created but not yet initialized.");
        }

        public void Init(string connectionName)
        {
            Debug.WriteLine(String.Format("DbConnector.Init(connectionName:{0}) is invoked", connectionName));
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

                Debug.WriteLine(String.Format("DbConnector can't be initialized twice with the same connection name ({0}). This Init call is ignored.", connectionName));
            }
            else
            {
                throw new InvalidOperationException("The DbConnector instance has already been initialized previously. the call to the Init() function can't be completed.");
            }
        }

        public static DbConnector Instance
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

            internal static readonly DbConnector instance = new DbConnector();
        }

        #endregion

        /// <summary>
        /// Returns a new instance of the provider's class that implements the DbCommandBuilder class.
        /// </summary>
        /// <returns>A new instance of DbCommandBuilder.</returns>
        public DbCommandBuilder CreateDbCommandBuilder()
        {
            return DbFactory.CreateCommandBuilder();
        }

        /// <summary>
        /// Create and get the Connection with the current database.
        /// </summary>
        /// <returns></returns>
        public DbConnection CreateConnection()
        {
            DbConnection dbConnection = DbFactory.CreateConnection();
            dbConnection.ConnectionString = ConnectionString;
            dbConnection.Open();
            return dbConnection;
        }

        /// <summary>
        /// Create a new DbDataAdapter
        /// </summary>
        /// <returns>returns an instance of DbDataAdapter for the current DbHelper</returns>
        public DbDataAdapter CreateAdapter()
        {
            return DbFactory.CreateDataAdapter();
        }
    }   
}
