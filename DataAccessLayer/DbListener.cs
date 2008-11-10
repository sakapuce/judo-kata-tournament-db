using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DALHelper
{
    public class DbListener
    {
        //Events
        public event EventHandler<DataSetListenerEventArgs> DataUpdatingEvent;
        public event EventHandler<DataSetListenerEventArgs> DataUpdatedEvent;

        private List<DataTableHelper> _helpers;

        public void DataSetListener()
        {
            _helpers = new List<DataTableHelper>();
        }

        public void Add(DataTableHelper helper)
        {
            _helpers.Add(helper);
            SqlDataAdapter adapter = helper.Adapter as SqlDataAdapter;
            if(adapter != null)
            {
                adapter.RowUpdating += OnRowUpdating;
                adapter.RowUpdated += OnRowUpdated;
            }
        }

        void OnRowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (DataUpdatedEvent != null)
            {
                DataSetListenerEventArgs args = new DataSetListenerEventArgs(e.Row.Table, e.StatementType, e.Row);
                DataUpdatedEvent(this, args);
            }
        }

        void OnRowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            if(DataUpdatingEvent!=null)
            {
                DataSetListenerEventArgs args = new DataSetListenerEventArgs(e.Row.Table, e.StatementType, e.Row);
                DataUpdatingEvent(this, args);
            }
        }
    }

    

    public class DataSetListenerEventArgs: EventArgs
    {
        private DataTable _table;
        private StatementType _statementType;
        private DataRow _row;
        
        public DataSetListenerEventArgs(DataTable table, StatementType statementType, DataRow row)
        {
            _table = table;
            _statementType = statementType;
            _row = row;
        }

        public DataTable TableName
        {
            get { return _table; }
        }

        public StatementType StatementType
        {
            get { return _statementType; }
        }

        public DataRow Row
        {
            get { return _row; }
        }
    }
}
