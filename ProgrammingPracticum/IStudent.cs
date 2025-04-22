namespace ProgrammingPracticum;

public interface IStudent : IPerson {
   bool ScholarshipRecipient { get; }
   int TuitionFee { get; }
   int WeeklyLessons { get; }
   DateTime SessionDate { get; }
}