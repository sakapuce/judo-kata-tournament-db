using System.Collections.Generic;

namespace DALHelper
{
    public interface IGraph
    {
        ICollection<IVertex> Vertices
        {
            get;
        }
    }
}
