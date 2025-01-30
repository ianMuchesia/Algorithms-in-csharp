


namespace DataStructuresAlgorithms.Graphs
{
    public class LeetCodeGraph
    {
        public int FindJudge(int n, int[][] trust)
        {
            Dictionary<int, int> incoming = new Dictionary<int, int>();
            Dictionary<int, int> outgoing = new Dictionary<int, int>();


            foreach (var pair in trust)
            {

                if (!incoming.ContainsKey(pair[0]))
                {
                    incoming[pair[0]] = 0;
                }

                if (!incoming.ContainsKey(pair[1]))
                {
                    incoming[pair[1]] = 1;
                }
                else
                {

                    incoming[pair[1]] += 1;
                }


                if (!outgoing.ContainsKey(pair[0]))
                {
                    outgoing[pair[0]] = 1;
                }
                else
                {
                    outgoing[pair[0]] += 1;
                }

                if (!outgoing.ContainsKey(pair[1]))
                {
                    outgoing[pair[1]] = 0;
                }


            }

            Console.WriteLine(string.Join(",", incoming));

            int outgoingTotal = 0;
            int judgeLabel = 0;

            foreach (var pair in incoming)
            {
                if ((n - 1 == pair.Value) && outgoing[pair.Key] == 0)
                {
                    outgoingTotal += 1;
                    judgeLabel = pair.Key;

                }


            }

            if (outgoingTotal > 1 || judgeLabel == 0) return -1;


            return judgeLabel;
        }


        public int FindCenter(int[][] edges)
        {

            // Dictionary<int, int> incoming = new Dictionary<int, int>();
            // Dictionary<int, int> outgoing = new Dictionary<int, int>();


            // foreach (var edge in edges)
            // {
            //     if (!incoming.ContainsKey(edge[0]))
            //     {
            //         incoming[edge[0]] = 0;
            //     }

            //     if (!incoming.ContainsKey(edge[1]))
            //     {
            //         incoming[edge[1]] = 1;
            //     }
            //     else
            //     {
            //         incoming[edge[1]] += 1;
            //     }


            //     if (!outgoing.ContainsKey(edge[0]))
            //     {
            //         outgoing[edge[0]] = 1;
            //     }
            //     else
            //     {
            //         outgoing[edge[0]] += 1;
            //     }

            //     if (!outgoing.ContainsKey(edge[1]))
            //     {
            //         outgoing[edge[1]] = 0;
            //     }
            // }



            // foreach (var pair in incoming)
            // {
            //     Console.WriteLine(outgoing[pair.Key]);
            //     var currentTotal = pair.Value + outgoing[pair.Key];

            //     if (currentTotal == edges.Length)
            //     {
            //         return pair.Key;
            //     }
            // }


            // return 1;

            Dictionary<int, int> keyValues = new Dictionary<int, int>();


            foreach (var edge in edges)
            {
                if (keyValues.ContainsKey(edge[0]))
                {
                    keyValues[edge[0]] += 1;
                }
                else
                {
                    keyValues[edge[0]] = 1;
                }

                if (keyValues.ContainsKey(edge[1]))
                {
                    keyValues[edge[1]] += 1;
                }
                else
                {
                    keyValues[edge[1]] = 1;
                }
            }

            Console.WriteLine(string.Join(",", keyValues));

            foreach (var pair in keyValues)
            {
                if (pair.Value == edges.Length)
                {
                    return pair.Key;
                }
            }



            return 0;





        }

        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            var adjacencyList = new Dictionary<int, HashSet<int>>();

            foreach (var edge in edges)
            {
                if (!adjacencyList.ContainsKey(edge[0]))
                {
                    adjacencyList[edge[0]] = [];
                }

                if (!adjacencyList.ContainsKey(edge[1]))
                {
                    adjacencyList[edge[1]] = [];
                }

                adjacencyList[edge[0]].Add(edge[1]);
                adjacencyList[edge[1]].Add(edge[0]);
            }

            foreach(var vertex in adjacencyList)
            {
                Console.WriteLine(vertex.Key + "->" + string.Join(",",vertex.Value));
            }

            if (adjacencyList[source].Contains(destination) && adjacencyList[destination].Contains(source))
            {
                return true;
            }

            return false;


        }
    }
}