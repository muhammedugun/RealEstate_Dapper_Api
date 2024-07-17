using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGenericRepository<ResultProductDto> _genericRepository;
        private readonly Context _context;

        public ProductRepository(IGenericRepository<ResultProductDto> genericRepository, Context context)
        {
            _genericRepository = genericRepository;
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            return (await _genericRepository.GetAllAsync(query)).ToList();
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task CreateProduct(CreateProductDto productDto)
        {
            string query = "insert into Product (Title, Price, City, District) values (@title,@price,@city,@district)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", productDto.Title);
            parameters.Add("@price", productDto.Price);
            parameters.Add("@city", productDto.City);
            parameters.Add("@district", productDto.District);
            await _genericRepository.CreateAsync(query, parameters);
        }

        public async Task DeleteProduct(int id)
        {
            string query = "Delete From Product Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            await _genericRepository.DeleteAsync(query, parameters);
        }

        public async Task UpdateProduct(UpdateProductDto productDto)
        {
            string query = "Update Product Set Title=@title,Price=@price,City=@city,District=@district where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@title", productDto.Title);
            parameters.Add("@price", productDto.Price);
            parameters.Add("@city", productDto.City);
            parameters.Add("@district", productDto.District);
            await _genericRepository.UpdateAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultProductDto>> GetAllAsync(string query)
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


    }
}
