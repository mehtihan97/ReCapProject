using Business.Abstract;
using Core.IEntity.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal userDal;
        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }
        public IResult Add(User user)
        {
            userDal.Add(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(userDal.GetAll());
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return userDal.GetClaims(user);
        }


        public User GetByMail(string email)
        {
            return userDal.Get(u => u.Email == email);
        }
    }
}

