namespace ProgrammingPracticum;

public class CurrencyExchange(Currency balance, int count) : ICurrencyExchange {
   public decimal Balance(Currency currency) => balance.Rate / currency.Rate * count;

   public decimal Convert(Currency from, Currency to, decimal amount)
   {
      if(Balance(from) < amount)
         throw new InvalidOperationException("Insufficient funds");
      
      return amount * from.Rate / to.Rate;
   }
}