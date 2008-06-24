using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DALHelper
{
    public class DataSetPersistor
    {
        private readonly IList<DbDataAdapter> _adapterSequenceForUpdate;
        private readonly IList<DbDataAdapter> _adapterSequenceForDelete;

        private DataSet _dataset;

        public IList<DbDataAdapter> AdapterSequenceForUpdate
        {
            get
            {
                return _adapterSequenceForUpdate;
            }
        }

        public IList<DbDataAdapter> AdapterSequenceForDelete
        {
            get
            {
                return _adapterSequenceForDelete;
            }
        }
        
        public DataSetPersistor(DataSet ds)
        {
            _dataset = ds;
            _adapterSequenceForUpdate = new List<DbDataAdapter>();
            _adapterSequenceForDelete = new List<DbDataAdapter>();
        }

        public DataSet DataSet
        {
            get { return _dataset; }
        }

        public void Update()
        {
            if (_dataset.HasChanges())
            {
                if (_adapterSequenceForDelete.Count == 0)
                {
                    throw new System.InvalidOperationException("The update try to delete some data but no DbDataAdapter sequence were provided.");
                }
                if (_adapterSequenceForUpdate.Count == 0)
                {
                    throw new System.InvalidOperationException("The update try to modify some data but no DbDataAdapter sequence were provided.");
                }

                DataSet ds = _dataset.GetChanges(DataRowState.Deleted);
                if(ds!=null)
                {
                    foreach (DbDataAdapter adapter in _adapterSequenceForUpdate)
                    {
                        adapter.Update(ds);
                    }
                }
                

                ds = _dataset.GetChanges(DataRowState.Modified);
                if(ds!=null)
                {
                    foreach (DbDataAdapter adapter in _adapterSequenceForDelete)
                    {
                        adapter.Update(ds);
                    }
                }
                
            }
        }

        public void SetAdapterSequenceForUpdate(IEnumerable<DbDataAdapter> collection)
        {
            foreach (DbDataAdapter adapter in collection)
            {
                _adapterSequenceForUpdate.Add(adapter);
            }
        }

        public void SetAdapterSequenceForDelete(IEnumerable<DbDataAdapter> collection)
        {
            foreach (DbDataAdapter adapter in collection)
            {
                _adapterSequenceForDelete.Add(adapter);
            }
        }
    }
}
