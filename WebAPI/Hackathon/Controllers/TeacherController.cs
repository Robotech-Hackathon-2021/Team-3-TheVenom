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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher teacherRepo;
        public TeacherController(ITeacher _teacherRepo)
        {
            teacherRepo = _teacherRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetTeacher()
        {
            try
            {
                return Ok(await teacherRepo.GetTeacher());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            try
            {
                var result = await teacherRepo.GetTeacher(id);
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
        public async Task<ActionResult<Teacher>> CreateTeacher(Teacher teacher)
        {
            try
            {
                if (teacher== null)
                {
                    return BadRequest();
                }

                var createdTeacher= await teacherRepo.AddTeacher(teacher);
                return CreatedAtAction(nameof(GetTeacher),
                    new { id = createdTeacher.Id }, createdTeacher
                    );
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating new Customer record");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(int id)
        {
            try
            {
                var teacherToDelete = await teacherRepo.GetTeacher(id);
                if (teacherToDelete == null)
                {
                    return NotFound($"Customer with Id={id} not found");
                }

                return await teacherRepo.DeleteTeacher(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Teacher>> UpdateTeacher(int id, Teacher teacher)
        {
            try
            {
                if (id != teacher.Id)
                    return BadRequest("Customer ID mismatch");

                var TeacherToUpdate = await teacherRepo.GetTeacher(id);

                if (TeacherToUpdate == null)
                    return NotFound($"Customer with Id = {id} not found");

                return await teacherRepo.UpdateTeacher(teacher);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
