using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PersonelDtos;
using RealEstate_Dapper_Api.Repositories;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelRepository _personelRepository;

        public PersonelController(IPersonelRepository personelRepository)
        {
            _personelRepository = personelRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ListPersonel()
        {
            var values = await _personelRepository.GetAllPersonelAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonel(CreatePersonelDto createPersonelDto)
        {
            await _personelRepository.CreatePersonel(createPersonelDto);
            return Ok("Personel başarılı bir şekilde eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonel(UpdatePersonelDto updatePersonelDto)
        {
            await _personelRepository.UpdatePersonel(updatePersonelDto);
            return Ok("Personel başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonel(int id)
        {
            await _personelRepository.DeletePersonel(id);
            return Ok("Personel başarıyla silindi");
        }
    }
}
