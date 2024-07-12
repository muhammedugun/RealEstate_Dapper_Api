using Dapper;
using RealEstate_Dapper_Api.Dtos;
using RealEstate_Dapper_Api.Dtos.GlobalDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories
{
    public class GlobalRepository : IGlobalRepository
    {
        private readonly IGenericRepository<ResultGlobalDto> _genericRepository;
        private readonly Context _context;

        public GlobalRepository(IGenericRepository<ResultGlobalDto> genericRepository, Context context)
        {
            _genericRepository = genericRepository;
            _context = context;
        }

        public async Task<List<ResultGlobalDto>> GetAllGlobalAsync()
        {
            string query = "SELECT * FROM TbGlobal";
            return (await _genericRepository.GetAllAsync(query)).ToList();
        }

        public async Task CreateGlobal(CreateGlobalDto globalDto)
        {
            string query = "INSERT INTO TbGlobal (GlobalID, GlobalAdi, GlobalTip, Aciklama, KurumID) " +
                           "VALUES (@globalID, @globalAdi, @globalTip, @aciklama, @kurumID)";
            var parameters = new DynamicParameters();
            parameters.Add("@globalID", globalDto.GlobalID);
            parameters.Add("@globalAdi", globalDto.GlobalAdi);
            parameters.Add("@globalTip", globalDto.GlobalTip);
            parameters.Add("@aciklama", globalDto.Aciklama);
            parameters.Add("@kurumID", globalDto.KurumID);
            await _genericRepository.CreateAsync(query, parameters);
        }

        public async Task UpdateGlobal(UpdateGlobalDto globalDto)
        {
            string query = "UPDATE TbGlobal SET GlobalID=@globalID, GlobalAdi=@globalAdi, GlobalTip=@globalTip, Aciklama=@aciklama, " +
                           "KurumID=@kurumID" +
                           "WHERE GlobalID=@globalID";
            var parameters = new DynamicParameters();
            parameters.Add("@globalID", globalDto.GlobalID);
            parameters.Add("@globalAdi", globalDto.GlobalAdi);
            parameters.Add("@globalTip", globalDto.GlobalTip);
            parameters.Add("@aciklama", globalDto.Aciklama);
            parameters.Add("@kurumID", globalDto.KurumID);
            await _genericRepository.UpdateAsync(query, parameters);
        }

        public async Task DeleteGlobal(int id)
        {
            string query = "DELETE FROM TbGlobal WHERE GlobalID=@globalID";
            var parameters = new DynamicParameters();
            parameters.Add("@globalID", id);
            await _genericRepository.DeleteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultGlobalDto>> GetAllAsync(string query)
        {
            return await _genericRepository.GetAllAsync(query);
        }

        public async Task CreateAsync(string query, DynamicParameters parameters)
        {
            await _genericRepository.CreateAsync(query, parameters);
        }

        public async Task UpdateAsync(string query, DynamicParameters parameters)
        {
            await _genericRepository.UpdateAsync(query, parameters);
        }

        public async Task DeleteAsync(string query, DynamicParameters parameters)
        {
            await _genericRepository.DeleteAsync(query, parameters);
        }
    }
}
