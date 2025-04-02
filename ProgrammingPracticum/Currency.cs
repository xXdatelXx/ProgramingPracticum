namespace ProgrammingPracticum;

public abstract class Currency(decimal rate) {
   public decimal Rate { get; private set; } = rate;

   public void Update(decimal rate) {
      ArgumentOutOfRangeException.ThrowIfNegative(rate);
      Rate = rate;
   }
}

public class Dollar(decimal rate) : Currency(rate);
public class Euro(decimal rate) : Currency(rate);
public class Hrn(decimal rate) : Currency(rate);
public class Rub(decimal rate) : Currency(rate);
public class Funt(decimal rate) : Currency(rate);
public class Fantics(decimal rate) : Currency(rate);