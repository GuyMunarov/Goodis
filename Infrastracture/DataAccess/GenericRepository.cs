using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly DataContext context;

        public GenericRepository(DataContext context)
        {
            this.context = context;
        }



        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public void Attach(T entity)
        {
            context.Set<T>().Attach(entity);
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }



        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void DeleteRange(List<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }


        public async Task<T> GetFirstOrDefaultBySpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListBySpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), spec);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
             await context.Set<T>().AddRangeAsync(entities);
            return;
        }

        public void AddRange(IEnumerable<T> entities)
        {
             context.Set<T>().AddRange(entities);
            return;
        }
    }
}
