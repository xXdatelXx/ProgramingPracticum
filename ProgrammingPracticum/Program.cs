using Newtonsoft.Json;

// Exercise 1
Console.WriteLine("Exercise 1");
Console.WriteLine("Input list: ");

List<int> list = [1, 2, 3, 4, 5];
list.ForEach(Console.Write);
for (int i = 0; i < list.Count - 1; i += 2) 
   (list[i], list[i + 1]) = (list[i + 1], list[i]);

Console.WriteLine("\nOutput list: ");
list.ForEach(Console.Write);
Console.WriteLine();



// Exercise 2
Console.WriteLine("Exercise 2");
Console.WriteLine("Input dictionary: ");

Dictionary<int, int> dict = new() {
   {1, 50}, {2, 10}, {3, 90}, {4, 30}, {5, 70}
};

dict.ToList().ForEach(kv => Console.WriteLine($"Key: {kv.Key}, Value: {kv.Value}"));

int min = dict.Values.Min();
int max = dict.Values.Max();

Console.WriteLine("Min value: " + min + ", Max value: " + max);

foreach (var key in dict.Where(kv => kv.Value == min || kv.Value == max).Select(kv => kv.Key)) 
   dict.Remove(key);

dict = dict.OrderBy(kv => kv.Key).ToDictionary(k => k.Key, v => v.Value);

Console.WriteLine("Output dictionary: ");
dict.ToList().ForEach(kv => Console.WriteLine($"Key: {kv.Key}, Value: {kv.Value}"));

string json = JsonConvert.SerializeObject(dict, Formatting.Indented);

// ProgrammingPracticum -> ProgrammingPracticum -> bin -> Release -> .exe
string path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
File.WriteAllText(Path.Combine(path, "dictionary.json"), json);



// Exercise 3
Console.WriteLine("Exercise 3");
Console.WriteLine("Input list: ");

List<int> list2 = [-5, 3, 8, -2, 7, 0, 6, -1, 9];
list2.ForEach(i => Console.Write(i + " "));

Console.WriteLine();
Console.WriteLine($"List2 where i > 0: {list2.Count(i => i > 0)}");
Console.WriteLine($"List2 sum where i % 2 != 0: {list2.Where(i => i % 2 != 0).Sum()}");