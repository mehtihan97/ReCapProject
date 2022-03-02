using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Car car1 = new Car();
            //car1.BrandId = 1;
            //car1.ColorId = 1;
            //car1.DailyPrice = 10;
            //car1.Description = "h";
            //car1.ModelYear = 10;
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(car1);
            var result = carManager.GetCarsDetails();
            //User user = new User();
            //user.FirstName = "a";
            //user.LastName = "b";
            //user.UserPassword = "c";
            //user.Email = "d";
            Rental rental = new Rental();
            rental.CustomerId= 2;
            rental.RentDate = DateTime.Now;
       
            
            
            
            RentalManager manager = new RentalManager(new EfRentalDal());
            Console.WriteLine(manager.Add(rental).Message);
    

            //foreach (var car in manager.GetAll().Data)
            //{
            //    Console.WriteLine(car.FirstName);
            //}
            //Console.WriteLine(result.Message);



        }
    }
}
