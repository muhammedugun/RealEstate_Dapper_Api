using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string query);
        Task CreateAsync(string query, DynamicParameters parameters);
        Task UpdateAsync(string query, DynamicParameters parameters);
        Task DeleteAsync(string query, DynamicParameters parameters);
    }
}
