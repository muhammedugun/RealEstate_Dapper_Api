using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IGenericRepository<ResultCategoryDto> _genericRepository;
        private readonly Context _context;

        public CategoryRepository(IGenericRepository<ResultCategoryDto> genericRepository, Context context)
        {
            _genericRepository = genericRepository;
            _context = context;
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            return (await _genericRepository.GetAllAsync(query)).ToList();
        }

        public async Task CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName, CategoryStatus) values (@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            await _genericRepository.CreateAsync(query, parameters);
        }

        public async Task DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            await _genericRepository.DeleteAsync(query, parameters);
        }

        public async Task UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
            parameters.Add("@categoryID", categoryDto.CategoryID);
            await _genericRepository.UpdateAsync(query, parameters);
        }

        // Implement the methods from IGenericRepository<ResultCategoryDto>
        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync(string query)
        {
            return await _genericRepository.GetAllAsync(query);
        }

        public async Task CreateAsync(string query, DynamicParameters parameters)
        {
            await _genericRepository.CreateAsync(query, parameters);
        }

        public async Task UpdateAsync(string query, DynamicParameters parameters)
        {
            await _genericRepository.UpdateAsync(query, parameters);
        }

        public async Task DeleteAsync(string query, DynamicParameters parameters)
        {
            await _genericRepository.DeleteAsync(query, parameters);
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category Where CategoryID=@CategoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, parameters);
                return values;
            }
        }
    }
}
