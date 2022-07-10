using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepositoryDal<TEntity>  where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext reCapContextDal = new TContext())
            {
                var Addcar = reCapContextDal.Entry(entity);
                Addcar.State = EntityState.Added;
                reCapContextDal.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext reCapContextDal = new TContext())
            {
                var Deletedcar = reCapContextDal.Entry(entity);
                Deletedcar.State = EntityState.Deleted;
                reCapContextDal.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext reCapContextDal = new TContext())
            {
                return reCapContextDal.Set<TEntity>().SingleOrDefault(filter);

            }
        }


        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext reCapContextDal = new TContext())
            {
                return filter == null ? reCapContextDal.Set<TEntity>().ToList() : reCapContextDal.Set<TEntity>().Where(filter).ToList();

            }
        }


        public void Update(TEntity entity)
        {
            using (TContext reCapContextDal = new TContext())
            {
                var Updatedcar = reCapContextDal.Entry(entity);
                Updatedcar.State = EntityState.Modified;
                reCapContextDal.SaveChanges();
            }
        }
    }
}
