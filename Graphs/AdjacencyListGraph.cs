


using System.Net.Http.Headers;

namespace DataStructuresAlgorithms.Graphs
{
    class AdjacencyListGraph
    {
        private readonly Dictionary<string,HashSet<string>> adjacencyList;

        public AdjacencyListGraph()
        {
            adjacencyList = new Dictionary<string, HashSet<string>>();
        }


        public void addVertex(string vertex)
        {
            if(!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = [];
            }
        }

        public void addEdge(string vertex1, string  vertex2)
        {
            if(!adjacencyList.ContainsKey(vertex1))
            {
                addVertex(vertex1);
            }

            if(!adjacencyList.ContainsKey(vertex2))
            {
                addVertex(vertex2);
            }

            adjacencyList[vertex1].Add(vertex2);
            adjacencyList[vertex2].Add(vertex1);


        }

        public bool hasEdge(string vertex1, string vertex2)
        {
           if(adjacencyList[vertex1].Contains(vertex2) && adjacencyList[vertex2].Contains(vertex1))
           {
            return true;
           } 

           return false;
        }


        public void removeEdge(string vertex1,string vertex2)
        {
            adjacencyList[vertex1].Remove(vertex2);
            adjacencyList[vertex2].Remove(vertex1);
        }


        public void removeVertex(string vertex)
        {
            if(adjacencyList[vertex] != null)
            {
                foreach(var adjacencyVertex in adjacencyList[vertex])
                {
                    removeEdge(vertex,adjacencyVertex);
                }

                adjacencyList[vertex].Clear();
                adjacencyList.Remove(vertex);
            }
        }


        public void display()
        {
            foreach(var vertex in adjacencyList)
            {
                Console.WriteLine(vertex.Key + "->" + string.Join(",",vertex.Value));
            }
        }



    }
}