using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        Task CreateService(CreateServiceDto serviceDto);
        Task UpdateService(UpdateServiceDto serviceDto);
        Task DeleteService(int id);
        Task<GetByIDServiceDto> GetService(int id);
    }
}
