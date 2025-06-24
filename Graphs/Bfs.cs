namespace DataStructuresAlgorithms.Graphs
{
    public class LeetCodeBfsGraph
    {


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
