using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string query)
        {
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<T>(query);
                return values;
            }
        }

        public async Task CreateAsync(string query, DynamicParameters parameters)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateAsync(string query, DynamicParameters parameters)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteAsync(string query, DynamicParameters parameters)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
