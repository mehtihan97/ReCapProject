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

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfRepositoryBase<Car, RecapContext>, ICarDal
    {
        public List<CarDetails> GetCarsDetails()
        {
            using (RecapContext context=new RecapContext())
            {
                var resault = from c in context.Cars
                              join b in context.Brands
                              on c.BrandId equals b.id
                              join o in context.Colors
                              on c.ColorId equals o.id
                              select new CarDetails { ColorName =o.ColorName, BrandName = b.BrandName, DailyPrice = c.DailyPrice, Description = c.Description };
                return resault.ToList();
            }
        }
    }
}
