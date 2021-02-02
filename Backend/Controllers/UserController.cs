using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
//using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository Repository { get; set; }
        private AlbumRepository AlbumRepository { get; set; }
        public UserController(UserRepository repository, AlbumRepository albumRepository)
        {
            Repository = repository;
            AlbumRepository = albumRepository;
        }

        [HttpGet("{id}/favorite-music")]
        public async Task<IActionResult> GetUserFavoriteMusics(Guid id)
        {
            return Ok(await Repository.GetFavoriteMusics(id));
        }

        [HttpPost("{id}/favorite-music/{musicId}")]
        public async Task<IActionResult> SaveUserFavoriteMusic(Guid id, Guid musicId)
        {
            var music = await AlbumRepository.GetMusic(musicId);
            var user = await Repository.GetByIdAsync(id);

            user.AddFavoriteMusic(music);
            await Repository.UpdateAsync(user);

            return Ok(user);
        }

        [HttpDelete("{id}/favore-music/{musicId}")]
        public async Task<IActionResult> RemoveUserFavoriteMusic(Guid id, Guid musicId)
        {
            var music = await AlbumRepository.GetMusic(musicId);
            var user = await Repository.GetByIdAsync(id);

            user.RemoveFavoriteMusic(music);
            await Repository.UpdateAsync(user);

            return Ok(user);
        }
    }
}