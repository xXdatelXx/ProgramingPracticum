using ProgrammingPracticum;

BudgetStudent budget = new(scholarshipRecipient: true, weeklyLessons: 5, sessionDate: DateTime.Now);
ContractStudent contract = new(scholarshipRecipient: false, weeklyLessons: 3, sessionDate: DateTime.Now, tuitionFee: 1000);
ExternalStudent external = new(sessionDate: DateTime.Now, tuitionFee: 2000);

Console.WriteLine(budget);
Console.WriteLine(contract);
Console.WriteLine(external);
budget.Eat();
contract.Eat();
external.Eat();