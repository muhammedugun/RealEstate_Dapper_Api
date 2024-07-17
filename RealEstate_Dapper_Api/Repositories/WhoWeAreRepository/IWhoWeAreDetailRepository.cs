using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;


namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreDetailRepository : IGenericRepository<ResultWhoWeAreDetailDto>
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
        Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDto WhoWeAreDetailDto);
        Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto WhoWeAreDetailDto);
        Task DeleteWhoWeAreDetail(int id);
        Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id);
    }
}
