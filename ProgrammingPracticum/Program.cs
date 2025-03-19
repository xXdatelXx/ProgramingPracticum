using System.Text.Json;

Time time = new Time(23, 59, 50);
Console.WriteLine(time);  // 23:59:50
time.AddTime(0, 0, 15);
Console.WriteLine(time);  // 00:00:05

string filename = "time.json";
time.SaveToJson(filename);
        
Time loadedTime = Time.LoadFromJson(filename);
Console.WriteLine(loadedTime);

class Time {
   public int _hours { get; private set; }
   public int _minutes { get; private set; }
   public int _seconds { get; private set; }
   
   public Time(int _hours, int _minutes, int _seconds) 
   {
      this._hours = _hours;
      this._minutes = _minutes;
      this._seconds = _seconds;
   }

   public void SetTime(int hours, int minutes, int seconds)
   {
      if (hours < 0 || hours >= 24 || minutes < 0 || minutes >= 60 || seconds < 0 || seconds >= 60)
         throw new ArgumentException("Invalid time");
      
      _hours = hours;
      _minutes = minutes;
      _seconds = seconds;
   }

   public void SetHours(int hours)
   {
      if (hours is < 0 or >= 24)
         throw new ArgumentException("Hours must be between 0 and 24");
      
      _hours = hours;
   }

   public void SetMinutes(int minutes)
   {
      if (minutes is < 0 or >= 60)
         throw new ArgumentException("Minutes must be between 0 and 60");
      
      _minutes = minutes;
   }

   public void SetSeconds(int seconds)
   {
      if (seconds < 0 || seconds >= 60)
         throw new ArgumentException("Seconds must be between 0 and 60");
      
      _seconds = seconds;
   }

   public void AddTime(int hours = 0, int minutes = 0, int seconds = 0)
   {
      const int secondsInHours = 3600;
      const int daySeconds = 8640;
      
      int totalSeconds = _hours * secondsInHours + _minutes * 60 + _seconds;
      totalSeconds += hours * secondsInHours + minutes * 60 + seconds;
      totalSeconds %= daySeconds;

      _hours = totalSeconds / secondsInHours;
      _minutes = (totalSeconds % secondsInHours) / 60;
      _seconds = totalSeconds % 60;
   }

   public override string ToString() => 
      $"{_hours:D2}:{_minutes:D2}:{_seconds:D2}";
   
   public void SaveToJson(string filename)
   {
      string json = JsonSerializer.Serialize(this);
      File.WriteAllText(filename, json);
   }

   public static Time LoadFromJson(string filename)
   {
      string json = File.ReadAllText(filename);
      return JsonSerializer.Deserialize<Time>(json);
   }
}
