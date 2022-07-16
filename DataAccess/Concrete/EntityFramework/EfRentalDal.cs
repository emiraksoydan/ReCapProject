using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContextDal>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (ReCapContextDal reCapContextDal =  new ReCapContextDal())
            {
                var result = from re in reCapContextDal.Rentals
                             join c in reCapContextDal.Cars on re.CarId equals c.Id
                             join cu in reCapContextDal.Customers on re.CustomerId equals cu.Id
                             join u in reCapContextDal.Users on cu.UserId equals u.Id
                             join br in reCapContextDal.Brands on c.BrandId equals br.BrandId
                             join co in reCapContextDal.Colors on c.ColorId equals co.ColorId
                             select new RentalDetailDto { BrandName = br.BrandName, ColorName = co.ColorName, CompanyName = cu.CompanyName, DailyPrice = c.DailyPrice, Description = c.Description, Email = u.Email, FirstName = u.FirstName, LastName = u.LastName, ModelYear = c.ModelYear, RentalId = re.Id, RentDate = re.RentDate, ReturnDate = re.ReturnDate };
                return result.ToList();
            }
        }
    }
}
