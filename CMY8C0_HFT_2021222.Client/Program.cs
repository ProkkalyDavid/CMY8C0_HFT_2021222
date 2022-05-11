using System;
using System.Collections.Generic;
using System.Linq;
using CMY8C0_HFT_2021222.Logic;
using CMY8C0_HFT_2021222.Models;
using ConsoleTools;

namespace CMY8C0_HFT_2021222.Client
{
    public class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            string name = null;
            if (entity == "Car")
            {
                Console.Write("Enter car name: ");
                name = Console.ReadLine();
                rest.Post(new Car() { Name = name },"Car");
            }
            else if (entity == "Brand")
            {
                Console.Write("Enter brand name: ");
                name = Console.ReadLine();
                rest.Post(new Brand() { Name = name }, "Brand");
            }
            else
            {
                Console.Write("Enter engine name: ");
                name = Console.ReadLine();
                rest.Post(new Engine() { Name = name }, "Engine");
            }
        }
        static void List(string entity)
        {
            if (entity == "Car")
            {
                List<Car> cars = rest.Get<Car>("Car");
                foreach (var item in cars)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            else if (entity == "Brand")
            {
                List<Brand> brands = rest.Get<Brand>("Brand");
                foreach (var item in brands)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            else
            {
                List<Engine> engines = rest.Get<Engine>("Engine");
                foreach (var item in engines)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Car")
            {
                Console.Write("Enter car's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Car one = rest.Get<Car>(id, "Car");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "Car");
            }
            else if (entity == "Brand")
            {
                Console.Write("Enter brand's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Brand one = rest.Get<Brand>(id, "Brand");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "Brand");
            }
            else
            {
                Console.Write("Enter engine's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Engine one = rest.Get<Engine>(id, "Engine");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "Engine");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Car")
            {
                Console.Write("Enter car's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Car");
            }
            else if (entity == "Brand")
            {
                Console.Write("Enter brand's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Brand");
            }
            else
            {
                Console.Write("Enter engine's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Engine");
            }
        }
        static void OldestCar()
        {
            Console.Write("Oldest car in the database: ");
            var oldest = rest.Get<Oldest>("stat/OldesCar");
            Console.WriteLine(oldest[0].CarName);
            Console.ReadLine();
        }
        static void CarsWithV8()
        {
            Console.WriteLine("Cars with a V8 engine: ");
            var v8s = rest.Get<Car>("stat/CarsWithV8");
            foreach (var item in v8s)
            {
                Console.WriteLine(item.Name + "(Engine: "+ item.engine.Name +")");
            }
            Console.ReadLine();
        }
        static void HighestMileage()
        {
            Console.Write("Highest mileage car: ");
            var highestMileage = rest.Get<HighestMileage>("stat/HighestMileage");
            Console.WriteLine(highestMileage[0].CarName);
            Console.ReadLine();
        }
        static void GermanPremium()
        {
            Console.WriteLine("German premium vehicles (Audi,BMW,Mercedes):");
            var premiums = rest.Get<Car>("stat/GermanPremium");
            foreach (var item in premiums)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:43002/", "Car");
            var carSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Car"))
                .Add("Create", () => Create("Car"))
                .Add("Delete", () => Delete("Car"))
                .Add("Update", () => Update("Car"))
                .Add("Oldest car", () => OldestCar())
                .Add("V8 cars", () => CarsWithV8())
                .Add("Highest milleage", () => HighestMileage())
                .Add("German premium", () => GermanPremium())
                .Add("Exit", ConsoleMenu.Close);
            var brandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Brand"))
                .Add("Create", () => Create("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Exit", ConsoleMenu.Close);
            var engineSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Engine"))
                .Add("Create", () => Create("Engine"))
                .Add("Delete", () => Delete("Engine"))
                .Add("Update", () => Update("Engine"))
                .Add("Exit", ConsoleMenu.Close);
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Cars", () => carSubMenu.Show())
                .Add("Brands", () => brandSubMenu.Show())
                .Add("Engines", () => engineSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
    }
}
