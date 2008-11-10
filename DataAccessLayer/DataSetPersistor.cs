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

            //for each DataTable create an instance of DataTableHelper
            foreach(DataTable table in _dataset.Tables)
            {
                table.ExtendedProperties["DataTableHelper"] = new DataTableHelper(table);
            }
        }

        public DataSet DataSet
        {
            get { return _dataset; }
        }

        /// <summary>
        /// This funtions calls the INSERT, DELETE and UPDATE queries to update the inner dataset and reflect the changes done on it.
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
                    if (dsVertex == null) continue;

                    DataTableHelper helper = dsVertex.Table.ExtendedProperties["DataTableHelper"] as DataTableHelper; //?? new DataTableHelper(dsVertex.Table);

                    if (helper == null)
                        throw new InvalidOperationException(string.Format("Operation cannot be performed because no DataTableHelper is defined for the table {0}.", dsVertex.Table));

                    if (helper.Table.GetChanges(DataRowState.Deleted) == null) continue;
                    Console.WriteLine(string.Format("Persistors deletes {0} rows from table '{1}'", helper.Table.GetChanges(DataRowState.Deleted).Rows.Count, helper.Table.TableName));
                    helper.Update();
                }
            }

            ds = _dataset.GetChanges(DataRowState.Modified | DataRowState.Added);
            if (ds != null)
            {
                itinerary.Reverse();

                foreach (IVertex vertex in itinerary)
                {
                    DataSetVertice dsVertex = vertex as DataSetVertice;
                    if (dsVertex == null) continue;

                    DataTableHelper helper = dsVertex.Table.ExtendedProperties["DataTableHelper"] as DataTableHelper; // ?? new DataTableHelper(dsVertex.Table);

                    if (helper == null)
                        throw new InvalidOperationException(string.Format("Operation cannot be performed because no DataTableHelper is defined for the table {0}.", dsVertex.Table));

                    if (helper.Table.GetChanges(DataRowState.Added) != null)
                        Console.WriteLine(string.Format("Persistor adds {0} rows into table '{1}'", helper.Table.GetChanges(DataRowState.Added).Rows.Count, helper.Table.TableName));

                    if (helper.Table.GetChanges(DataRowState.Modified) != null)
                        Console.WriteLine(string.Format("Persistor updates {0} rows into table '{1}'", helper.Table.GetChanges(DataRowState.Modified).Rows.Count, helper.Table.TableName));

                    helper.Update();
                }
            }
        }

        /// <summary>
        /// This function fills the tables of the inner dataset by calling the SELECT queries on each table.
        /// </summary>
        public void Fill()
        {
            
            List<IVertex> itinerary = DFS.ComputeItinerary(new DataSetGraph(_dataset));
            itinerary.Reverse();

            foreach (IVertex vertex in itinerary)
            {
                DataSetVertice dsVertex = vertex as DataSetVertice;
                if (dsVertex == null) continue;
                DataTableHelper helper = dsVertex.Table.ExtendedProperties["DataTableHelper"] as DataTableHelper;

                if (helper == null)
                    throw new InvalidOperationException(string.Format("Operation cannot be performed because no DataTableHelper is defined for the table {0}.", dsVertex.Table));

                helper.Fill(_dataset);
            }
        }
    }
}
