using Dapper;
using RealEstate_Dapper_Api.Dtos.PersonelDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories
{
    public class PersonelRepository : IPersonelRepository
    {
        private readonly IGenericRepository<ResultPersonelDto> _genericRepository;
        private readonly Context _context;

        public PersonelRepository(IGenericRepository<ResultPersonelDto> genericRepository, Context context)
        {
            _genericRepository = genericRepository;
            _context = context;
        }

        public async Task<List<ResultPersonelDto>> GetAllPersonelAsync()
        {
            string query = "SELECT * FROM TbPersonel";
            return (await _genericRepository.GetAllAsync(query)).ToList();
        }

        public async Task CreatePersonel(CreatePersonelDto personelDto)
        {
            string query = "INSERT INTO TbPersonel (KullaniciAdi, Sifre, PersonelAdi, BirimID, KurumID, UnvanID, SonGirisTarihi, BoAdmin, BoAktif, BoKontrolMuhendisiMi) " +
                           "VALUES (@kullaniciAdi, @sifre, @personelAdi, @birimID, @kurumID, @unvanID, @sonGirisTarihi, @boAdmin, @boAktif, @boKontrolMuhendisiMi)";
            var parameters = new DynamicParameters();
            parameters.Add("@kullaniciAdi", personelDto.KullaniciAdi);
            parameters.Add("@sifre", personelDto.Sifre);
            parameters.Add("@personelAdi", personelDto.PersonelAdi);
            parameters.Add("@birimID", personelDto.BirimID);
            parameters.Add("@kurumID", personelDto.KurumID);
            parameters.Add("@unvanID", personelDto.UnvanID);
            parameters.Add("@sonGirisTarihi", personelDto.SonGirisTarihi);
            parameters.Add("@boAdmin", personelDto.BoAdmin);
            parameters.Add("@boAktif", personelDto.BoAktif);
            parameters.Add("@boKontrolMuhendisiMi", personelDto.BoKontrolMuhendisiMi);
            await _genericRepository.CreateAsync(query, parameters);
        }

        public async Task UpdatePersonel(UpdatePersonelDto personelDto)
        {
            string query = "UPDATE TbPersonel SET KullaniciAdi=@kullaniciAdi, Sifre=@sifre, PersonelAdi=@personelAdi, BirimID=@birimID, " +
                           "KurumID=@kurumID, UnvanID=@unvanID, SonGirisTarihi=@sonGirisTarihi, BoAdmin=@boAdmin, BoAktif=@boAktif, BoKontrolMuhendisiMi=@boKontrolMuhendisiMi " +
                           "WHERE PersonelID=@personelID";
            var parameters = new DynamicParameters();
            parameters.Add("@personelID", personelDto.PersonelID);
            parameters.Add("@kullaniciAdi", personelDto.KullaniciAdi);
            parameters.Add("@sifre", personelDto.Sifre);
            parameters.Add("@personelAdi", personelDto.PersonelAdi);
            parameters.Add("@birimID", personelDto.BirimID);
            parameters.Add("@kurumID", personelDto.KurumID);
            parameters.Add("@unvanID", personelDto.UnvanID);
            parameters.Add("@sonGirisTarihi", personelDto.SonGirisTarihi);
            parameters.Add("@boAdmin", personelDto.BoAdmin);
            parameters.Add("@boAktif", personelDto.BoAktif);
            parameters.Add("@boKontrolMuhendisiMi", personelDto.BoKontrolMuhendisiMi);
            await _genericRepository.UpdateAsync(query, parameters);
        }

        public async Task DeletePersonel(int id)
        {
            string query = "DELETE FROM TbPersonel WHERE PersonelID=@personelID";
            var parameters = new DynamicParameters();
            parameters.Add("@personelID", id);
            await _genericRepository.DeleteAsync(query, parameters);
        }

        // Implementing the methods from IGenericRepository
        public async Task<IEnumerable<ResultPersonelDto>> GetAllAsync(string query)
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
