namespace ProgrammingPracticum;

public class Wallet(Dictionary<Currency, decimal> balances) : IWallet {
   public decimal Amount(Currency currency) => balances.GetValueOrDefault(currency, 0);

   public void Add(Currency currency, decimal amount) {
      if (!balances.TryAdd(currency, amount))
         balances[currency] += amount;
   }
   
   public void Remove(Currency currency, decimal amount) {
      if (!balances.TryGetValue(currency, out decimal value) || value < amount)
         throw new InvalidOperationException("Insufficient funds");

      balances[currency] -= amount;
      
      if (balances[currency] == 0)
         balances.Remove(currency);
   }
}