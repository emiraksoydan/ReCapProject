using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars;

        public InMemoryCarDal()
        {
            cars =new List<Car> { new Car { Id = 1,BrandId = 2,ColorId = 10,DailyPrice = 20,Description = "asdsada",ModelYear = 2022}, new Car { Id = 2, BrandId = 3, ColorId = 5, DailyPrice = 10, Description = "togg", ModelYear = 2022 } };
        }

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car result = cars.SingleOrDefault(p => p.Id == car.Id);
            cars.Remove(result);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return cars;
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carss = cars.SingleOrDefault(p => p.Id == car.Id);
            carss.DailyPrice = car.DailyPrice;
            carss.ModelYear = car.ModelYear;
            carss.BrandId = car.BrandId;
            carss.ColorId = car.ColorId;
        }
    }
}
