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

    
        public List<Car> getall()
        {
            return icardal.GetAll();
        }

     

       

       
    }
}
