using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramewotk;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //EntityFrameworkAddTest()
            //EntityFrameworkDeleteTest();
            EntityFrameworkUpdateTest();
        }

        private static void EntityFrameworkAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
            carManager.Add(new Car { BrandId = 1, ColorId = 3, DailyPrice = 1500, Descriptions = "Benzinli Otomatik-new", ModelYear = 2021 });
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
        }

        private static void EntityFrameworkDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
            carManager.Delete(new Car { CarId = 1002 });
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
        }
        private static void EntityFrameworkUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
            carManager.Update(new Car { CarId = 1003, BrandId = 1, ColorId = 1, ModelYear = 1, Descriptions = "Deneme", DailyPrice = 1222 });
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
        }
    }
}
