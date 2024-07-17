using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IGenericRepository<ResultServiceDto> _genericRepository;
        private readonly Context _context;

        public ServiceRepository(IGenericRepository<ResultServiceDto> genericRepository, Context context)
        {
            _genericRepository = genericRepository;
            _context = context;
        }
        public Task CreateService(CreateServiceDto serviceDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteService(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * From Service";
            return (await _genericRepository.GetAllAsync(query)).ToList();
        }

        public Task<GetByIDServiceDto> GetService(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateService(UpdateServiceDto serviceDto)
        {
            throw new NotImplementedException();
        }
    }
}
