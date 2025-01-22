﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{


    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task CommitAsync();
        Task DeleteAsync(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> where);
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<T> GetByIdAsync(params object[] keyValues);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where = null);
        Task UpdateAsync(T entity);
    }

}