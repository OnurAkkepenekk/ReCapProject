
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramewotk
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Descriptions,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
        public List<CarWithBrandAndColorDto> GetAllWithDetail(Expression<Func<CarWithBrandAndColorDto, bool>> filter = null)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {


                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarWithBrandAndColorDto
                             {
                                 Id = c.CarId,
                                 CarImages = (from i in context.CarImages where i.CarId == c.CarId select i).ToList(),
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Descriptions,
                                 BrandId = c.BrandId,
                                 BrandName = b.BrandName,
                                 ColorId = c.ColorId,
                                 ColorName = co.ColorName
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorAndBrand(int brandId, int colorId)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             where c.ColorId == colorId && c.BrandId == brandId

                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Descriptions,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {

                var result =
                  from car in context.Cars
                  join brand in context.Brands on car.BrandId equals brand.BrandId
                  join color in context.Colors on car.ColorId equals color.ColorId
                  join image in context.CarImages on car.CarId equals image.CarId
                  where car.CarId == carId
                  select new CarDetailDto
                  {
                      CarId = car.CarId,
                      BrandId = brand.BrandId,
                      ColorId = color.ColorId,
                      BrandName = brand.BrandName,
                      ColorName = color.ColorName,
                      ModelYear = car.ModelYear,
                      DailyPrice = car.DailyPrice,
                      Description = car.Descriptions,
                      ImageId = image.Id,
                      ImagePath = image.ImagePath,
                      Date = image.Date
                  };

                return result.ToList();
            }
        }
    }
}
