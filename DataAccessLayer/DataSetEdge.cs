using System.Data;

namespace DALHelper
{
    public class DataSetEdge: IEdge
    {
        private readonly DataRelation _relation;
        
        public DataSetEdge(DataRelation relation)
        {
            _relation = relation;
        }

        #region IEdge Members

        public IVertex From
        {
            get 
            {
                return (DataSetVertice) _relation.ParentTable;
            }
        }

        public IVertex To
        {
            get
            {
                return (DataSetVertice) _relation.ChildTable;
            }
        }

        #endregion

        public string Label
        {
            get
            {
                return _relation.RelationName;
            }
        }
    }
}
