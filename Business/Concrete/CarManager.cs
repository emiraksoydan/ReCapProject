using Business.Abstract;
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
    public class CarManager : ICarService 
    {
        ICarDal icardal;
        public CarManager(ICarDal icardal)
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
        public void Delete(Car car)
        {
            
                icardal.Delete(car);   
            
        }
        public void Update(Car car)
        {

            icardal.Update(car);

        }

        public List<Car> GetAll()
        {
            return icardal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int Brandid)
        {
            return icardal.GetAll(p=>p.BrandId == Brandid).OrderByDescending(p=>p.Description).ToList();
        }

        public List<Car> GetCarsByColorId(int Colorid)
        {
            return icardal.GetAll(p => p.ColorId == Colorid);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return icardal.GetAllCarDetails();
        }
    }
}
