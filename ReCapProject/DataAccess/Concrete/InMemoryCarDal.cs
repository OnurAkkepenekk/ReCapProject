using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car(){Id = 1, BrandId =1, ColorId = 1, DailyPrice = 1500, Description = "AUDI", ModelYear=2011 },
                new Car(){Id = 2, BrandId =2, ColorId = 1, DailyPrice = 1700, Description = "Ford", ModelYear=2012 },
                new Car(){Id = 3, BrandId =1, ColorId = 2, DailyPrice = 1900, Description = "AUDI", ModelYear=2013 },
                new Car(){Id = 4, BrandId =4, ColorId = 3, DailyPrice = 3500, Description = "BMW", ModelYear=2018 },
                new Car(){Id = 5, BrandId =3, ColorId = 2, DailyPrice = 1050, Description = "Volkswagen", ModelYear=2009 },
                new Car(){Id = 6, BrandId =2, ColorId = 3, DailyPrice = 2700, Description = "Ford", ModelYear=2015 },

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);

        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int carID)
        {
            return (_cars.SingleOrDefault(c => c.Id == carID));
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
