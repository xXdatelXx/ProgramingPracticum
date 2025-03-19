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
         throw new ArgumentException("Hours must be between 0 and 24");
      
      Hours = hours;
   }

   public void SetMinutes(int minutes)
   {
      if (minutes is < 0 or >= 60)
         throw new ArgumentException("Minutes must be between 0 and 60");
      
      Minutes = minutes;
   }

   public void SetSeconds(int seconds)
   {
      if (seconds < 0 || seconds >= 60)
         throw new ArgumentException("Seconds must be between 0 and 60");
      
      Seconds = seconds;
   }

   public void AddTime(int hours = 0, int minutes = 0, int seconds = 0)
   {
      const int secondsInHours = 3600;
      const int daySeconds = 8640;
      
      int totalSeconds = Hours * secondsInHours + Minutes * 60 + Seconds;
      totalSeconds += hours * secondsInHours + minutes * 60 + seconds;
      totalSeconds %= daySeconds;

      Hours = totalSeconds / secondsInHours;
      Minutes = (totalSeconds % secondsInHours) / 60;
      Seconds = totalSeconds % 60;
   }

   public override string ToString() => 
      $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
}
