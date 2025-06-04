using IETA.Graph;

//Graph graph = new GraphFactory().CreateRandom(30, 30, false, false);
Graph graph = new GraphFactory().CreateHardcoded();
int start;

Console.WriteLine("Write number of start vertex: ");
while (int.TryParse(Console.ReadLine(), out start) && start < 0)
   Console.WriteLine("Error: try again");

Console.WriteLine("Ex1:");
new GraphSearchAlgorithm(graph)
   .DFS(start)
   .ToList()
   .ForEach(Console.Write);

Console.WriteLine("\nEx2:");
Console.WriteLine("Write number of end vertex: ");
int end = int.Parse(Console.ReadLine());
new GraphSearchAlgorithm(graph)
   .BFSPath(start, end)
   .ToList()
   .ForEach(Console.Write);

Console.WriteLine("\nEx3:");
new GraphSearchAlgorithm(graph)
   .Dijkstra(new GraphFactory().CreateHardcodedWithWeights(), start, end, 0)
   .ToList()
   .ForEach(i => Console.Write($"{i} "));

Console.WriteLine("\nEx4:");
int[] coordinates = [-50, 20, 0, 75, -30, 40, -90, 15, -5, 60, 10, -80, 5, -25, 100, -60, 85];
int[] usersCount = [10, 12, 15, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 42, 45, 50];

Console.WriteLine("Sorted coordinates:");
int[] sortedCoordinates = SortArray(coordinates, 0, coordinates.Length - 1);
Console.WriteLine(string.Join(", ", sortedCoordinates));
Console.WriteLine("Sorted users count:");
int[] sortedUsersCount = SortArray(usersCount, 0, usersCount.Length - 1);
Console.WriteLine(string.Join(", ", sortedUsersCount));


int[] SortArray(int[] array, int leftIndex, int rightIndex)
{
   var i = leftIndex;
   var j = rightIndex;
   var pivot = array[leftIndex];
   while (i <= j)
   {
      while (array[i] < pivot)
      {
         i++;
      }
        
      while (array[j] > pivot)
      {
         j--;
      }
      if (i <= j)
      {
         (array[i], array[j]) = (array[j], array[i]);
         i++;
         j--;
      }
   }
    
   if (leftIndex < j)
      SortArray(array, leftIndex, j);
   if (i < rightIndex)
      SortArray(array, i, rightIndex);
   return array;
}


   