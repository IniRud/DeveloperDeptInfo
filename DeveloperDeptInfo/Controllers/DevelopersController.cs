using DeveloperDeptInfo.Domain;
using DeveloperDeptInfo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperDeptInfo.Controllers
{
    [ApiController]
    [Route("api/v1/controller")]
    public class DevelopersController:ControllerBase
    {
        protected readonly IDeveloperService _developerService;
        public DevelopersController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDevelopers()
        {
            var developers = await _developerService.GetAllDeveloper();
            return Ok(developers);
        }
        [Route("[action]")]
        //[HttpGet("Id")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDeveloperById(int Id)
        {
            var developer = await _developerService.GetDeveloperById(Id);
            return Ok(developer);
        }

        //[HttpGet("Email")]
        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDeveloperByEmail(string Email)
        {
            var developer = await _developerService.GetDeveloperByEmail(Email);
            return Ok(developer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddDeveloper([FromBody] Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _developerService.AddDeveloper(developer);
            return CreatedAtAction(nameof(GetDeveloperById), new { Id = developer.Id }, developer);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult UpdateDeveloper([FromBody] Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _developerService.UpdateDeveloper(developer);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteDeveloper(int Id)
        {
            _developerService.DeleteDeveloper(Id);
            return Ok();
        }

    }
}
