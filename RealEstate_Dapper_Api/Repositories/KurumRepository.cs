using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.TbKurumDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories
{
    public class KurumRepository : IKurumRepository
    {
        private readonly IGenericRepository<ResultKurumDto> _genericRepository;
        private readonly Context _context;

        public KurumRepository(IGenericRepository<ResultKurumDto> genericRepository, Context context)
        {
            _genericRepository = genericRepository;
            _context = context;
        }

        public async Task<List<ResultKurumDto>> GetAllKurumAsync()
        {
            string query = "Select * From TbKurum";
            // using bloğu tamamlandığında, connection nesnesinin Dispose metodu otomatik olarak çağrılır.
            // Bu, bağlantının doğru bir şekilde kapatılmasını ve ilgili kaynakların serbest bırakılmasını sağlar.
            return (await _genericRepository.GetAllAsync(query)).ToList();
        }

        public async Task CreateKurum(CreateKurumDto kurumDto)
        {
            string query = "insert into TbKurum (KurumID, KurumAdi) values (@kurumID,@kurumAdi)";
            var parameters = new DynamicParameters();
            parameters.Add("@kurumID", kurumDto.KurumID);
            parameters.Add("@kurumAdi", kurumDto.KurumAdi);
            await _genericRepository.CreateAsync(query, parameters);
        }

        public async Task DeleteKurum(int id)
        {
            string query = "Delete From TbKurum Where KurumID=@kurumID";
            var parameters = new DynamicParameters();
            parameters.Add("@kurumID", id);
            await _genericRepository.DeleteAsync(query, parameters);
        }

       

        public async Task UpdateKurum(UpdateKurumDto kurumDto)
        {
            string query = "Update TbKurum Set KurumAdi=@kurumAdi where KurumID=@kurumID";
            var parameters = new DynamicParameters();
            parameters.Add("@kurumAdi", kurumDto.KurumAdi);
            parameters.Add("@kurumID", kurumDto.KurumID);
            await _genericRepository.UpdateAsync(query, parameters);

        }

        // Implement the methods from IGenericRepository<ResultCategoryDto>
        public async Task<IEnumerable<ResultKurumDto>> GetAllAsync(string query)
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
