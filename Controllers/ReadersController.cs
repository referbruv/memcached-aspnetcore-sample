using System;
using Microsoft.AspNetCore.Mvc;
using ReadersMvcApp.Providers.Repositories;

namespace ReadersMvcApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadersController : ControllerBase
    {
        private readonly IReaderRepo _repo;

        public ReadersController(IReaderRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.Readers);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var reader = _repo.GetReader(id);
            return Ok(reader);
        }
    }
}