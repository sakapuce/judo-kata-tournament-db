using System.Data;
using System.Collections.Generic;

namespace DALHelper
{
    public class DataSetGraph: IGraph
    {
        private readonly DataSet _dataset;
        private readonly List<IVertex> _executionPlan;
        private readonly List<IVertex> _vertices;

        public DataSetGraph(DataSet dataset)
        {
            _dataset = dataset;
            _executionPlan = new List<IVertex>();

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

        public List<IVertex> ComputeExecutionPlan()
        {
            InitializeVertices();
            foreach(IVertex vertex in Vertices)
            {
                if(vertex.Color == VerticeColor.White)
                {
                    DepthFirstSearch(vertex);
                }
            }
            return _executionPlan;
        }

        private void InitializeVertices()
        {
            foreach(IVertex vertex in Vertices)
            {
                vertex.Color = VerticeColor.White;
            }
        }

        private void DepthFirstSearch(IVertex vertex)
        {
            vertex.Color = VerticeColor.Gray; //Mark vertex as visited
            foreach(IVertex adjacentVertex in vertex.AdjacentVertices)
            {
                if (adjacentVertex.Color == VerticeColor.White)
                {
                    DepthFirstSearch(adjacentVertex);
                }
            }
            vertex.Color = VerticeColor.Black; //Indicate that the subtree from the current vertex has been completly treated
            _executionPlan.Add(vertex);
        }

        #endregion
    }
}
