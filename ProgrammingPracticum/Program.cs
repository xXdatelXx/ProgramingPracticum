using ProgrammingPracticum;

new Exercise1().Run();

Dollar usd = new(37);
Euro eur = new(40);
Hrn uah = new(1);
Rub rub = new(0.5m);
Funt gbp = new(50);
Fantics fnt = new(0.1m);

Wallet wallet = new(new Dictionary<Currency, decimal>
{
   { usd, 100 },
   { eur, 50 }
});

CurrencyExchange exchange = new(usd, 500);
        
Console.WriteLine($"Total currency in exchange: {exchange.Balance(usd)}");

wallet.Remove(usd, 20);
wallet.Add(eur, exchange.Convert(usd, eur, 20));
