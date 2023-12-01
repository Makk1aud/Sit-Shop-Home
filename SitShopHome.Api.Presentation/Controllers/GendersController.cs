using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitShopHome.Api.Presentation.Controllers
{
    [ApiController]
    [Route("api/genders")]
    public class GendersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public GendersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetGenders()
        {
            var gendersToReturn = _serviceManager.Gender.GetGenders(trackChanges: false);
            return Ok(gendersToReturn);
        }

        [HttpGet("{genderId}", Name ="GenderById")]
        public IActionResult GetGender(Guid genderId)
        {
            var genderToReturn = _serviceManager.Gender.GetGender(genderId, trackChanges: false);
            return Ok(genderToReturn);
        }

        [HttpPost]
        public IActionResult CreateGender([FromBody] GenderForManipulationDTO genderForManipulation)
        {
            if (genderForManipulation is null)
                return BadRequest("Sent object is null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var genderToReturn = _serviceManager.Gender.CreateGender(genderForManipulation);
            return CreatedAtRoute("GenderById", new { genderId = genderToReturn.id }, genderToReturn);
        }

        [HttpDelete("{genderId}")]
        public IActionResult DeleteGender(Guid genderId)
        {
            _serviceManager.Gender.DeleteGender(genderId, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{genderId}")]
        public IActionResult UpdateGender(Guid genderId, GenderForManipulationDTO genderForManipulation)
        {
            if (genderForManipulation is null)
                return BadRequest("Sent object is null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var genderToReturn = _serviceManager.Gender.UpdateGender(genderId, genderForManipulation, trackChanges: true);
            return Ok(genderToReturn);
        }
    }
}
