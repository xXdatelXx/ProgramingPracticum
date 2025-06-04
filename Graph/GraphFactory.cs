namespace IETA.Graph;

public sealed class GraphFactory {
   public Graph Create() {
      int vertexCount;
      Console.Write("Write number of vertexes: ");
      while (int.TryParse(Console.ReadLine(), out vertexCount) && vertexCount < 0)
         Console.WriteLine("Error: Please try again!.");

      Dictionary<int, List<int>> graphDictionary = new();

      for (int i = 1; i <= vertexCount; i++)
         while (true) {
            Console.Write($"Write vertexes that chain with {i}, with space: ");
            string? input = Console.ReadLine();
            try {
               List<int> edges = input!
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToList();

               if (edges.Any(i => i > vertexCount))
                  throw new Exception();

               graphDictionary[i] = edges;
               break;
            }
            catch {
               Console.WriteLine("Error: Please try again!.");
            }
         }

      return new Graph(graphDictionary);
   }
   
   public Graph CreateRandom(int vertexCount, int edgeCount, bool allowSelfLoops = false, bool directed = false) {
      if (vertexCount <= 0 || edgeCount < 0)
         throw new ArgumentException("Invalid vertex or edge count.");

      Random random = new();
      Dictionary<int, List<int>> graphDictionary = new();

      // Initialize dictionary with empty lists
      for (int i = 1; i <= vertexCount; i++)
         graphDictionary[i] = new List<int>();

      HashSet<(int, int)> edges = new();

      while (edges.Count < edgeCount) {
         int from = random.Next(1, vertexCount + 1);
         int to = random.Next(1, vertexCount + 1);

         if (!allowSelfLoops && from == to)
            continue;

         var edge = (from, to);
         var reverseEdge = (to, from);

         if (directed) {
            if (edges.Add(edge))
               graphDictionary[from].Add(to);
         } else {
            if (!edges.Contains(edge) && !edges.Contains(reverseEdge)) {
               edges.Add(edge);
               graphDictionary[from].Add(to);
               graphDictionary[to].Add(from);
            }
         }
      }

      return new Graph(graphDictionary);
   }
   
   public Graph CreateHardcoded() {
      var graphDictionary = new Dictionary<int, List<int>> {
         {1, [2, 6]},
         {2, [3, 1]},
         {3, [2, 4, 5]},
         {4, [3]},
         {5, [3, 6, 14]},
         {6, [1, 7, 5]},
         {7, [6]},
         {8, [6, 15, 9]},
         {9, [8, 10]},
         {10, [9, 11]},
         {11, [12, 10]},
         {12, [13, 11]},
         {13, [14, 12]},
         {14, [5, 15, 13]},
         {15, [14, 8]},
      };

      return new Graph(graphDictionary);
   }
   
   public GraphWithWeight CreateHardcodedWithWeights() {
      var graph = new Dictionary<int, List<WeightedEdge>>();

      AddEdge(1, 2, -50, 10);
      AddEdge(2, 1, -50, 10);

      AddEdge(1, 6, 20, 12);
      AddEdge(6, 1, 20, 12);

      AddEdge(2, 3, 0, 15);
      AddEdge(3, 2, 0, 15);

      AddEdge(3, 4, 75, 18);
      AddEdge(4, 3, 75, 18);

      AddEdge(3, 5, -30, 20);
      AddEdge(5, 3, -30, 20);

      AddEdge(5, 6, 40, 22);
      AddEdge(6, 5, 40, 22);

      AddEdge(6, 7, -90, 24);
      AddEdge(7, 6, -90, 24);

      AddEdge(5, 14, 15, 26);
      AddEdge(14, 5, 15, 26);

      AddEdge(8, 6, -5, 28);
      AddEdge(6, 8, -5, 28);

      AddEdge(8, 9, 60, 30);
      AddEdge(9, 8, 60, 30);

      AddEdge(8, 15, 10, 32);
      AddEdge(15, 8, 10, 32);

      AddEdge(9, 10, -80, 34);
      AddEdge(10, 9, -80, 34);

      AddEdge(10, 11, 5, 36);
      AddEdge(11, 10, 5, 36);

      AddEdge(11, 12, -25, 38);
      AddEdge(12, 11, -25, 38);

      AddEdge(12, 13, 100, 42);
      AddEdge(13, 12, 100, 42);

      AddEdge(13, 14, -60, 45);
      AddEdge(14, 13, -60, 45);

      AddEdge(14, 15, 85, 50);
      AddEdge(15, 14, 85, 50);

      return new GraphWithWeight(graph);

      void AddEdge(int from, int to, int weight1, int weight2) {
         if (!graph.ContainsKey(from))
            graph[from] = new List<WeightedEdge>();
         graph[from].Add(new WeightedEdge(to, weight1, weight2));
      }
   }
   
   public GraphWithWeight CreateWithTwoWeights() {
      int vertexCount;
      Console.Write("Write number of vertexes: ");
      while (!int.TryParse(Console.ReadLine(), out vertexCount) || vertexCount <= 0)
         Console.WriteLine("Error: Please enter a positive integer.");

      var graph = new Dictionary<int, List<WeightedEdge>>();

      for (int i = 1; i <= vertexCount; i++) {
         graph[i] = new List<WeightedEdge>();

         while (true) {
            Console.Write($"Enter neighbors of vertex {i} in format 'to weight1 weight2', separated by commas (or leave empty if none): ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
               break;

            try {
               var edges = input
                  .Split(',', StringSplitOptions.RemoveEmptyEntries)
                  .Select(edgeStr => edgeStr.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries))
                  .Select(parts => {
                     if (parts.Length != 3)
                        throw new FormatException();
                     int to = int.Parse(parts[0]);
                     int weight1 = int.Parse(parts[1]);
                     int weight2 = int.Parse(parts[2]);

                     if (to < 1 || to > vertexCount)
                        throw new ArgumentOutOfRangeException();

                     return new WeightedEdge(to, weight1, weight2);
                  });

               graph[i].AddRange(edges);
               break;
            }
            catch {
               Console.WriteLine("Error: Invalid format. Example: 2 10 5, 3 7 8");
            }
         }
      }

      return new GraphWithWeight(graph);
   }

}