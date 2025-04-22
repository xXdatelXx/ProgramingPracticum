namespace ProgrammingPracticum;

public sealed class ExternalStudent(DateTime sessionDate, int tuitionFee) {
   public bool ScholarshipRecipient => false;
   public int WeeklyLessons => 0;
   public int TuitionFee { get; } = tuitionFee;
   public DateTime SessionDate { get; } = sessionDate;
   
   public void Eat() => 
      Console.WriteLine("BudgetStudent is eating in a Michelin restaurants.");
   
   public override string ToString() => 
      $"BudgetStudent: {ScholarshipRecipient}, {TuitionFee}, {WeeklyLessons}, {SessionDate}";
}