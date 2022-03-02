using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IEntity.Concrete
{
    public class OperationClaim:IEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
