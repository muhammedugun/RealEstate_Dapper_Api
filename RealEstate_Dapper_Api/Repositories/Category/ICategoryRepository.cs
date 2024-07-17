using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.Category
{
    public interface ICategoryRepository : IGenericRepository<ResultCategoryDto>
    {
        // Kategoriye özgü metodlar burada tanımlanabilir
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategory(CreateCategoryDto categoryDto);
        Task UpdateCategory(UpdateCategoryDto categoryDto);
        Task DeleteCategory(int id);
        Task<GetByIDCategoryDto> GetCategory(int id);
    }
}
