using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AppContext = AspNetCore_Stack.Entities.AppContext;

namespace AspNetCore_Stack.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppContext _dbContext;
        private readonly DbSet<T> _dbSet;
 
        public Repository(AppContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<T>();
        }
 
        #region IRepository Members
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }
 
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
 
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
 
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }
 
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }
 
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
 
        public void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _dbContext.Entry(entity);
 
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
            
            _dbContext.SaveChanges();
        }
 
        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }

        #endregion
    }
}