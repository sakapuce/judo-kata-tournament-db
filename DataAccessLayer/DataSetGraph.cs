using System.Data;
using System.Collections.Generic;

namespace DALHelper
{
    public class DataSetGraph: IGraph
    {
        private readonly DataSet _dataset;
        private readonly List<IVertex> _vertices;

        public DataSetGraph(DataSet dataset)
        {
            _dataset = dataset;

            _vertices = new List<IVertex>();
            foreach (DataTable table in _dataset.Tables)
            {
                _vertices.Add(new DataSetVertice(table));
            }
        }

        /// <summary>
        /// Returns the list of vertices following the Depth-First-Search algorithm
        /// </summary>
        /// <returns>a List of IVertex objects</returns>
        public List<IVertex> ComputeDFSItinerary()
        {
            return DFS.ComputeItinerary(this);
        }

        #region IGraph Members

        public ICollection<IVertex> Vertices
        {
            get
            {
                return _vertices;
            }
        }

        #endregion
    }
}
