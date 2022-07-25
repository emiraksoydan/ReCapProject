﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            this.rentalDal = rentalDal;
        }

        public IResult AddRental(Rental rentalcar)
        {

            ValidationTool.Validate(new RentalValidator(), rentalcar);
            rentalDal.Add(rentalcar);
            return new SuccessResult(true);




        }

        public IResult DeleteRental(Rental rentalcar)
        {
            rentalDal.Delete(rentalcar);
            return new SuccessResult(true);
        }

        public IDataResult<List<Rental>> GetAllRental()
        {
            return new SuccessDataResult<List<Rental>>(rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(rentalDal.GetRentalDetail());
        }

        public IResult UpdateRental(Rental rentalcar)
        {
            rentalDal.Update(rentalcar);
            return new SuccessResult(true);
        }
    }
}
