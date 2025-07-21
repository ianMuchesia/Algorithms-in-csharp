using System.Runtime.CompilerServices;

namespace DataStructuresAlgorithms.Graphs
{
    public class LeetCodeDfsGraph
    {
        public int NumIslands(char[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;


            var visited = new bool[rows, cols];
            int counter = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == '1' && !visited[i, j])
                    {
                        foreach (var pair in visited)
                        {
                            Console.WriteLine($"{string.Join(",", pair)}");
                        }
                        Dfs(i, j);
                        counter++;

                    }
                }
            }

            void Dfs(int r, int c)
            {
                if (r < 0 || r >= rows || c < 0 || c >= cols)
                {
                    return;
                }

                if (grid[r][c] != '1')
                {
                    return;
                }

                if (visited[r, c])
                {
                    return;
                }

                Console.WriteLine($"this is r:{r} and this is c:{c}");

                visited[r, c] = true;

                Dfs(r - 1, c);
                Dfs(r, c - 1);
                Dfs(r + 1, c);
                Dfs(r, c + 1);
            }

            foreach (var pair in grid)
            {
                Console.WriteLine($"{string.Join(",", pair)}");
            }

            return counter;



        }

        public int MaxAreaOfIsland(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            var visited = new bool[rows, cols];

            int result = int.MinValue;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1 && !visited[i, j])
                    {
                        result = Math.Max(Dfs(i, j), result);
                    }
                }
            }

            int Dfs(int r, int c)
            {
                if (r < 0 || r >= rows || c < 0 || c >= cols)
                {
                    return 0;
                }

                if (grid[r][c] != 1)
                {
                    return 0;
                }

                if (visited[r, c])
                {
                    return 0;
                }
                visited[r, c] = true;

                int top = Dfs(r - 1, c);
                int left = Dfs(r, c - 1);
                int bottom = Dfs(r + 1, c);
                int right = Dfs(r, c + 1);

                return 1 + top + left + bottom + right;
            }


            return result == int.MinValue ? 0 : result;




        }
        public int ClosedIsland(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            var visited = new bool[rows, cols];

            int counter = 0;
            foreach (var pair in grid)
            {
                Console.WriteLine($"{string.Join(",", pair)}");
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j != 0 && j != cols - 1 && i != 0 && i != rows - 1 && !visited[i, j] && grid[i][j] == 0)
                    {


                        if (Dfs(i, j, true))
                        {

                            Console.WriteLine($"The value of r is {i} and the value of c is {j}");
                            counter++;
                        }

                    }
                }
            }

            bool Dfs(int r, int c, bool IsAtEdge)
            {

                if (r >= rows || r < 0 || c >= cols || c < 0)
                {
                    return IsAtEdge;
                }

                if (visited[r, c])
                {
                    return IsAtEdge;
                }

                if (grid[r][c] != 0)
                {
                    return IsAtEdge;
                }

                if (r == 0 || r == rows - 1 || c == 0 || c == cols - 1)
                {
                    grid[r][c] = 2;
                    // Console.WriteLine("We are here");
                    // Console.WriteLine($"The value of r is {r} and the value of c is {c}");
                    return false;
                }

                visited[r, c] = true;
                grid[r][c] = 2;

                //Console.WriteLine($"The bool is at edge: {IsAtEdge}");

                var top = Dfs(r - 1, c, IsAtEdge);
                var left = Dfs(r, c - 1, IsAtEdge);
                var down = Dfs(r + 1, c, IsAtEdge);
                var right = Dfs(r, c + 1, IsAtEdge);


                return top &&
                       left &&
                       down &&
                       right;

            }
            foreach (var pair in grid)
            {
                Console.WriteLine($"{string.Join(",", pair)}");
            }

            return counter;
        }

        public void Solve(char[][] board)
        {
            int rows = board.Length;
            int cols = board[0].Length;

            var visited = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 || j == 0 || i == rows - 1 || j == cols - 1)
                    {
                        if (board[i][j] == 'O' && !visited[i, j])
                        {
                            Dfs(i, j);
                        }
                    }

                }
            }

            void Dfs(int r, int c)
            {
                if (r >= rows || r < 0 || c >= cols || c < 0)
                {
                    return;
                }

                if (board[r][c] != 'O')
                {
                    return;
                }

                visited[r, c] = true;

                Dfs(r - 1, c);
                Dfs(r, c - 1);
                Dfs(r + 1, c);
                Dfs(r, c + 1);

            }


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i][j] == 'O' && !visited[i, j])
                    {
                        board[i][j] = 'X';
                    }

                }
            }

            foreach (var pair in board)
            {
                Console.WriteLine($"{string.Join(",", pair)}");
            }







        }

        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {

            var visited = new HashSet<int>();



            void Dfs(int room)
            {

                visited.Add(room);

                for (int i = 0; i < rooms[room].Count; i++)
                {
                    if (!visited.Contains(rooms[room][i]))
                    {
                        Dfs(rooms[room][i]);
                    }

                }

                return;
            }

            Dfs(0);

            return visited.Count == rooms.Count;



        }


    }
}