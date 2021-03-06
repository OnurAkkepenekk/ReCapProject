using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRule;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImage;

        public CarImageManager(ICarImageDal carImage)
        {
            _carImage = carImage;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageCount(carImage.CarId));
            if (result == null)
            {
                var fileUpload = FileHelper.Add(file);
                if (fileUpload.Success)
                {
                    carImage.ImagePath = fileUpload.Data;
                    _carImage.Add(carImage);
                }
                return new SuccessDataResult<CarImage>(Messages.CarImageAdded);
            }
            else
            {
                return result;
            }
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImage.Delete(carImage);
            return new SuccessResult("Silinme işlemi yapıldı");
        }
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImage.Get(p => p.Id == id));
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImage.GetAll(), Messages.ListCarImage);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImage.Get(c => c.CarId == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));
            if (result == null)
            {
                return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
            }
            else
            {
                return new ErrorDataResult<List<CarImage>>();
            }
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var fileUpload = FileHelper.Update(file, carImage.ImagePath);
            // Database güncellemesi
            if (fileUpload.Success)
            {
                carImage.ImagePath = fileUpload.Data;
                _carImage.Update(carImage);
                return new SuccessDataResult<CarImage>(Messages.CarImageAdded);
            }
            else
            {
                return new ErrorResult();
            }
        }

        private IResult CheckImageCount(int id)
        {
            int countOfImage = _carImage.GetAll(c => c.CarId == id).Count;
            if (countOfImage >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            string path = @"\wwwroot\Images\logo.jpg";
            var result = _carImage.GetAll(c => c.CarId == id);
            if (result.Count == 0)
            {
                List<CarImage> defaultCarImage = new List<CarImage>();
                defaultCarImage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                return new SuccessDataResult<List<CarImage>>(defaultCarImage);
            }
            else
            {
                return new SuccessDataResult<List<CarImage>>(_carImage.GetAll(p => p.CarId == id).ToList());
            }
        }
    }
}
