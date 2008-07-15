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

        public void Update()
        {
            if (!_dataset.HasChanges()) return;

            List<IVertex> itinerary = DFS.ComputeItinerary(new DataSetGraph(_dataset));
            
            DataSet ds = _dataset.GetChanges(DataRowState.Deleted);
            if(ds!=null)
            {

                foreach (IVertex vertex in itinerary)
                {
                    DataTable table = vertex as DataTable;
                    if(table != null)
                    {
                        DataTableHelper helper = table.ExtendedProperties["DataTableHelper"] as DataTableHelper;
                        if (helper == null)
                        {
                            helper = new DataTableHelper(table);
                            Console.WriteLine(string.Format("Persistors deletes {0} rows from table '{1}'", helper.Table.GetChanges(DataRowState.Deleted).Rows.Count, helper.Table.TableName));
                            helper.Update();
                        }
                    }
                }
            }

            ds = _dataset.GetChanges(DataRowState.Modified | DataRowState.Added);
            if(ds!=null)
            {
                    
                itinerary.Reverse();

                foreach (IVertex vertex in itinerary)
                {
                    DataTable table = vertex as DataTable;
                    if (table != null)
                    {
                        DataTableHelper helper = table.ExtendedProperties["DataTableHelper"] as DataTableHelper;
                        if (helper == null)
                        {
                            helper = new DataTableHelper(table);
                            Console.WriteLine(string.Format("Persistor adds or updates {0} rows from table '{1}'", helper.Table.GetChanges(DataRowState.Deleted).Rows.Count, helper.Table.TableName));
                            helper.Update();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This function fills the tables of the inner dataset
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
