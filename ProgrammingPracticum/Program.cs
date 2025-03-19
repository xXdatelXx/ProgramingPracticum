Time time = new Time(23, 59, 50);
Console.WriteLine(time);  // 23:59:50
time.AddTime(0, 0, 15);
Console.WriteLine(time);  // 00:00:05

class Time(int Hours, int Minutes, int Seconds)
{
   public void SetTime(int hours, int minutes, int seconds)
   {
      if (hours < 0 || hours >= 24 || minutes < 0 || minutes >= 60 || seconds < 0 || seconds >= 60)
         throw new ArgumentException("Недопустиме значення часу");
      
      Hours = hours;
      Minutes = minutes;
      Seconds = seconds;
   }

   public void SetHours(int hours)
   {
      if (hours is < 0 or >= 24)
         throw new ArgumentException("Недопустиме значення годин");
      
      Hours = hours;
   }

   public void SetMinutes(int minutes)
   {
      if (minutes is < 0 or >= 60)
         throw new ArgumentException("Недопустиме значення хвилин");
      
      Minutes = minutes;
   }

   public void SetSeconds(int seconds)
   {
      if (seconds < 0 || seconds >= 60)
         throw new ArgumentException("Недопустиме значення секунд");
      
      Seconds = seconds;
   }

   public void AddTime(int hours = 0, int minutes = 0, int seconds = 0)
   {
      int totalSeconds = Hours * 3600 + Minutes * 60 + Seconds;
      totalSeconds += hours * 3600 + minutes * 60 + seconds;
      totalSeconds %= 86400; // 24 години в секундах

      Hours = totalSeconds / 3600;
      Minutes = (totalSeconds % 3600) / 60;
      Seconds = totalSeconds % 60;
   }

   public override string ToString()
   {
      return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
   }
}
