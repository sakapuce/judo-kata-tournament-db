using System;
using System.Collections.Generic;
using System.Data;

namespace DALHelper
{
    public class DataSetPersistor
    {
        private readonly IList<DataTableHelper> _sequenceForUpdate;
        private readonly IList<DataTableHelper> _sequenceForDelete;
        private readonly IList<DataTableHelper> _sequenceForFill;

        private readonly DataSet _dataset;

        public IList<DataTableHelper> SequenceForUpdate
        {
            get
            {
                return _sequenceForUpdate;
            }
        }

        public IList<DataTableHelper> SequenceForDelete
        {
            get
            {
                return _sequenceForDelete;
            }
        }

        public IList<DataTableHelper> SequenceForFill
        {
            get
            {
                return _sequenceForFill;
            }
        }
        
        public DataSetPersistor(DataSet ds)
        {
            _dataset = ds;
            _sequenceForUpdate = new List<DataTableHelper>();
            _sequenceForDelete = new List<DataTableHelper>();
            _sequenceForFill = new List<DataTableHelper>();
        }

        public DataSet DataSet
        {
            get { return _dataset; }
        }

        public void Update()
        {
            if (_dataset.HasChanges())
            {
                DataSet ds = _dataset.GetChanges(DataRowState.Deleted);
                if(ds!=null)
                {
                    if (_sequenceForDelete.Count == 0)
                    {
                        throw new InvalidOperationException("The update try to delete some data but no DbDataAdapter sequence were provided.");
                    }

                    foreach (DataTableHelper dtHelper in _sequenceForDelete)
                    {
                        dtHelper.Update(ds);
                    }
                }
                

                ds = _dataset.GetChanges(DataRowState.Modified);
                if(ds!=null)
                {

                    if (_sequenceForUpdate.Count == 0)
                    {
                        throw new InvalidOperationException("The update try to modify some data but no DbDataAdapter sequence were provided.");
                    }

                    foreach (DataTableHelper dtHelper in _sequenceForUpdate)
                    {
                        dtHelper.Update(ds);
                    }
                }
                
            }
        }

        public void SetSequenceForUpdate(IEnumerable<DataTableHelper> collection)
        {
            foreach (DataTableHelper dtHelper in collection)
            {
                _sequenceForUpdate.Add(dtHelper);
            }
        }

        public void SetSequenceForDelete(IEnumerable<DataTableHelper> collection)
        {
            foreach (DataTableHelper dtHelper in collection)
            {
                _sequenceForDelete.Add(dtHelper);
            }
        }

        public void SetSequenceForFill(IEnumerable<DataTableHelper> collection)
        {
            foreach (DataTableHelper dtHelper in collection)
            {
                _sequenceForFill.Add(dtHelper);
            }
        }

        /// <summary>
        /// This function calls the DbDataTableAdapter to fill the datatable of the inner dataset
        /// </summary>
        public void Fill()
        {
            if(_sequenceForFill.Count == 0)
            {
                throw new InvalidOperationException("Cannot fill the data tables if no DbDataAdapters were previously declared.");
            }

            foreach (DataTableHelper dtHelper in _sequenceForFill)
            {
                dtHelper.Fill(_dataset);
            }
        }
    }
}
