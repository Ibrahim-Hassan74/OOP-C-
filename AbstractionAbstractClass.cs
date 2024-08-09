global using static System.Console;
global using static System.Math;
global using static System.ConsoleColor;
global using main;
using System.ComponentModel;
using System.Collections;
using System;
using System.Numerics;
using System.Collections.Generic;
using maincs.Models;
namespace maincs.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cashier c = new Cashier(new Cash());
            c.CheckOut(99999.99m);
            c = new Cashier(new Debit());
            c.CheckOut(212.21m);
            c = new Cashier(new Mastercard());
            c.CheckOut(928981.222m);
            c = new Cashier(new Via());
            c.CheckOut(3412.21m);
        }
    }
    public class Cashier
    {
        private IPayment _payment;
        public Cashier(IPayment payment) => _payment = payment;
        public void CheckOut(decimal amount) => _payment.Pay(amount);

    }
    public abstract class IPayment
    {
        public abstract void Pay(decimal amount);
    }
    public class Cash : IPayment
    {
        public override void Pay(decimal amount) => WriteLine($"Cash Payment: ${Round(amount, 2):N0}");
    }

    public class Debit : IPayment
    {
        public override void Pay(decimal amount) => WriteLine($"Debit Payment: ${Round(amount, 2):N0}");
    }
    public class Mastercard : IPayment
    {
        public override void Pay(decimal amount) => WriteLine($"Mastercard Payment: ${Round(amount, 2):N0}");
    }
    public class Via : IPayment
    {
        public override void Pay(decimal amount) => WriteLine($"Via Payment: ${Round(amount, 2):N0}"); 
    }
}
