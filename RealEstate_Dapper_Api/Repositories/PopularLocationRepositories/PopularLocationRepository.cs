using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
	public class PopularLocationRepository : IPopularLocationRepository
	{
		private readonly IGenericRepository<ResultPopularLocationDto> _genericRepository;
		private readonly Context _context;

		public PopularLocationRepository(IGenericRepository<ResultPopularLocationDto> genericRepository, Context context)
		{
			_genericRepository = genericRepository;
			_context = context;
		}

		public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
		{
			string query = "Select * From PopularLocation";
			return (await _genericRepository.GetAllAsync(query)).ToList();
		}
	}
}
