



using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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

            foreach (var vertex in adjacencyList)
            {
                Console.WriteLine(vertex.Key + "->" + string.Join(",", vertex.Value));
            }

            if (adjacencyList[source].Contains(destination) && adjacencyList[destination].Contains(source))
            {
                return true;
            }

            return false;


        }

        public int FindJudge2(int n, int[][] trust)
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

            // foreach (var pair in incoming)
            // {
            //     Console.WriteLine(string.Join(",", pair));
            // }

            Console.WriteLine(string.Join(",", incoming));
            Console.WriteLine(string.Join(",", outgoing));

            return 1;

        }

        public bool ValidPath2(int n, int[][] edges, int source, int destination)
        {

            Dictionary<int, List<int>> BuildAdjacencyList(int[][] edges)
            {
                var adj = new Dictionary<int, List<int>>();

                foreach (var edge in edges)
                {
                    if (!adj.ContainsKey(edge[0]))
                    {
                        adj[edge[0]] = new List<int>();
                    }

                    if (!adj.ContainsKey(edge[1]))
                    {
                        adj[edge[1]] = new List<int>();
                    }


                    adj[edge[0]].Add(edge[1]);
                    adj[edge[1]].Add(edge[0]);
                }

                return adj;
            }

            var adj = BuildAdjacencyList(edges);


            foreach (var pair in BuildAdjacencyList(edges))
            {
                Console.WriteLine($"{pair.Key} -> {string.Join("-", pair.Value)}");
            }


            bool BFS(Dictionary<int, List<int>> adj, int source, int destination)
            {
                var visited = new HashSet<int>();
                var queue = new Queue<int>();

                queue.Enqueue(source);

                while (queue.Count > 0)
                {
                    Console.WriteLine("These are the contents of the queue: " + string.Join(",", queue));

                    var u = queue.Dequeue();
                    Console.WriteLine(u);

                    visited.Add(u);

                    if (u == destination)
                    {
                        return true;
                    }


                    foreach (var v in adj[u])
                    {
                        if (!visited.Contains(v))
                        {
                            queue.Enqueue(v);
                            visited.Add(v);
                        }
                    }
                    Console.WriteLine("The contents of the queue after the loop: " + string.Join(",", queue));
                    Console.WriteLine("The contents of the visited after the loop: " + string.Join(",", visited));
                }

                return false;
            }

            Console.WriteLine("BFS returns: " + BFS(adj, source, destination));

            // Console.WriteLine(string.Join(",", BuildAdjacencyList(edges)));

            bool Dfs(Dictionary<int, List<int>> adj, HashSet<int> visited, int source, int destination)
            {
                if (source == destination)
                {
                    return true;
                }

                if (!visited.Contains(source))
                {
                    visited.Add(source);
                    foreach (var v in adj[source])
                    {
                        if (Dfs(adj, visited, v, destination))
                        {
                            return true;
                        }
                    }
                }
                return false;

            }

            Dfs(adj, new HashSet<int>(), source, destination);
            return true;
        }

        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {



            var sourceColor = image[sr][sc];

            void Dfs(int r, int c)
            {

                if (image[r][c] != sourceColor)
                {
                    return;
                }
                if (image[r][c] == color)
                {
                    return;
                }

                image[r][c] = color;



                if (r != 0)
                {
                    Dfs(r - 1, c);
                }

                if (c != 0)
                {
                    Dfs(r, c - 1);
                }



                if (c < image[sr].Length - 1)
                {
                    Dfs(r, c + 1);
                }

                if (r < image.Length - 1)
                {
                    Dfs(r + 1, c);
                }


            }


            Dfs(sr, sc);


            return image;

        }

        public int NumIslands(string[][] grid)
        {
            void Dfs(int r, int c)
            {
                if (c < 0 || r < 0 || c == grid[0].Length || r == grid.Length)
                {
                    return;
                }

                if (grid[r][c] == "0")
                {
                    return;
                }

                grid[r][c] = "0";

                Dfs(r - 1, c);
                Dfs(r, c - 1);
                Dfs(r, c + 1);
                Dfs(r + 1, c);



            }

            int islands = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == "1")
                    {
                        Dfs(i, j);
                        islands++;
                    }
                }
            }


            Console.WriteLine(islands);

            return islands;
        }


        public int IslandPerimeter(int[][] grid)
        {


            // int Dfs(int r, int c, int counter)
            // {

            //     if (r < 0 || c < 0 || r == grid.Length || c == grid[0].Length)
            //     {
            //         return counter;

            //     }

            //     if (grid[r][c] == 0)
            //     {
            //         return counter;
            //     }


            //     Console.WriteLine($"r is :{r} c is :{c} counter is :{counter}");


            //     grid[r][c] = 0;


            //     counter++;

            //     var top = Dfs(r - 1, c, counter);
            //     var left = Dfs(r, c - 1, counter);
            //     var right = Dfs(r, c + 1, counter);
            //     var bottom = Dfs(r + 1, c, counter);

            //     int total = top + left + right + bottom;
            //     Console.WriteLine(total);
            //     return total;




            // }

            int counter = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        counter += 4;
                        //Console.WriteLine(Dfs(i, j, 0));
                        if (j > 0)
                        {
                            if (grid[i][j - 1] == 1)
                            {
                                counter -= 2;
                            }
                        }

                        if (i > 0)
                        {
                            if (grid[i - 1][j] == 1)
                            {
                                counter -= 2;
                            }
                        }

                        Console.WriteLine($"The counter is: {counter}");


                    }
                }
            }


            return counter;





        }


        public int MaxAreaOfIsland(int[][] grid)
        {

            int Dfs(int r, int c, int counter)
            {

                if (r < 0 || c < 0 || r == grid.Length || c == grid[0].Length)
                {
                    return 0;

                }

                if (grid[r][c] == 0)
                {
                    return 0;
                }


                Console.WriteLine($"r is :{r} c is :{c} counter is :{counter}");


                grid[r][c] = 0;




                var top = Dfs(r - 1, c, counter + 1);
                var left = Dfs(r, c - 1, counter + 1);
                var right = Dfs(r, c + 1, counter + 1);
                var bottom = Dfs(r + 1, c, counter + 1);

                int total = top + left + right + bottom;

                Console.WriteLine();
                Console.WriteLine($"top: {top}");
                Console.WriteLine($"left: {left}");
                Console.WriteLine($"right: {right}");
                Console.WriteLine($"bottom: {bottom}");
                Console.WriteLine($"total: {total}");
                Console.WriteLine($"total: {total}");
                Console.WriteLine();

                return total + 1;




            }

            int result = 0;


            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        result = Math.Max(result
                        , Dfs(i, j, 0));
                        Console.WriteLine("Result at this juncture: " + result);

                    }
                }
            }

            return result;

        }


        public string[][] Solve(string[][] board)
        {

            void Dfs(int r, int c)
            {
                if (r < 1 || c < 1 || r == board.Length - 1 || c == board[0].Length)
                {
                    return;
                }

                if (board[r - 1][c] != "X" || board[r][c - 1] != "X")
                {
                    return;
                }

                if (board[r][c] == "X")
                {
                    return;
                }

                board[r][c] = "X";


                Dfs(r - 1, c);
                Dfs(r, c - 1);
                Dfs(r + 1, c);
                Dfs(r, c + 1);
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == "O")
                    {
                        Dfs(i, j);
                    }

                }
            }


            foreach (var pair in board)
            {
                Console.WriteLine(string.Join("-", pair));
            }

            return board;
        }

        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            var visited = new HashSet<int>();

            void Dfs(int room)
            {
                if (visited.Contains(room)) return;

                visited.Add(room);

                foreach (var key in rooms[room])
                {
                    Dfs(key);  // visit rooms unlocked by this room
                }
            }

            Dfs(0); // 🔑 Always start from room 0

            return visited.Count == rooms.Count;
        }

        public int NumberOfProvinces(int[][] isConnected)
        {
            var n = isConnected.Length;
            var visited = new bool[n];
            var adjMatrix = isConnected;

            int provinces = 0;


            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    provinces++;
                    Dfs(i);
                }
            }

            void Dfs(int currentCity)
            {
                visited[currentCity] = true;

                for (int neighbour = 0; neighbour < n; neighbour++)
                {
                    if (adjMatrix[currentCity][neighbour] == 1 && !visited[neighbour])
                    {
                        Dfs(neighbour);
                    }
                }


            }

            return provinces;


        }

        public int NumberOfProvinces2(int[][] isConnected)
        {
            var n = isConnected.Length;
            var visited = new bool[n];

            var adjList = new List<List<int>>();

            int provinces = 0;







            for (int i = 0; i < n; i++)
            {
                adjList.Add(new List<int>());
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (isConnected[i][j] == 1)
                    {
                        adjList[i].Add(j);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    provinces++;
                    Dfs(i);
                }
            }


            void Dfs(int currentCity)
            {
                visited[currentCity] = true;

                foreach (int neighbour in adjList[currentCity])
                {
                    if (!visited[neighbour])
                    {
                        Dfs(neighbour);
                    }
                }
            }

            return provinces;


        }


        public int FindJudge2(int n, int[][] trust)
        {

        }



    }
}