using System.Collections.Generic;

namespace _10.JustBFS
{
    /// <summary> Represents a directed unweighted graph structure </summary>
    public class Graph
    {
        // Contains the child nodes for each vertex of the graph assuming that the vertices are numbered 0... size - 1
        private List<int>[] childNodes;

        /// <summary> Constructs an empty graph of given size </summary>
        /// <param name="size">number of vertices</param>
        public Graph(int size)
        {
            this.childNodes = new List<int>[size];

            for (int i = 0; i < size; i++)
            {
                // Assign an empty list of adjacents for each vertex
                this.childNodes[i] = new List<int>();
            }
        }

        /// <summary> Constructs a graph by given list of child nodes (successors) for each vertex </summary>
        /// <param name="childNodes">children for each node</param>
        public Graph(List<int>[] childNodes) 
            => this.childNodes = childNodes;

        /// <summary> Returns the size of the graph (number of vertices) </summary>
        public int Size => this.childNodes.Length;

        /// <summary> Adds new edge from u to v </summary>
        /// <param name="u">the starting vertex</param>
        /// <param name="v">the ending vertex</param>
        public void AddEdge(int u, int v) =>
            this.childNodes[u].Add(v);

        /// <summary> Removes the edge from u to v if such exists </summary>
        /// <param name="u">the starting vertex</param>
        /// <param name="v">the ending vertex</param>
        public void RemoveEdge(int u, int v) =>
            this.childNodes[u].Remove(v);

        /// <summary> Checks whether there is an edge between vertex u and v </summary>
        /// <param name="u">the starting vertex</param>
        /// <param name="v">the ending vertex</param>
        /// <returns>true if there is an edge between vertex u and vertex v</returns>
        public void HasEdge(int u, int v) =>
            this.childNodes[u].Contains(v);

        /// <summary> Returns the successors of a given vertex </summary>
        /// <param name="v">the vertex</param>
        /// <returns>list with all successors of the given vertex</returns>
        public IList<int> GetSuccessors(int v) =>
            this.childNodes[v];
    }
}
