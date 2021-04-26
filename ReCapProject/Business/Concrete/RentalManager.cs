using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            ValidationTool.Validate(new RentalValidator(), rental);

            _rentalDal.Add(rental);
            return new SuccessDataResult<Rental>(Messages.RentalAdded);
        }

        public IResult CheckAvailability(DateTime rentDate, int carId)
        {
            if (_rentalDal.CheckAvailability(rentDate, carId).Success)
            {
                return new SuccessDataResult<Rental>();
            }
            else
            {
                return new ErrorDataResult<Rental>();
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessDataResult<Rental>(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(u => u.RentalId == id));
        }

        public IDataResult<List<RentalDetailDto>> RentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return filter == null
                ? new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalDetails)
                : new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(filter), Messages.RentalDetails);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessDataResult<Rental>(Messages.RentalUpdated);
        }
    }
}
