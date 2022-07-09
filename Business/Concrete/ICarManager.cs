using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ICarManager : ICarService 
    {
        ICarDal icardal;
        public ICarManager(ICarDal icardal)
        {
            this.icardal = icardal;
        }

        public void Add(Car car)
        {
            if((car.Description).Length >= 2 && car.DailyPrice > 0)
            {
                icardal.Add(car);
            }
        }

        public List<Car> GetAll()
        {
            return icardal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int Brandid)
        {
            return icardal.GetAll(p=>p.BrandId == Brandid);
        }

        public List<Car> GetCarsByColorId(int Colorid)
        {
            return icardal.GetAll(p => p.ColorId == Colorid);
        }
    }
}
