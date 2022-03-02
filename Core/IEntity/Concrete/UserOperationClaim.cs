using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IEntity.Concrete
{
    public class UserOperationClaim:IEntities
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
