using System;
using System.Collections.Generic;
using System.Data;

namespace DALHelper
{
    public class DataSetPersistor
    {

        private readonly DataSet _dataset;
        
        public DataSetPersistor(DataSet ds)
        {
            _dataset = ds;
        }

        public DataSet DataSet
        {
            get { return _dataset; }
        }

        /// <summary>
        /// Set a specific DataTableHelper for a particular table of the inner dataset.
        /// </summary>
        public void SetDataTableHelper(string tableName, DataTableHelper helper)
        {
            DataTable table = _dataset.Tables[tableName];
            if (table == null)
            {
                throw new ArgumentException("the table '{0}' cannot be find.", tableName);
            }

            if(helper == null)
            {
                table.ExtendedProperties["DataTableHelper"] = null;
                return;
            }

            if(helper.Table.TableName != tableName)
            {
                throw new ArgumentException(string.Format("the provided DataHelper matchs the table '{0}' and cannot be assigned to table '{1}'.", helper.Table.TableName, tableName));
            }

            table.ExtendedProperties["DataTableHelper"] = helper;
        }

        /// <summary>
        /// This funtions calls the INSERT, DELETE and UPDATE queries to update the inner dataset and reflects the changes done on it.
        /// </summary>
        public void Update()
        {
            if (!_dataset.HasChanges()) return;

            List<IVertex> itinerary = DFS.ComputeItinerary(new DataSetGraph(_dataset));
            
            DataSet ds = _dataset.GetChanges(DataRowState.Deleted);
            if(ds!=null)
            {

                foreach (IVertex vertex in itinerary)
                {
                    DataSetVertice dsVertex = vertex as DataSetVertice;
                    if (dsVertex != null)
                    {
                        DataTableHelper helper = dsVertex.Table.ExtendedProperties["DataTableHelper"] as DataTableHelper ?? new DataTableHelper(dsVertex.Table);

                        Console.WriteLine(string.Format("Persistors deletes {0} rows from table '{1}'", helper.Table.GetChanges(DataRowState.Deleted).Rows.Count, helper.Table.TableName));
                        helper.Update();
                    }
                }
            }

            ds = _dataset.GetChanges(DataRowState.Modified | DataRowState.Added);
            if(ds!=null)
            {
                    
                itinerary.Reverse();

                foreach (IVertex vertex in itinerary)
                {
                    DataSetVertice dsVertex = vertex as DataSetVertice;
                    if (dsVertex != null)
                    {
                        DataTableHelper helper = dsVertex.Table.ExtendedProperties["DataTableHelper"] as DataTableHelper ?? new DataTableHelper(dsVertex.Table);

                        Console.WriteLine(string.Format("Persistor adds {0} rows into table '{1}'", helper.Table.GetChanges(DataRowState.Added).Rows.Count, helper.Table.TableName));
                        Console.WriteLine(string.Format("Persistor updates {0} rows into table '{1}'", helper.Table.GetChanges(DataRowState.Modified).Rows.Count, helper.Table.TableName));
                        helper.Update();
                    }
                }
            }
        }

        /// <summary>
        /// This function fills the tables of the inner dataset by calling the SELECT queries on each table.
        /// </summary>
        public void Fill()
        {
            List<IVertex> itinerary = DFS.ComputeItinerary(new DataSetGraph(_dataset));

            foreach (IVertex vertex in itinerary)
            {
                DataSetVertice dsVertice = vertex as DataSetVertice;
                if (dsVertice != null)
                {
                    DataTableHelper helper = dsVertice.Table.ExtendedProperties["DataTableHelper"] as DataTableHelper;
                    if (helper == null)
                    {
                        helper = new DataTableHelper(dsVertice.Table);
                        helper.Fill(_dataset);
                    }
                }
            }
        }
    }
}
