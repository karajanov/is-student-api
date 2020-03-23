using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityApp.Services.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);

        Task InsertAsync(T obj);

        Task UpdateAsync(T obj);

        Task DeleteAsync(object id);

        Task<bool> DeleteMultipleRecordsAsync<X>(IEnumerable<X> idList) where X : struct;

        Task SaveAsync();
    }
}
