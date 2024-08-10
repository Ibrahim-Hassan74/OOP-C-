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
    public delegate string StringManipulator(string s);
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var temp = new List<Tempreture>();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
                temp.Add(new Tempreture(rnd.Next(-100, 100)));
            temp.Sort();
            foreach(var i in  temp)
                WriteLine(i.Value);
        }
    }
    public class Tempreture : IComparable
    {
        private int _value;
        public int Value => _value;
        public Tempreture(int value)
        {
            _value = value;
        }

        public int CompareTo(object? obj)
        {
            if (obj is null)
                return 1;
            var tmp = obj as Tempreture;
            if (tmp is null)
                throw new ArgumentException("Object is not a Tempreture");
            return this._value.CompareTo(tmp._value);
        }
    }

}
