﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:IEntities
    {
        public int id { get; set; }
        public string BrandName { get; set; }
    }
}
