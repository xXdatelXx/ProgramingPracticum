namespace ProgrammingPracticum;

public interface ICurrencyExchange {
   decimal Balance(Currency currency);
   decimal Convert(Currency from, Currency to, decimal amount);
}