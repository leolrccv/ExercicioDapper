using DapperEx.Domain.Entities;
using DapperEx.Infra.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DapperEx.Controllers
{
    [Route("api/pets")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _repository;

        public PetController(IPetRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Pet pet)
        {
            await _repository.AddAsync(pet);
            return Created($"/api/pets/{pet.Id}", pet);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPets()
        {
            return Ok(await _repository.GetAllPets());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var pet = await _repository.GetByIdAsync(id);
            return Ok(pet);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update([FromBody] Pet pet, Guid id)
        {
            pet.Id = id;
            return Ok(await _repository.Update(pet));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _repository.Delete(id));
        }

    }
}
