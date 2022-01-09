using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
    where TEntity:class, IEntity,new()
    where TContext:DbContext,new ()
    {
        //using disposable patterndir yani nesnenin hayatını sonlandırmasını gc ' ye bırakmadan using blogu bittiğinde bellekten silinmesini sağlar.
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context=new TContext())
            {
                //verilen filtereye göre o data nın gelmesini sağlar
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context=new TContext())
            {
                //filtre null ise tüm listeyi getir. null değilse filtreye göre işlem yap ve listele.
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Add(TEntity entity)
        {
            using (var context=new TContext())
            {
                var addedEntity=context.Entry(entity); //gönderilen entitity eklenmeye çalışılan
                addedEntity.State = EntityState.Added; //yeni eklenecek
                context.SaveChanges(); //db ye ekler
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //gönderilen entitity güncellenmeye çalışılan
                updatedEntity.State = EntityState.Modified; //güncellenecej entity
                context.SaveChanges(); //db den günceller
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //gönderilen entitity silinmeye çalışılan
                deletedEntity.State = EntityState.Deleted; //silinecek entity
                context.SaveChanges(); //db den siler
            }
        }
    }
}
