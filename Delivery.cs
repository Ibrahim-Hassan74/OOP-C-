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
            var delivery = new Delivery { Id = 100, CustomerName = "Ibrahim Hassan", Address = "Minya" };
            var service = new DeliveryService();
            service.Start(delivery);
            WriteLine(delivery);
        }
    }

    public class DeliveryService
    {
        public void Start(Delivery delivery)
        {
            Process(delivery);
            Ship(delivery);
            InTransit(delivery);
            Deliver(delivery);
        }
        private void Process(Delivery delivery)
        {
            FakeIt("Processing delivery");
            delivery.DeliveryStatus = DeliveryStatus.PROCESSED;
        }
        private void Ship(Delivery delivery)
        {
            FakeIt("Shipping delivery");
            delivery.DeliveryStatus = DeliveryStatus.SHIPPED;
        }
        private void InTransit(Delivery delivery)
        {
            FakeIt("Moving delivery to transit");
            delivery.DeliveryStatus = DeliveryStatus.INTRANSIT;
        }
        private void Deliver(Delivery delivery)
        {
            FakeIt("Delivering delivery");
            delivery.DeliveryStatus = DeliveryStatus.DELIVERED;
        }

        private void FakeIt(String title)
        {
            Write(title);
            for (int i = 0; i < 6; i++)
            {
                System.Threading.Thread.Sleep(300);
                Console.Write('.');
            }
            WriteLine();
        }
    }

    public class Delivery
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public override string ToString()
        {
            return $"{{\n   Id:    {Id}\n   Customer Name:   {CustomerName}\n   Address:   {Address}\n   DeliveryStatus:   {DeliveryStatus}\n}}";
        }
    }

    public enum DeliveryStatus
    {
        UNKNOWN,
        PROCESSED,
        SHIPPED,
        INTRANSIT,
        DELIVERED,
    }
}
