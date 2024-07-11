using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.TbKurumDtos;
using RealEstate_Dapper_Api.Repositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KurumController : ControllerBase
    {
        private readonly IKurumRepository _kurumRepository;

        public KurumController(IKurumRepository kurumRepository)
        {
            _kurumRepository = kurumRepository;
        }



        [HttpGet] //Bu attribute, bu metodun yalnızca HTTP GET istekleriyle çağrılabileceğini belirtir
        public async Task<IActionResult> ListKurum()
        {
            var values = await _kurumRepository.GetAllKurumAsync();
            return Ok(values); //  HTTP 200 OK yanıtı ile alınan kategorileri return eder
        }

        [HttpPost]
        public async Task<IActionResult> CreateKurum(CreateKurumDto createKurumDto)
        {
            _kurumRepository.CreateKurum(createKurumDto);
            return Ok("Kategori başarılı bir şekilde eklendi!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteKurum(int id)
        {
            _kurumRepository.DeleteKurum(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateKurum(UpdateKurumDto updateKurumDto)
        {
            _kurumRepository.UpdateKurum(updateKurumDto);
            return Ok("Kategori Başarıyla Güncellendi");
        }
    }
}
