using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Repositories;
using Torcar.CORE.Service;
using Torcar.CORE.UnitOfWork;

namespace Torcar.SERVICE.Service
{
    
    public class GenericService<T> : IGenericService<T> where T : class
    {

        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unit;

        public GenericService(IGenericRepository<T> repository, IUnitOfWork unit)
        {
            _repository = repository;
            _unit = unit;
        }

        public async Task<T> AddAsync(T entity)
        {
           await _repository.AddAsync(entity);
            
           await _unit.CommitAsync();
           return entity;  
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unit.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
           return await _repository.AnyAsync(expression);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _repository.FirstOrDefault(expression);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll().AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
             _repository.Remove(entity);
            await _unit.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unit.CommitAsync();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> expression)
        {
            return _repository.SingleOrDefault(expression);
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return _repository.SingleOrDefaultAsync(expression);
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unit.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
           return _repository.Where(expression);
        }

    }
}
