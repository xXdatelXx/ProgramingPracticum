namespace ProgrammingPracticum;

public sealed class ContractStudent(bool scholarshipRecipient, int weeklyLessons, DateTime sessionDate, int tuitionFee) : IStudent {
      public bool ScholarshipRecipient { get; } = scholarshipRecipient;
      public int TuitionFee { get; } = tuitionFee;
      public int WeeklyLessons { get; } = weeklyLessons;
      public DateTime SessionDate { get; } = sessionDate;
   
      public void Eat() => 
         Console.WriteLine("BudgetStudent is eating a fast-food.");
      
      public override string ToString() => 
         $"BudgetStudent: {ScholarshipRecipient}, {TuitionFee}, {WeeklyLessons}, {SessionDate}";
}
