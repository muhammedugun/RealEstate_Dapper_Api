using RealEstate_Dapper_Api.Dtos.PersonelDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories
{
    public interface IPersonelRepository : IGenericRepository<ResultPersonelDto>
    {
        Task<List<ResultPersonelDto>> GetAllPersonelAsync();
        Task CreatePersonel(CreatePersonelDto personelDto);
        Task UpdatePersonel(UpdatePersonelDto personelDto);
        Task DeletePersonel(int id);
    }
}
