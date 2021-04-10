using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car(){CarId = 1, BrandId =1, ColorId = 1, DailyPrice = 1500, Descriptions = "AUDI", ModelYear=2011 },
                new Car(){CarId = 2, BrandId =2, ColorId = 1, DailyPrice = 1700, Descriptions = "Ford", ModelYear=2012 },
                new Car(){CarId = 3, BrandId =1, ColorId = 2, DailyPrice = 1900, Descriptions = "AUDI", ModelYear=2013 },
                new Car(){CarId = 4, BrandId =4, ColorId = 3, DailyPrice = 3500, Descriptions = "BMW", ModelYear=2018 },
                new Car(){CarId = 5, BrandId =3, ColorId = 2, DailyPrice = 1050, Descriptions = "Volkswagen", ModelYear=2009 },
                new Car(){CarId = 6, BrandId =2, ColorId = 3, DailyPrice = 2700, Descriptions = "Ford", ModelYear=2015 },

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carID)
        {
            return (_cars.SingleOrDefault(c => c.CarId == carID));
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

 

        public List<CarDetailDto> GetCarDetailsByColorAndBrand(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
        }
    }
}
