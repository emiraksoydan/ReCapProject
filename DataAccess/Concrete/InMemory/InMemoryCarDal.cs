using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetById(int id)
        {
            return cars.Where(p => p.Id == id).ToList();
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
