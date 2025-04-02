namespace ProgrammingPracticum;

public interface ICurrencyExchange {
   decimal Convert(Currency from, Currency to, decimal amount);
   decimal Balance(Currency currency);
}