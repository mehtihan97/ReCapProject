using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidator
{
    public class CarImageValidation:AbstractValidator<CarImage>
    {
        public CarImageValidation()
        {
            RuleFor(i => i.CarId).NotEmpty();
        }
    }
}
