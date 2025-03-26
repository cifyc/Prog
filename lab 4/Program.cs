using System;
using System.Collections.Generic;
using System.Linq;

namespace PortDateApp
{
    public class Day
    {
        public int Value { get; set; }
        public Day(int value)
        {
            Console.WriteLine("Створено об'єкт Day");
            Value = value;
        }
        public override string ToString() => $"Day: {Value}";
        public override bool Equals(object obj) => obj is Day d && d.Value == Value;
        public override int GetHashCode() => Value.GetHashCode();
    }
    public class Month
    {
        public int Value { get; set; }
        public Month(int value)
        {
            Console.WriteLine("Створено об'єкт Month");
            Value = value;
        }
        public override string ToString() => $"Month: {Value}";
        public override bool Equals(object obj) => obj is Month m && m.Value == Value;
        public override int GetHashCode() => Value.GetHashCode();
    }
    public class Year
    {
        public int Value { get; set; }
        public Month Month { get; set; }
        public Day Day { get; set; }
        public Year(int year, int month, int day)
        {
            Console.WriteLine("Створено об'єкт Year");
            Value = year;
            Month = new Month(month);
            Day = new Day(day);
        }
        public void PrintDayOfWeek()
        {
            DateTime date = new DateTime(Value, Month.Value, Day.Value);
            Console.WriteLine($"День тижня: {date.DayOfWeek}");
        }
        public void GetPeriodInfo(DateTime end)
        {
            DateTime start = new DateTime(Value, Month.Value, Day.Value);
            TimeSpan span = end - start;
            Console.WriteLine($"Кількість днів: {span.Days}");
            Console.WriteLine($"Кількість місяців: {span.Days / 30}");
        }
        public override string ToString() => $"Дата: {Day.Value}.{Month.Value}.{Value}";
        public override bool Equals(object obj) => obj is Year y && y.Value == Value && y.Month.Equals(Month) && y.Day.Equals(Day);
        public override int GetHashCode() => HashCode.Combine(Value, Month, Day);
    }
    public class Ship
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Load { get; set; }
        public double FuelPerHour { get; set; }
        public int YearBuilt { get; set; }
        public Ship(string name, int capacity, int load, double fuel, int year)
        {
            Console.WriteLine("Створено об'єкт Ship");
            Name = name;
            Capacity = capacity;
            Load = load;
            FuelPerHour = fuel;
            YearBuilt = year;
        }
        public override string ToString() => $"{Name} | Місткість: {Capacity} | Вантажність: {Load} | Паливо/год: {FuelPerHour} | Рік: {YearBuilt}";
        public override bool Equals(object obj) => obj is Ship s && s.Name == Name;
        public override int GetHashCode() => Name.GetHashCode();
    }
    public class Carrier
    {
        public string Name { get; set; }
        public List<Ship> Ships { get; set; } = new List<Ship>();
        public Carrier(string name)
        {
            Console.WriteLine("Створено об'єкт Carrier");
            Name = name;
        }
        public void AddShip(Ship ship)
        {
            Ships.Add(ship);
            Console.WriteLine($"Додано корабель: {ship.Name}");
        }
        public void TotalStats()
        {
            Console.WriteLine($"Загальна місткість: {Ships.Sum(s => s.Capacity)}");
            Console.WriteLine($"Загальна вантажність: {Ships.Sum(s => s.Load)}");
        }
        public void SortByFuel()
        {
            Ships = Ships.OrderBy(s => s.FuelPerHour).ToList();
            Console.WriteLine("Судна відсортовано за паливом/год: ");
            Ships.ForEach(s => Console.WriteLine(s));
        }
        public void FindByYearRange(int minYear, int maxYear)
        {
            var found = Ships.Where(s => s.YearBuilt >= minYear && s.YearBuilt <= maxYear);
            Console.WriteLine($"Судна з {minYear} до {maxYear}:");
            foreach (var ship in found)
                Console.WriteLine(ship);
        }
    }
    class Program
    {
        static void Main()
        {
            var year = new Year(2024, 3, 26);
            Console.WriteLine(year);
            year.PrintDayOfWeek();
            year.GetPeriodInfo(DateTime.Now);
            var carrier = new Carrier("УкрПорт");
            carrier.AddShip(new Ship("Корабель1", 1000, 500, 50.5, 2010));
            carrier.AddShip(new Ship("Корабель2", 800, 400, 30.2, 2015));
            carrier.AddShip(new Ship("Корабель3", 1200, 600, 40.0, 2005));
            carrier.TotalStats();
            carrier.SortByFuel();
            carrier.FindByYearRange(2008, 2016);
        }
    }
}
