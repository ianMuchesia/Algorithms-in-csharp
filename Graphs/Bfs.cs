using System.Data;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using Microsoft.VisualBasic;

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

                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    var currentCell = queue.Dequeue();
                    int r = currentCell.r;
                    int c = currentCell.c;

                    // CHECK IMMEDIATELY
                    if (r == rows - 1 && c == cols - 1)
                    {
                        return counter + 1;
                    }

                    // enqueue neighbors
                    for (int d = 0; d < 8; d++)
                    {
                        int nextR = r + udr[d];
                        int nextC = c + udc[d];

                        if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols &&
                            grid[nextR][nextC] == 0 && !visited[nextR, nextC])
                        {
                            visited[nextR, nextC] = true;
                            queue.Enqueue((nextR, nextC));
                        }
                    }
                }
                Console.WriteLine($"this is the counter before additon: {counter}");
                counter++;
                Console.WriteLine($"the queue at this poin is: {string.Join(",", queue)}");
            }
            return -1;
        }


        public int ShortestPathBinaryMatrixPaint(int[][] grid)
        {

            int[] udr = { 1, 0, -1, 1, -1, -1, 0, 1 };
            int[] udc = { 1, 1, 1, 0, 0, -1, -1, -1 };

            int rows = grid.Length;
            int cols = grid[0].Length;

            var queue = new Queue<(int r, int c)>();

            queue.Enqueue((0, 0));
            grid[0][0] = 1;

            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();

                int r = currentCell.r;
                int c = currentCell.c;

                int currentNummber = grid[r][c];
                Console.WriteLine($"Current Number: {currentNummber}");


                for (int i = 0; i < 8; i++)
                {
                    int nextR = r + udr[i];
                    int nextC = c + udc[i];

                    if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols &&
                          grid[nextR][nextC] == 0)
                    {
                        if (nextR == rows - 1 && nextC == cols - 1)
                        {
                            return (currentNummber + 1);
                        }
                        Console.WriteLine($"current nextR, nextC: {grid[nextR][nextC]}");
                        grid[nextR][nextC] = currentNummber + 1;
                        queue.Enqueue((nextR, nextC));
                    }
                }
            }

            return -1;

        }

        public int[][] UpdateMatrix(int[][] mat)
        {
            int rows = mat.Length;
            int cols = mat[0].Length;
            foreach (var pair in mat)
            {
                Console.WriteLine(string.Join(",", pair));
            }


            var queue = new Queue<(int r, int c)>();

            var visited = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (mat[i][j] > 0)
                    {
                        queue.Enqueue((i, j));
                        visited[i, j] = true;
                        Bfs();

                    }
                }
            }

            void Bfs()
            {

                Console.WriteLine(string.Join(",", queue));
                var currentCell = queue.Dequeue();
                int r = currentCell.r;
                int c = currentCell.c;

                for (int d = 0; d < 4; d++)
                {
                    int nextR = r + dr[d];
                    int nextC = c + dc[d];

                    Console.WriteLine($"nextR is {nextR}, nextC is {nextC}");
                    // if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols &&
                    //  mat[nextR][nextC] == 0 && mat[r][c] > 1)
                    // {
                    //     Console.WriteLine($"second one nextR is {nextR}, nextC is {nextC}");
                    //     mat[r][c] = 1;

                    // }
                    if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols &&
                     mat[nextR][nextC] > 0 && !visited[nextR, nextC])
                    {
                        Console.WriteLine($"second one nextR is {nextR}, nextC is {nextC}");
                        visited[nextR, nextC] = true;
                        mat[nextR][nextC] = mat[r][c] + 1;
                        queue.Enqueue((nextR, nextC));

                    }
                }



            }
            Console.WriteLine();
            foreach (var pair in mat)
            {
                Console.WriteLine(string.Join(",", pair));
            }
            return mat;
        }

        public int[][] UpdateMatrixSolution(int[][] mat)
        {
            int rows = mat.Length;
            int cols = mat[0].Length;

            int MAX_VALUE = rows * cols;
            var queue = new Queue<(int r, int c)>();


            Console.WriteLine();
            foreach (var pair in mat)
            {
                Console.WriteLine(string.Join(",", pair));
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        queue.Enqueue((i, j));
                    }
                    else
                    {
                        mat[i][j] = MAX_VALUE;
                    }
                }
            }

            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();

                int r = currentCell.r;
                int c = currentCell.c;

                for (int d = 0; d < 4; d++)
                {
                    int nextR = r + dr[d];
                    int nextC = c + dc[d];

                    if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols &&
                   mat[nextR][nextC] > mat[r][c] + 1)
                    {
                        queue.Enqueue((nextR, nextC));
                        mat[nextR][nextC] = mat[r][c] + 1;
                    }
                }
            }
            Console.WriteLine();
            foreach (var pair in mat)
            {
                Console.WriteLine(string.Join(",", pair));
            }

            return mat;
        }

        public int OrangesRotting(int[][] grid)
        {

            int rows = grid.Length;

            int cols = grid[0].Length;

            var queue = new Queue<(int r, int c)>();

            int counter = 0;


            var visited = new bool[rows, cols];

            foreach (var pair in grid)
            {
                Console.WriteLine(string.Join(",", pair));
            }



            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 2 && !visited[i, j])
                    {
                        queue.Enqueue((i, j));
                        Bfs(i, j);


                    }


                }
            }


            void Bfs(int i, int j)
            {
                while (queue.Count > 0)
                {

                    int levelSize = queue.Count;


                    Console.WriteLine($"this is hte level size: {levelSize}");


                    for (int l = 0; l < levelSize; l++)
                    {
                        var currentCell = queue.Dequeue();
                        int r = currentCell.r;
                        int c = currentCell.c;

                        for (int d = 0; d < 4; d++)
                        {
                            int nextR = r + dr[d];
                            int nextC = c + dc[d];

                            if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols && grid[nextR][nextC] == 1)
                            {
                                grid[nextR][nextC] = 2;
                                queue.Enqueue((nextR, nextC));
                                visited[nextR, nextC] = true;
                            }
                        }
                    }
                    Console.WriteLine($"this is the queue: {string.Join("", queue)}");
                    if (queue.Count > 0)
                    {
                        counter++;
                    }




                }
            }
            foreach (var pair in grid)
            {
                Console.WriteLine(string.Join(",", pair));
            }

            return counter;

        }

        public int OrangesRotting2(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            var queue = new Queue<(int r, int c)>();

            int freshOrangesCount = 0;
            int minutes = 0;

            // 1. Initialize the queue with all rotten oranges and count fresh oranges

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 2)
                    {
                        queue.Enqueue((r, c));
                    }
                    else if (grid[r][c] == 1)
                    {
                        freshOrangesCount++;
                    }
                }
            }


            if (freshOrangesCount == 0)
            {
                return 0;
            }


            // The BFS processes level by level, where each level represents one minute.
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                bool didRotThisMinute = false; // Flag to check if any orange rotted in this minute

                for (int i = 0; i < levelSize; i++)
                {
                    var current = queue.Dequeue();
                    int r = current.r;
                    int c = current.c;

                    //check all 4 neighbours
                    for (int d = 0; d < 4; d++)
                    {
                        int nextR = r + dr[d];
                        int nextC = c + dc[d];

                        //check bounds and if the neighbor is a fresh orange
                        if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols && grid[nextR][nextC] == 1)
                        {
                            grid[nextR][nextC] = 2;
                            queue.Enqueue((nextR, nextC));
                            freshOrangesCount--;
                            didRotThisMinute = true;
                        }
                    }
                }

                if (queue.Count > 0 && didRotThisMinute) // Only increment if there are oranges to rot in the *next* minute
                {
                    minutes++;
                }
            }
            if (freshOrangesCount == 0)
            {
                return minutes;
            }
            else
            {
                return -1;
            }






        }

        public int MaxDistance(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            var queue = new Queue<(int r, int c)>();

            int counter = 0;

            int distance = 0;
            int totalWaters = 0;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        queue.Enqueue((i, j));
                    }
                    else
                    {
                        totalWaters++;
                    }
                }
            }

            if (totalWaters == 0)
            {
                return -1;
            }

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                bool didHaveWaters = false;

                for (int k = 0; k < levelSize; k++)
                {
                    var current = queue.Dequeue();
                    int r = current.r;
                    int c = current.c;

                    for (int d = 0; d < 4; d++)
                    {
                        int nextR = r + dr[d];
                        int nextC = c + dc[d];

                        if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols && grid[nextR][nextC] == 0)
                        {
                            didHaveWaters = true;
                            queue.Enqueue((nextR, nextC));
                            grid[nextR][nextC] = 1;
                            totalWaters--;

                        }

                    }
                }
                if (didHaveWaters && queue.Count > 0)
                {
                    distance++;
                }
            }

            return distance;
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


        public int ClosedIsland(int[][] grid)
        {

            int rows = grid.Length;
            int cols = grid[0].Length;
            foreach (var pair in grid)
            {
                Console.WriteLine(string.Join(",", pair));
            }

            var queue = new Queue<(int r, int c)>();
            int counter = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 0 && i != 0 && i != rows - 1 && j != 0 && j != cols - 1)
                    {
                        Console.WriteLine($"the value of i is {i} and the value of j is {j}");
                        queue.Enqueue((i, j));
                        Bfs();

                    }
                }
            }

            void Bfs()
            {

                bool IsAtEdge = false;

                while (queue.Count > 0)
                {

                    var current = queue.Dequeue();
                    int r = current.r;
                    int c = current.c;


                    for (int d = 0; d < 4; d++)
                    {
                        int nextR = r + dr[d];
                        int nextC = c + dc[d];

                        if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols && grid[nextR][nextC] == 0)
                        {
                            if (nextR == 0 || nextR == rows - 1)
                            {
                                IsAtEdge = true;

                            }

                            if (nextC == 0 || nextC == cols - 1)
                            {
                                IsAtEdge = true;

                            }
                            Console.WriteLine($"the value of nextR is {nextR} and the value of nextC is {nextC}");
                            grid[nextR][nextC] = 1;
                            queue.Enqueue((nextR, nextC));


                        }
                    }

                    // if (IsAtEdge)
                    // {
                    //     break;
                    // }
                }

                if (queue.Count > 0) queue.Clear();
                if (!IsAtEdge)
                {
                    counter++;
                }
            }

            return counter;

        }

        public char[][] UpdateBoard(char[][] board, int[] click)
        {
             int[] udr = { 1, 0, -1, 1, -1, -1, 0, 1 };
            int[] udc = { 1, 1, 1, 0, 0, -1, -1, -1 };
            if (board[click[0]][click[1]] == 'M')
            {
                board[click[0]][click[1]] = 'X';
                return board;
            }
            int rows = board.Length;
            int cols = board[0].Length;

            var queue = new Queue<(int r, int c)>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i][j] == 'M')
                    {
                        queue.Enqueue((i, j));
                    }
                }
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                int r = current.r;
                int c = current.c;

                for (int d = 0; d < 8; d++)
                {
                    int nextR = r + udr[d];
                    int nextC = c + udc[d];

                    
                }


            }
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
