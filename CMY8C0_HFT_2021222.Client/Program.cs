using System;
using System.Collections.Generic;
using System.Linq;
using CMY8C0_HFT_2021222.Models;
using ConsoleTools;

namespace CMY8C0_HFT_2021222.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Car")
            {
                Console.Write("Enter car name: ");
                string name = Console.ReadLine();
                rest.Post(new Car() { Name = name },"car");
            }

        }
        static void List(String entity)
        {
            if (entity == "Car")
            {
                List<Car> cars = rest.Get<Car>("car");
                foreach (var item in cars)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.Write("Enter car's id to update: ");
            int id = int.Parse(Console.ReadLine());
            Car one = rest.Get<Car>(id, "car");
            Console.Write($"New name [old: {one.Name}]: ");
            string name = Console.ReadLine();
            one.Name = name;
            rest.Put(one, "car");
        }
        static void Delete(string entity)
        {
            if (entity == "Car")
            {
                Console.Write("Enter car's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "car");
            }
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:3764/","car");
        }
    }
}
