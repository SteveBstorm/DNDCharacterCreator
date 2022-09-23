using BLL.Interfaces;
using DNDCharacterCreator.Hubs;
using DNDCharacterCreator.Mappers;
using DNDCharacterCreator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNDCharacterCreator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;
        private readonly CharHub _hub;

        public CharacterController(ICharacterService service, CharHub hub)
        {
            _service = service;
            _hub = hub;
        }

        [HttpPost]
        public IActionResult Create(CharacterForm form)
        {
            if (!ModelState.IsValid) return BadRequest();
            //_hub.NewChar();
            return Ok(_service.Create(form.ToBll()));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
