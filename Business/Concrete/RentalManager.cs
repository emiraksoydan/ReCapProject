using Business.Abstract;
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

        public IResult AddRental(Rental car)
        {
            
            if(car.ReturnDate == null)
            {
                return new ErrorResult(false);

            }
            rentalDal.Add(car);
            return new SuccessResult(true);




        }

        public IResult DeleteRental(Rental car)
        {
            rentalDal.Delete(car);
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

        public IResult UpdateRental(Rental car)
        {
            rentalDal.Update(car);
            return new SuccessResult(true);
        }
    }
}
