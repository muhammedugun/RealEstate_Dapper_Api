using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.GlobalDtos;
using RealEstate_Dapper_Api.Dtos;
using RealEstate_Dapper_Api.Repositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjeKonulari : ControllerBase
    {
        private readonly IGlobalRepository _globalRepository;

        public ProjeKonulari(IGlobalRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ListGlobal()
        {
            var values = await _globalRepository.GetAllGlobalAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGlobal(CreateGlobalDto createGlobalDto)
        {
            await _globalRepository.CreateGlobal(createGlobalDto);
            return Ok("Personel başarılı bir şekilde eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGlobal(UpdateGlobalDto updateGlobalDto)
        {
            await _globalRepository.UpdateGlobal(updateGlobalDto);
            return Ok("Personel başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGlobal(int id)
        {
            await _globalRepository.DeleteGlobal(id);
            return Ok("Personel başarıyla silindi");
        }
    }
}
