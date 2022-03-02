using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            this.customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            customerDal.Add(customer);
            return new SuccessResult();
        }
    }
}
