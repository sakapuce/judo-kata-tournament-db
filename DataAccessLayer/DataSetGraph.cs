using System.Data;
using System.Collections.Generic;

namespace DALHelper
{
    public class DataSetGraph: IGraph
    {
        private readonly DataSet _dataset;
        private readonly List<IVertex> _vertices;

        /// <summary>
        /// The DataSetGraph class implements the IGraph interface. This constructor returns an instance of DataSetGraph.
        /// It can be used to abstract any DataSet as a Graph (a set of Vertices connected by edges)
        /// </summary>
        /// <param name="dataset">a DataSet on top of which the DataSetGraph must be constructed.</param>
        public DataSetGraph(DataSet dataset)
        {
            _dataset = dataset;

            _vertices = new List<IVertex>();
            foreach (DataTable table in _dataset.Tables)
            {
                _vertices.Add(new DataSetVertice(table));
            }
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
