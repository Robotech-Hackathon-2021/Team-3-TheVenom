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
    public class StudentController : ControllerBase
    {
        private readonly IStudent studentRepo;
        public StudentController(IStudent _studentRepo)
        {
            studentRepo = _studentRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudent()
        {
            try
            {
                return Ok(await studentRepo.GetStudent());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var result = await studentRepo.GetStudent(id);
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
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest();
                }

                var createdStudent = await studentRepo.AddStudent(student);
                return CreatedAtAction(nameof(GetStudent),
                    new { id = createdStudent.Id }, createdStudent
                    );
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating new Customer record");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            try
            {
                var studentToDelete = await studentRepo.GetStudent(id);
                if (studentToDelete == null)
                {
                    return NotFound($"Customer with Id={id} not found");
                }

                return await studentRepo.DeleteStudent(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            try
            {
                if (id != student.Id)
                    return BadRequest("Customer ID mismatch");

                var studentToUpdate = await studentRepo.GetStudent(id);

                if (studentToUpdate == null)
                    return NotFound($"Customer with Id = {id} not found");

                return await studentRepo.UpdateStudent(student);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

    }
}