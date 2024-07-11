using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate_Dapper_Api.Repositories;
using Dapper;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TDto, TRepository> : ControllerBase
        where TDto : class
        where TRepository : IGenericRepository<TDto>
    {
        private readonly TRepository _repository;
        private readonly string _getAllQuery;
        private readonly string _createQuery;
        private readonly string _updateQuery;
        private readonly string _deleteQuery;

        public GenericController(TRepository repository, string getAllQuery, string createQuery, string updateQuery, string deleteQuery)
        {
            _repository = repository;
            _getAllQuery = getAllQuery;
            _createQuery = createQuery;
            _updateQuery = updateQuery;
            _deleteQuery = deleteQuery;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _repository.GetAllAsync(_getAllQuery);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TDto dto)
        {
            var parameters = new DynamicParameters(dto);
            await _repository.CreateAsync(_createQuery, parameters);
            return Ok("Başarıyla eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TDto dto)
        {
            var parameters = new DynamicParameters(dto);
            await _repository.UpdateAsync(_updateQuery, parameters);
            return Ok("Başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            await _repository.DeleteAsync(_deleteQuery, parameters);
            return Ok("Başarıyla silindi!");
        }
    }
}
