namespace ProgrammingPracticum;

public sealed class Exercise1 {
   public void Run() {
      LightCar car1 = new ("Deo", "Grey", 1000);
      HeavyCar car2 = new ("Sitroen", "White", 2000);

      car1.SetColor("Red");
      car2.SetWeight(3000);
   }
   
   class LightCar(string brand, string color, int weight) : Car(brand, color, weight);
   class HeavyCar(string brand, string color, int weight) : Car(brand, color, weight);

   abstract class Car(string brand, string color, int weight) {
      public string Brand { get; private set; } = brand;
      public string Color { get; private set; } = color;
      public int Weight { get; private set; } = weight;

      public void SetBrand(string brand) {
         Console.WriteLine($"Changing brand from {Brand} to {brand}");
         Brand = brand;
      }

      public void SetColor(string color) {
         Console.WriteLine($"Changing color from {Color} to {color}");
         Color = color;
      }

      public void SetWeight(int weight) {
         Console.WriteLine($"Changing weight from {Weight} to {weight}");
         Weight = weight;
      }

      public override string ToString() => 
         $"Car: {Brand}, Color: {Color}, Weight: {Weight}kg";

      public override bool Equals(object? obj) {
         if (obj is not Car other) return false;
         return Brand == other.Brand && Color == other.Color && Weight == other.Weight;
      }

      public override int GetHashCode() => 
         HashCode.Combine(Brand, Color, Weight);
   }
}