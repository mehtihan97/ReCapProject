using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidator;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal carImageDal;

        public CarImageManager(ICarImageDal carDal)
        {
            this.carImageDal = carDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result=BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result==null)
            {
                carImage.ImagePath = FileHelper.Add(file);
                carImage.ImageDate = DateTime.Now;
                carImageDal.Add(carImage);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IResult Delete(CarImage image)
        {
            FileHelper.Delete(image.ImagePath);
            carImageDal.Delete(image);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(carImageDal.Get(i=>i.Id==id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(carImageDal.GetAll());
        }
        [ValidationAspect(typeof(CarImageValidation))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(carImage.ImagePath, file);
            carImage.ImageDate = DateTime.Now;
            carImageDal.Update(carImage);
            return new SuccessResult();
        }
        private IResult CheckImageLimitExceeded(int id)
        {
            var result = carImageDal.GetAll(i => i.CarId == id).Count;
            if (result <= 5)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Message.CarImageLimmit);
            }
        }
    }
}
