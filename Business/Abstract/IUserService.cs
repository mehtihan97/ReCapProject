using Core.IEntity.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
