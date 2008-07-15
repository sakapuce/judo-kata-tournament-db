using System.Collections.Generic;

namespace DALHelper
{
    /// <summary>
    /// This class implement the Depth First Search Algoritm
    /// </summary>
    public static class DFS
    {
        /// <summary>
        /// This function return the list of vertices following the Depth-First search Algorithm
        /// </summary>
        /// <returns>a List of IVertex objects</returns>
        public static List<IVertex> ComputeItinerary(IGraph graph)
        {
            //initialize each vertex as unvisited
            foreach (IVertex vertex in graph.Vertices)
            {
                vertex.Color = VerticeColor.White;
            }

            List<IVertex> itinerary = new List<IVertex>();
            foreach (IVertex vertex in graph.Vertices)
            {
                if (vertex.Color == VerticeColor.White)
                {
                    DepthFirstSearch(vertex, itinerary);
                }
            }
            return itinerary;
        }

        private static void DepthFirstSearch(IVertex vertex, List<IVertex> itinerary)
        {
            vertex.Color = VerticeColor.Gray; //Mark vertex as visited
            foreach (IVertex adjacentVertex in vertex.AdjacentVertices)
            {
                if (adjacentVertex.Color == VerticeColor.White)
                {
                    DepthFirstSearch(adjacentVertex, itinerary);
                }
            }
            vertex.Color = VerticeColor.Black; //Indicate that the subtree from the current vertex has been completly treated
            itinerary.Add(vertex);
        }
    }
}
