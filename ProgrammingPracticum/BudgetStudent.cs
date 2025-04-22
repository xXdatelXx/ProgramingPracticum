namespace ProgrammingPracticum;

class BudgetStudent(bool scholarshipRecipient, int weeklyLessons, DateTime sessionDate) : IStudent {
   public bool ScholarshipRecipient { get; } = scholarshipRecipient;
   public int TuitionFee => 0;
   public int WeeklyLessons { get; } = weeklyLessons;
   public DateTime SessionDate { get; } = sessionDate;
   
   public void Eat() => 
      Console.WriteLine("BudgetStudent is eating a healthy meal.");

   public override string ToString() => 
      $"BudgetStudent: {ScholarshipRecipient}, {TuitionFee}, {WeeklyLessons}, {SessionDate}";
}