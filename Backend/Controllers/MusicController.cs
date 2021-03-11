using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Backend.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")] 
    [ApiController]
    public class MusicController : ControllerBase
    {
        private AlbumRepository AlbumRepository { get; set; }

        public MusicController(AlbumRepository repository)
        {
            AlbumRepository = repository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var music = await AlbumRepository.GetMusicFromAlbum(id);

            return Ok(music);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var music = await AlbumRepository.GetMusic(id);
            return Ok(music);
        }

        [HttpPost("{albumId}")]
        public async Task<IActionResult> PostTModel(Guid albumId, Music model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var album = await AlbumRepository.GetByIdAsync(albumId);
            album.Musics.Add(model);
            await AlbumRepository.UpdateAsync(album);
            return Ok();
        }
    }
}