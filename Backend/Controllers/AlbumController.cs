using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        public AlbumController()
        {
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            // TODO: Your code here
            return Ok(new
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Album legal",
                Description = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum"
            });
        }
    }
}