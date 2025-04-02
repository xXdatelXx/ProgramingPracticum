namespace ProgrammingPracticum;

public interface IWallet {
   decimal Amount(Currency currency);
   void Add(Currency currency, decimal amount);
   void Remove(Currency currency, decimal amount);
}