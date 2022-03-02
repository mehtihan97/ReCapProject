using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car(){ Id = 1,BrandId=1,ColorId=1,ModelYear=2017,DailyPrice=10,Description="good"},
            new Car(){ Id = 2,BrandId=1,ColorId=1,ModelYear=2015,DailyPrice=6,Description="very nice"},
            new Car(){ Id = 3,BrandId=2,ColorId=1,ModelYear=2016,DailyPrice=5,Description="bad"}};
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deleteToCar;
            //foreach(var c in _cars)
            //{
            //    if (car.Id == c.Id)
            //    {
            //        deleteToCar = c;
            //    }
            //}

            //_cars.Remove(deleteToCar);
            deleteToCar = _cars.SingleOrDefault(c => c.Id == car.Id);           
            _cars.Remove(deleteToCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> getAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int getById(int id)
        {
            var resault= _cars.Find(c => c.ColorId ==id);
            return resault.Id;
        }

        public List<CarDetails> GetCarsDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUptudate=null;
            carToUptudate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUptudate.Description = car.Description;

        }
    }
}
