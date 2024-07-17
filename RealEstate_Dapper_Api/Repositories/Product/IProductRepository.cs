using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.Product
{
    public interface IProductRepository : IGenericRepository<ResultProductDto>
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task CreateProduct(CreateProductDto productDto);
        Task UpdateProduct(UpdateProductDto productDto);
        Task DeleteProduct(int id);
    }
}
