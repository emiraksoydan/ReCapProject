﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p=>p.BrandId).NotEmpty();
            RuleFor(p=>p.ColorId).NotEmpty();
            RuleFor(p => p.ModelYear).GreaterThan(2015);
            RuleFor(p => p.Description).Must(StartWithT).WithMessage("Car Name start with T");
        }

        private bool StartWithT(string arg)
        {
            return arg.StartsWith("T");
        }
    }
}
