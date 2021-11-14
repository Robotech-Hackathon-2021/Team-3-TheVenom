using Hackathon.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnonymousController : ControllerBase
    {
        private readonly IAnonymous anonymousRepo;
        public AnonymousController(IAnonymous _anonymousRepo)
        {
            anonymousRepo = _anonymousRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAnonymous()
        {
            try
            {
                return Ok(await anonymousRepo.GetAnonymous());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Anonymous>> GetAnonymous(int id)
        {
            try
            {
                var result = await anonymousRepo.GetAnonymous(id);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Anonymous>> CreateAnonymous(Anonymous anonymous)
        {
            try
            {
                if (anonymous == null)
                {
                    return BadRequest();
                }

                var createdAnonymous = await anonymousRepo.AddAnonymous(anonymous);
                return CreatedAtAction(nameof(GetAnonymous),
                    new { id = createdAnonymous.Id }, createdAnonymous
                    );
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating new Customer record");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Anonymous>> DeleteAnonymous(int id)
        {
            try
            {
                var anonymousToDelete = await anonymousRepo.GetAnonymous(id);
                if (anonymousToDelete == null)
                {
                    return NotFound($"Customer with Id={id} not found");
                }

                return await anonymousRepo.DeleteAnonymous(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Anonymous>> UpdateAnonymous(int id, Anonymous anonymous)
        {
            try
            {
                if (id != anonymous.Id)
                    return BadRequest("Customer ID mismatch");

                var anonymousToUpdate = await anonymousRepo.GetAnonymous(id);

                if (anonymousToUpdate == null)
                    return NotFound($"Customer with Id = {id} not found");

                return await anonymousRepo.UpdateAnonymous(anonymous);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

    }
}
