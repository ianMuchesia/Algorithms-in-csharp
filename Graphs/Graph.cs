namespace DataStructuresAlgorithms.Graphs
{
    public class Graphs
    {
        public int AdjacencyMatrix()
        {

            int[][] matrix = [
                [0,1,0],
                [1,0,1],
                [0,1,0],
            ];
            return matrix[0][1];
        }

        public string AdjacencyList()
        {
            Dictionary<string,List<string>> hashmap = new Dictionary<string, List<string>>()
            {
               {"A", new List<string> {"B"}},
               {"B", new List<string> {"A", "C"}},
               {"C", new List<string> {"B"}}
            };

             Dictionary<string,List<string>> hashmapList = new Dictionary<string, List<string>>()
            {
               {"A", ["B"]},
               {"B",  ["A", "C"]},
               {"C",  ["B"]}
            };


            return hashmap["A"][0];
        }

    }
}