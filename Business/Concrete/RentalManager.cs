using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal rentaDal;
        public RentalManager(IRentalDal rentaDal)
        {
            this.rentaDal = rentaDal;
        }
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                rentaDal.Add(rental);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Message.NoCar);
            }
        }
    }
}
