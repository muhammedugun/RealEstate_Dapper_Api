using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly IGenericRepository<ResultWhoWeAreDetailDto> _genericRepository;
        private readonly Context _context;

        public WhoWeAreDetailRepository(IGenericRepository<ResultWhoWeAreDetailDto> genericRepository, Context context)
        {
            _genericRepository = genericRepository;
            _context = context;
        }

        public Task CreateAsync(string query, DynamicParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDto whoWeAreDetailDto)
        {
            string query = "insert into WhoWeAreDetail (Title,Subtitle,Description1,Description2) values (@title,@subTitle,@description1,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", whoWeAreDetailDto.Title);
            parameters.Add("@subTitle", whoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", whoWeAreDetailDto.Description1);
            parameters.Add("@description2", whoWeAreDetailDto.Description2);
            await _genericRepository.CreateAsync(query, parameters);
        }

        public Task DeleteAsync(string query, DynamicParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete From WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            await _genericRepository.DeleteAsync(query, parameters);
        }

        public Task<IEnumerable<ResultWhoWeAreDetailDto>> GetAllAsync(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            return (await _genericRepository.GetAllAsync(query)).ToList();
        }

        public async Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            string query = "Select * From WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetail", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDto>(query, parameters);
                return values;
            }
        }

        public Task UpdateAsync(string query, DynamicParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto WhoWeAreDetailDto)
        {
            string query = "Update WhoWeAreDetail Set Title=@title,Subtitle=@subtitle,Description1=@description1,Description2=@description2 where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@title", WhoWeAreDetailDto.Title);
            parameters.Add("@subtitle", WhoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", WhoWeAreDetailDto.Description1);
            parameters.Add("@description2", WhoWeAreDetailDto.Description2);
            parameters.Add("@whoWeAreDetailID", WhoWeAreDetailDto.WhoWeAreDetailID);
            await _genericRepository.UpdateAsync(query, parameters);
        }
    }
}
