using Application.Interfaces.Repository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class GenericRepositoryImp<T> : IGenericRepository<T> where T : class
    {
        private readonly SavDbContext _savDbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepositoryImp(SavDbContext savDbContext) 
        {
            _savDbContext = savDbContext;
            _dbSet = _savDbContext.Set<T>();

        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _savDbContext.SaveChangesAsync();
            return entity;            
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _savDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            var entities = await _dbSet.Where(where).ToListAsync();
            _dbSet.RemoveRange(entities);
            await _savDbContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await _dbSet.FirstOrDefaultAsync(where);
        }

        public async Task<T> GetByIdAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where = null)
        {
            return where != null
                  ? await _dbSet.Where(where).ToListAsync()
                  : await _dbSet.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _savDbContext.Entry(entity).State= EntityState.Modified;
            await _savDbContext.SaveChangesAsync();
        }
    }
}
