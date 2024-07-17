using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        Task CreateBottomGrid(CreateBottomGridDto bottomGridDto);
        Task UpdateBottomGrid(UpdateBottomGridDto bottomGridDto);
        Task DeleteBottomGrid(int id);
        Task<GetBottomGridDto> GetBottomGrid(int id);
    }
}
