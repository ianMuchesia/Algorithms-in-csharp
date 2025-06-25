using System.Diagnostics.Metrics;

namespace DataStructuresAlgorithms.Graphs
{
    public class LeetCodeBfsGraph
    {

        private static readonly int[] dr = { -1, 1, 0, 0 }; // Delta row
        private static readonly int[] dc = { 0, 0, -1, 1 }; // Delta column


        public void Bfs_Matrix(int start_node, int[][] adj_matrix)
        {
            var NumNodes = adj_matrix.Length;

            var visited = new bool[NumNodes];

            var queue = new Queue<int>();

            queue.Enqueue(start_node);

            visited[start_node] = true;
            foreach (var adj in adj_matrix)
            {
                Console.WriteLine(string.Join(",", adj));
            }

            while (queue.Count > 0)
            {
                var u = queue.Dequeue();

                Console.WriteLine($"Visiting node: {u}");

                for (int v = 0; v < NumNodes; v++)
                {
                    //Console.WriteLine($"value of v is :{v}");
                    if (adj_matrix[u][v] == 1 && visited[v] != true)
                    {
                        visited[v] = true;
                        queue.Enqueue(v);
                        adj_matrix[u][v] = 2;
                    }
                }
            }


            foreach (var adj in adj_matrix)
            {
                Console.WriteLine(string.Join(",", adj));
            }
        }

        public void Bfs_GridTraversal(int startRow, int startCol, int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            foreach (var adj in grid)
            {
                Console.WriteLine(string.Join(",", adj));
            }

            //use a 2D boolean array for visited cells
            var visited = new bool[rows, cols];

            //Queue stores (row, col) pairs
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();

            //start bfs
            queue.Enqueue((startRow, startCol));

            visited[startRow, startCol] = true;

            Console.WriteLine($"BFS traversal starting from cell ({startRow}, {startCol}):");

            //mark the starting cell in the grid
            grid[startRow][startCol] = 2;

            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();
                int r = currentCell.r;
                int c = currentCell.c;


                Console.WriteLine($"  Visiting cell: ({r}, {c})");


                //check all the 4 neighbours (up , down,left,right)
                for (int i = 0; i < 4; i++)
                {
                    int nextR = r + dr[i];
                    int nextC = c + dc[i];

                    //check boundary conditions
                    if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols)
                    {
                        if (grid[nextR][nextC] == 1 && !visited[nextR, nextC])
                        {
                            visited[nextR, nextC] = true;
                            queue.Enqueue((nextR, nextC));
                            grid[nextR][nextC] = 2; // Mark the visited neighbor in the grid
                        }
                    }
                }



            }

            Console.WriteLine("\nFinal grid after BFS:");
            foreach (var row in grid)
            {
                Console.WriteLine(string.Join(",", row));
            }
        }


        public int ShortestPathBinaryMatrix(int[][] grid)
        {

            int[] udr = { 1, 0, -1, 1, -1, -1, 0, 1 };
            int[] udc = { 1, 1, 1, 0, 0, -1, -1, -1 };

            int rows = grid.Length;
            int cols = grid[0].Length;

            var visited = new bool[rows, cols];

            var queue = new Queue<(int r, int c)>();
            int counter = 0;

            queue.Enqueue((0, 0));
            visited[0, 0] = true;

            while (queue.Count > 0)
            {
                counter++;
                var currentCell = queue.Dequeue();
                int r = currentCell.r;
                int c = currentCell.c;

                Console.WriteLine($"  Visiting cell: ({r}, {c})");


                //check all 8 neighbours
                for (int i = 0; i < 8; i++)
                {
                    int nextR = r + udr[i];
                    int nextC = c + udc[i];


                    if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols)
                    {
                        
                    Console.WriteLine($"This is the value of grid: {grid[nextR][nextC]} and nextR is {nextR} and nextc is {nextC}");
                        if (nextR == (rows - 1) && nextC == (cols - 1))
                        {
                            Console.WriteLine("We are here");
                            if (grid[nextR][nextC] == 0)
                            {
                                return counter + 1;
                            }
                            return -1;
                        }

                        if (grid[nextR][nextC] == 0 && !visited[nextR, nextC])
                        {
                            Console.WriteLine($"this is our queue now: {string.Join(",", queue)}");
                            visited[nextR, nextC] = true;
                            queue.Enqueue((nextR, nextC));
                        }



                    }


                }


            }

            return -1;





        }

        public int NumIslands(string[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int counter = 0;

            var queue = new Queue<(int r, int c)>();

            var visited = new bool[rows, cols];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == "1" && !visited[i, j])
                    {
                        queue.Enqueue((i, j));
                        Bfs();
                        counter++;

                    }
                }
            }


            void Bfs()
            {
                while (queue.Count > 0)
                {
                    var currentCell = queue.Dequeue();

                    int r = currentCell.r;
                    int c = currentCell.c;

                    for (int k = 0; k < 4; k++)
                    {
                        int nextR = r + dr[k];
                        int nextC = c + dc[k];
                        if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols)
                        {
                            if (grid[nextR][nextC] == "1" && !visited[nextR, nextC])
                            {
                                visited[nextR, nextC] = true;
                                queue.Enqueue((nextR, nextC));
                            }
                        }
                    }
                }
            }

            return counter;

        }

        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {

            int[][] DepthFirstSearch()
            {
                if (image[sr][sc] == color)
                {
                    return image;
                }
                var sourcecolor = image[sr][sc];
                void Dfs(int r, int c)
                {
                    if (r < 0 || c < 0 || r == image.Length || c == image[0].Length)
                    {
                        return;
                    }


                    if (image[r][c] != sourcecolor)
                    {
                        return;
                    }

                    image[r][c] = color;

                    Dfs(r - 1, c);
                    Dfs(r, c - 1);
                    Dfs(r + 1, c);
                    Dfs(r, c + 1);
                }

                Dfs(sr, sc);

                foreach (var pair in image)
                {
                    Console.WriteLine(string.Join(",", pair));
                }

                return image;
            }

            DepthFirstSearch();

            int[][] BreadthFirstSearch()
            {
                if (image[sr][sc] == color)
                {
                    return image;
                }
                var sourcecolor = image[sr][sc];

                var queue = new Queue<int>();

                var visited = new HashSet<int>();

                queue.Enqueue(sourcecolor);

                while (queue.Count > 1)
                {
                    var u = queue.Dequeue();

                    Console.WriteLine($" Visiting node: {u}");

                    for (int i = 0; i < image.Length; i++)
                    {
                        // if (image[u][i] == 1 && )
                    }
                }

                return image;


            }
            BreadthFirstSearch();
            return image;

        }
    }
}
