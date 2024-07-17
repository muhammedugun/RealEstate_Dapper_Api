using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly IGenericRepository<ResultBottomGridDto> _genericRepository;
        private readonly Context _context;

        public BottomGridRepository(IGenericRepository<ResultBottomGridDto> genericRepository, Context context)
        {
            _genericRepository = genericRepository;
            _context = context;
        }

        public Task CreateBottomGrid(CreateBottomGridDto bottomGridDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBottomGrid(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";
            return (await _genericRepository.GetAllAsync(query)).ToList();
        }

        public Task<GetBottomGridDto> GetBottomGrid(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
        {
            throw new NotImplementedException();
        }
    }
}
