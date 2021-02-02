using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
//using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private AlbumRepository Repository { get; set; }

        public AlbumController(AlbumRepository repository)
        {
            Repository = repository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            // TODO: Your code here
            return Ok(await Repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(Guid id)
        {
            var result = await Repository.GetByIdAsync(id);

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Album model)
        {
            await Repository.SaveAsync(model);

            return Created($"/{model.Id}", model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Repository.GetByIdAsync(id);
            await Repository.RemoveAsync(result);
            return NoContent();
        }
    }
}