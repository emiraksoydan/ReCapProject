using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAllRental();
        IResult AddRental(Rental car);
        IResult DeleteRental(Rental car);
        IResult UpdateRental(Rental car);
    

        IDataResult<List<RentalDetailDto>> GetRentalDetail();
    }
}
