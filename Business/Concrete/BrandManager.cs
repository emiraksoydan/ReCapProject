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
    public class BrandManager : IBrandService
    {
        IBrandDal _ibranddal;

        public BrandManager(IBrandDal ibranddal)
        {
            _ibranddal = ibranddal;
        }

        public void Add(Brand car)
        {
            _ibranddal.Add(car);
        }

        public void Delete(Brand car)
        {
            _ibranddal.Delete(car);
        }

        public List<Brand> GetAll()
        {
            return _ibranddal.GetAll();
        }

        public Brand GetBrandByBrandId(int id)
        {
            return _ibranddal.Get(b=>b.BrandId == id);
        }

        public void Update(Brand car)
        {
            _ibranddal.Update(car);
        }
    }
}
