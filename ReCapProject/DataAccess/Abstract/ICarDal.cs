using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailsByColorAndBrand(int brandId, int colorId);
        List<CarDetailDto>GetCarDetailsByCarId(int carId);
        List<CarWithBrandAndColorDto> GetAllWithDetail(Expression<Func<CarWithBrandAndColorDto, bool>> filter = null);
    }
}
