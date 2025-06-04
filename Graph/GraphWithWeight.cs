namespace IETA.Graph;

public sealed class GraphWithWeight(Dictionary<int, List<WeightedEdge>> adjacencyList) {
   public Dictionary<int, List<WeightedEdge>> AdjacencyList { get; } = adjacencyList;
}

public class WeightedEdge(int to, int weight1, int weight2) {
   public int To { get; } = to;
   public int Weight1 { get; } = weight1;
   public int Weight2 { get; } = weight2;
}

