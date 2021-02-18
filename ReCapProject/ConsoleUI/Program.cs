using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (Car c in carManager.GetCars())
            {
                Console.WriteLine(c.Description);
            }
        }
    }
}
