using RealEstate_Dapper_Api.Dtos;
using RealEstate_Dapper_Api.Dtos.GlobalDtos;

namespace RealEstate_Dapper_Api.Repositories
{
    public interface IGlobalRepository : IGenericRepository<ResultGlobalDto>
    {
        Task<List<ResultGlobalDto>> GetAllGlobalAsync();
        Task CreateGlobal(CreateGlobalDto globalDto);
        Task UpdateGlobal(UpdateGlobalDto globalDto);
        Task DeleteGlobal(int id);
    }
}
