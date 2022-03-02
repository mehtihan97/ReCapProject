using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class CarManager : ICarService
    {
        ICarDal carDal;
        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.add,admin")]
        public IResult Add(Car car)
        {

            //var context = new ValidationContext<Car>(car);
            //CarValidator carValidation = new CarValidator();
            //var result=carValidation.Validate(context);
            //if(!result.IsValid)
            //{
            //   throw new ValidationException(result.Errors);
            //}
            //ValidationTool.Validate(new CarValidator(), car);
            carDal.Add(car);
           return new SuccessResult();
           
        }

        public IResult Delete(Car car)
        {
            carDal.Delete(car);
            return new SuccessResult();
        }
        public IDataResult<List<Car>> getAll()
        {
            return new SuccessDataResult < List < Car >> (carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult < List < Car >> (carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetails>> GetCarsDetails()
        {
            
            return new SuccessDataResult<List<CarDetails>>(carDal.GetCarsDetails(),Message.CarAdded);
        }

        public IResult Update(Car car)
        {
            carDal.Update(car);
            return new SuccessResult();
        }
    }
}
