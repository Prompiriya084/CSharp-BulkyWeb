using BulkyWeb.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly DbSet<TEntity> _dbSet;
        public GenericRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null, bool tracked = false)
        {
            try
            {
                IQueryable<TEntity> query;

                if (tracked)
                {
                    query = _dbSet;
                }
                else
                {
                    query = _dbSet.AsNoTracking();
                }

                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }
                return query.ToList();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception($"Inner exception : {ex.InnerException.Message}");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter, string? inclueProperties = null, bool tracked = false)
        {
            try
            {
                IQueryable<TEntity> query;
                if (tracked)
                {
                    query = _dbSet;
                }
                else
                {
                    query = _dbSet.AsNoTracking();
                }

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (!string.IsNullOrEmpty(inclueProperties))
                {
                    foreach (var includeProp in inclueProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception($"Inner exception : {ex.InnerException.Message}");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public virtual void Add(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Empty");
                }
                _dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception($"Inner exception : {ex.InnerException.Message}");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public virtual void AddRange(IEnumerable<TEntity> entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Empty");
                }
                _dbSet.AddRange(entity);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception($"Inner exception : {ex.InnerException.Message}");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public virtual void Update(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Empty");
                }
                _dbSet.Update(entity);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception($"Inner exception : {ex.InnerException.Message}");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public virtual void UpdateRange(IEnumerable<TEntity> entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Empty");
                }
                _dbSet.UpdateRange(entity);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception($"Inner exception : {ex.InnerException.Message}");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public virtual void Delete(TEntity entity)
        {
            try
            {
                if (_dbSet.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception($"Inner exception : {ex.InnerException.Message}");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public virtual void DeleteRange(IEnumerable<TEntity> entity)
        {
            try
            {
                if (_dbSet.Entry(entity.FirstOrDefault()).State == EntityState.Detached)
                {
                    _dbSet.AttachRange(entity);
                }
                _dbSet.RemoveRange(entity);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception($"Inner exception : {ex.InnerException.Message}");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
