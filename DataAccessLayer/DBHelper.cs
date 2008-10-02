using System.Data.Common;
using System;
using System.Data;

namespace DALHelper
{
    public static class DbHelper
    {

        static DbHelper()
        {
            DbConnector.Instance.Init("JudoKataTournamentDb");
        }


        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        
        /// <summary>
        /// Create and get the Connection with the current database.
        /// </summary>
        /// <returns></returns>
        public static DbConnection CreateConnection()
        {
            DbConnection dbConnection = DbConnector.Instance.CreateConnection();
            return dbConnection;
        }

        /// <summary>
        /// Create a command that can be execute with the database in used.
        /// </summary>
        /// <param name="query">a string that contains a query</param>
        /// <returns>return a DbCommand with that matchs the query specified in parameter</returns>
        public static DbCommand CreateCommand(string query)
        {
            DbCommand dbCommand = CreateConnection().CreateCommand();
            dbCommand.CommandText = query;

            return dbCommand;
        }

        /// <summary>
        /// Returns a new instance of the provider's class that implements the DbCommandBuilder class.
        /// </summary>
        /// <returns>A new instance of DbCommandBuilder.</returns>
        public static DbCommandBuilder CreateDbCommandBuilder()
        {
            return DbConnector.Instance.CreateDbCommandBuilder();
        }

        /// <summary>
        /// Returns a new instance of the provider's class that implements the DbParameter class.
        /// </summary>
        /// <returns>A new instance of DbParameter.</returns>
        public static DbParameter CreateDbParameter()
        {
            return DbConnector.Instance.CreateDbParameter();
        }

        /// <summary>
        /// Create a new DbDataAdapter
        /// </summary>
        /// <returns>returns an instance of DbDataAdapter for the current DbHelper</returns>
        public static DbDataAdapter CreateAdapter()
        {
            return DbConnector.Instance.CreateAdapter();
        }

        public static DbDataReader CreateDataReader(string query)
        {
            return CreateCommand(query).ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static DataSet GetDataSet(string query)
        {
            DataSet ds = new DataSet();
            DbDataAdapter adapter = CreateAdapter();
            DbCommand command = CreateCommand(query);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            return ds;
        }
        /// <summary>
        /// Executes a SQL script (Batch)
        /// </summary>
        /// <param name="script">a string containing the script to be executed.</param>
        public static void ExecuteScript(string script)
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
