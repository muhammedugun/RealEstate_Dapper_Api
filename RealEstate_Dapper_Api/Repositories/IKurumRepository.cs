using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.TbKurumDtos;

namespace RealEstate_Dapper_Api.Repositories
{
    public interface IKurumRepository : IGenericRepository<ResultKurumDto>
    {
        Task<List<ResultKurumDto>> GetAllKurumAsync();
        Task CreateKurum(CreateKurumDto kurumDto);
        Task DeleteKurum(int id);
        Task UpdateKurum(UpdateKurumDto kurumDto);
    }
}
