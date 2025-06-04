namespace IETA.Graph;

public sealed class GraphSearchAlgorithm(Graph graph) {
   /// <summary>
   ///    Breadth-first search
   /// </summary>
   public int[] BFS(int vertex) {
      Queue<int> queue = [];
      HashSet<int> result = [];

      while (result.Count != graph.Elements.Count) {
         result.Add(vertex);
         graph.Elements[vertex].ForEach(queue.Enqueue);
         vertex = queue.Dequeue();
      }

      return result.ToArray();
   }

   public List<int> BFSPath(int start, int end) {
      Queue<int> queue = new();
      Dictionary<int, int> parent = new();

      queue.Enqueue(start);
      parent[start] = -1;

      while (queue.Count > 0) {
         int current = queue.Dequeue();

         if (current == end) {
            List<int> path = new();
            while (current != -1) {
               path.Add(current);
               current = parent[current];
            }
            path.Reverse();
            return path;
         }

         foreach (int neighbor in graph.Elements[current]) {
            if (!parent.ContainsKey(neighbor)) {
               queue.Enqueue(neighbor);
               parent[neighbor] = current;
            }
         }
      }

      return []; // Путь не найден
   }
   
   /// <summary>
   ///    Decorrelated Fast Cipher
   /// </summary>
   public int[] DFS(int vertex) {
      HashSet<int> result = [];
      Stack<int> stack = [];

      Recurs(vertex);

      return result.ToArray();

      void Recurs(int current) {
         if (!result.Add(current))
            return;

         stack.Push(current);
         graph.Elements[current].ForEach(Recurs);
         stack.Pop();
      }
   }
   
   public List<int> Dijkstra(GraphWithWeight graph, int start, int end, int weightChoice)
   {
      var distances = new Dictionary<int, int>();
      var previous = new Dictionary<int, int?>();
      var priorityQueue = new PriorityQueue<int, int>();

      foreach (var node in graph.AdjacencyList.Keys)
      {
         distances[node] = int.MaxValue;
         previous[node] = null;
      }

      distances[start] = 0;
      priorityQueue.Enqueue(start, 0);

      while (priorityQueue.Count > 0)
      {
         int current = priorityQueue.Dequeue();

         if (current == end)
            break;

         if (!graph.AdjacencyList.TryGetValue(current, out var neighbors))
            continue;

         foreach (var edge in neighbors)
         {
            int weight = weightChoice == 1 ? edge.Weight1 : edge.Weight2;
            int newDist = distances[current] + weight;

            if (newDist < distances[edge.To])
            {
               distances[edge.To] = newDist;
               previous[edge.To] = current;
               priorityQueue.Enqueue(edge.To, newDist);
            }
         }
      }

      return ReconstructPath(previous, end);
   }

   private List<int> ReconstructPath(Dictionary<int, int?> previous, int end)
   {
      var path = new List<int>();
      for (int? at = end; at != null; at = previous[at.Value])
         path.Insert(0, at.Value);

      return path.Count > 0 && path[0] == end ? new List<int>() : path;
   }
}