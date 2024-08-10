namespace maincs.Models
{
    public class Money
    {
        private decimal amount;
        public decimal Amount => amount;
        public Money(decimal amount)
        {
            this.amount = amount;
        }
        public static Money operator +(Money a, Money b)
        {
            return new Money(a.Amount + b.Amount);
        }
        public static Money operator -(Money a, Money b)
        {
            return new Money(a.Amount - b.Amount);
        }
        public static Money operator *(Money a, Money b)
        {
            return new Money(a.Amount * b.Amount);
        }

        public static Money operator /(Money a, Money b)
        {
            return new Money(a.Amount / b.Amount);
        }
        public static bool operator >(Money a, Money b)
        {
            return a.Amount > b.Amount;
        }
        public static bool operator <(Money a, Money b)
        {
            return a.Amount < b.Amount;
        }

        public static bool operator >=(Money a, Money b)
        {
            return a.Amount >= b.Amount;
        }
        public static bool operator <=(Money a, Money b)
        {
            return a.Amount <= b.Amount;
        }

        public static bool operator ==(Money a, Money b)
        {
            return a.Amount == b.Amount;
        }
        public static bool operator !=(Money a, Money b)
        {
            return a.Amount != b.Amount;
        }
        public static Money operator ++(Money a)
        {
            var val = a.Amount;
            return new Money(++val);
        }
        public static Money operator --(Money a)
        {
            var val = a.Amount;
            return new Money(--val);
        }

    }


}
