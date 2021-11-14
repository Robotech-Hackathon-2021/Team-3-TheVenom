using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Model
{
    public interface IStudent
    {
        //All Details
        Task<IEnumerable<Student>> GetStudent();
        //Single Details
        Task<Student> GetStudent(int studentId);
        //Add a Student
        Task<Student> AddStudent(Student student);
        //Update a Student
        Task<Student> UpdateStudent(Student student);
        //Delete a Student
        Task<Student> DeleteStudent(int studentId);
    }
}
