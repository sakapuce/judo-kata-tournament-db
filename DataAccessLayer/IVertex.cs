using System.Collections.Generic;

namespace DALHelper
{
    public enum VerticeColor
    {
        White,
        Gray,
        Black
    }
    
    public interface IVertex
    {
        ICollection<IEdge> IncomingEdges
        {
            get; 
        }

        ICollection<IEdge> OutgoingEdges
        { 
            get;
        }

        ICollection<IVertex> AdjacentVertices
        {
            get;
        }

        string Label
        { 
            get;
        }

        VerticeColor Color
        {
            get;
            set;
        }
    }
}
