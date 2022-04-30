using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();

        void Update(T entity);

        void Attach(T entity);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);
        void AddRange(IEnumerable<T> entity);

        Task<int> CountAsync(ISpecification<T> spec);

        void Delete(T entity);
        void DeleteRange(List<T> entity);
        Task<T> GetFirstOrDefaultBySpecAsync(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListBySpecAsync(ISpecification<T> spec);
    }
}
