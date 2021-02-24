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
            bool choice = true;

            while (choice)
            {
                Console.WriteLine("Add (1)");
                Console.WriteLine("Delete (2)");
                Console.WriteLine("Update (3)");
                Console.WriteLine("Exit (4)");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        EntityFrameworkAddTest();
                        break;

                    case "2":
                        EntityFrameworkDeleteTest();
                        break;

                    case "3":
                        EntityFrameworkUpdateTest();
                        break;

                    case "4":
                        choice = false;
                        break;

                    case "5":
                        CarDetails();
                        break;
                }
            }
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetailDtos().Data)
            {
                if (carManager.GetCarDetailDtos().Success == true)
                    Console.WriteLine(item.CarName + "--->" + item.BrandName + "--->" + item.ColorName + "--->" + item.DailyPrice);
            }
        }
        private static void EntityFrameworkAddTest()
        {
            /*CarManager carManager = new CarManager(new EfCarDal());
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
            carManager.Add(new Car { BrandId = 1, ColorId = 3, DailyPrice = 1500, Descriptions = "Benzinli Otomatik-new", ModelYear = 2021 });
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }*/

            /* ColorManager colorManager = new ColorManager(new EfColorDal());
             foreach (Color c in colorManager.GetAll())
             {
                 Console.WriteLine(c.ColorId + " " + c.ColorName);
             }
             colorManager.Add(new Color { ColorName = "Pink" });
             foreach (Color c in colorManager.GetAll())
             {
                 Console.WriteLine(c.ColorId + " " + c.ColorName);
             }*/

            /* BrandManager brandManager = new BrandManager(new EfBrandDal());
             foreach (Brand c in brandManager.GetAll())
             {
                 Console.WriteLine(c.BrandId + " " + c.BrandName);
             }
             brandManager.Add(new Brand { BrandName = "Onur" });
             foreach (Brand c in brandManager.GetAll())
             {
                 Console.WriteLine(c.BrandId + " " + c.BrandName);
             }*/

        }
        private static void EntityFrameworkDeleteTest()
        {
            /*CarManager carManager = new CarManager(new EfCarDal());
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
            carManager.Delete(new Car { CarId = 2 });
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
            
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (Color c in colorManager.GetAll().Data)
            {
                Console.WriteLine(c.ColorId + " " + c.ColorName);
            }
            colorManager.Delete(new Color { ColorId = 4 });
            foreach (Color c in colorManager.GetAll().Data)
            {
                Console.WriteLine(c.ColorId + " " + c.ColorName);
            }

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (Brand c in brandManager.GetAll())
            {
                Console.WriteLine(c.BrandId + " " + c.BrandName);
            }
            brandManager.Delete(new Brand { BrandId = 1 });
            foreach (Brand c in brandManager.GetAll())
            {
                Console.WriteLine(c.BrandId + " " + c.BrandName);
            }*/
        }
        private static void EntityFrameworkUpdateTest()
        {
            /*CarManager carManager = new CarManager(new EfCarDal());
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
            carManager.Update(new Car { CarId = 1003, BrandId = 1, ColorId = 1, ModelYear = 1, Descriptions = "Deneme", DailyPrice = 1222 });
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }*/
        }
    }
}
