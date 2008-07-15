using System.Data;
using System.Collections.Generic;

namespace DALHelper
{
    public class DataSetVertice: IVertex
    {
        private DataTable _table;

        #region IVertex Members

        public DataSetVertice(DataTable table)
        {
            _table = table;
            if(!_table.ExtendedProperties.ContainsKey("VerticeColor"))
            {
                _table.ExtendedProperties.Add("VerticeColor",VerticeColor.White);
            }
        }

        public DataTable Table
        {
            get
            {
                return _table;
            }
        }
        
        public ICollection<IEdge> IncomingEdges
        {
            get
            {
                List<IEdge> incomingEdges = new List<IEdge>(_table.ParentRelations.Count);
                foreach (DataRelation relation in _table.ParentRelations)
                {
                    incomingEdges.Add(new DataSetEdge(relation));
                }
                return incomingEdges;
            }
        }

        public ICollection<IEdge> OutgoingEdges
        {
            get
            {
                List<IEdge> outgoingEdges = new List<IEdge>(_table.ChildRelations.Count);
                foreach (DataRelation relation in _table.ChildRelations)
                {
                    outgoingEdges.Add(new DataSetEdge(relation));
                }
                return outgoingEdges;
            }
        }

        public ICollection<IVertex> AdjacentVertices
        {
            get
            {
                List<IVertex> adjacentVertices = new List<IVertex>();
                foreach(IEdge edge in OutgoingEdges)
                {
                    adjacentVertices.Add(edge.To);
                }
                return adjacentVertices;
            }
        }

        public string Label
        {
            get
            {
                return _table.TableName;
            }
        }

        public VerticeColor Color
        {
            get
            {
                return (VerticeColor)_table.ExtendedProperties["VerticeColor"];
            }
            set
            {
                _table.ExtendedProperties["VerticeColor"] = value;
            }
        }

        public static explicit operator DataSetVertice(DataTable table)
        {
            return new DataSetVertice(table);
        }

        #endregion
    }
}
