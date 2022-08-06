using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContextDal>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails()
        {
            using (ReCapContextDal reCapContextDal = new ReCapContextDal())
            {
                var result = from c in reCapContextDal.Cars
                             join b in reCapContextDal.Brands
                             on c.BrandId equals b.BrandId
                             join col in reCapContextDal.Colors
                             on c.ColorId equals col.ColorId
                             select new CarDetailDto { BrandName = b.BrandName, CarId = c.Id, DailyPrice = c.DailyPrice, ColorName = col.ColorName };
                return result.ToList();
            }
            
        }
    }
}
