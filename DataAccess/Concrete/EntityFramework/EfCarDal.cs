using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapContextDal reCapContextDal = new ReCapContextDal())
            {
               var Addcar =  reCapContextDal.Entry(entity);
               Addcar.State = EntityState.Added;
               reCapContextDal.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapContextDal reCapContextDal = new ReCapContextDal())
            {
                var Deletedcar = reCapContextDal.Entry(entity);
                Deletedcar.State = EntityState.Deleted;
                reCapContextDal.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContextDal reCapContextDal = new ReCapContextDal())
            {
                return reCapContextDal.Set<Car>().SingleOrDefault(filter);

            }
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContextDal reCapContextDal = new ReCapContextDal())
            {
                return filter == null ? reCapContextDal.Set<Car>().ToList() : reCapContextDal.Set<Car>().Where(filter).ToList();

            }
        }


        public void Update(Car entity)
        {
            using(ReCapContextDal reCapContextDal = new ReCapContextDal())
            {
                var Updatedcar = reCapContextDal.Entry(entity);
                Updatedcar.State = EntityState.Modified;
                reCapContextDal.SaveChanges();
            }
        }
    }
}
