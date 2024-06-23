﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataFactory.BaseFactory
{
    public class GenericFactoryEF<C, T> : IGenericFactoryEF<T> where T : class where C : DbContext, new()
    {
        private C Context = new C();
        private DbSet<T> _dbset;

        protected C _dbctx
        {
            get { return Context; }
            set { Context = value; }
        }

        public GenericFactoryEF()
        {
            _dbset = _dbctx.Set<T>();
        }

        #region ===========readonly=========

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetById(T entity)
        {
            return await _dbset.FindAsync(entity);
        }

        public async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
        }

        #endregion

        #region ======crud operations=======
        public virtual void InsertAsync(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void InsertListAsync(IEnumerable<T> entities)
        {
            _dbset.AddRange(entities);
        }

        public virtual void UpdateAsync(T entity)
        {
            _dbctx.Entry(entity).State = EntityState.Modified;
        }

        public virtual void DeleteAsync(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void DeleteListAsync(IEnumerable<T> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public virtual void DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> list = _dbset.Where(predicate);
            foreach (var entity in list)
            {
                _dbset.Remove(entity);
            }
        }

        public async Task SaveAsync()
        {
            await _dbctx.SaveChangesAsync();
        }

        #endregion

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
                if (disposing)
                    _dbctx.Dispose();
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
