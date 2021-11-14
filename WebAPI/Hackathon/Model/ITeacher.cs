using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Model
{
    public interface ITeacher
    {
        //All Details
        Task<IEnumerable<Teacher>> GetTeacher();
        //Single Details
        Task<Teacher> GetTeacher(int teacherId);
        //Add a Teacher
        Task<Teacher> AddTeacher(Teacher teacher);
        //Update a Teacher
        Task<Teacher> UpdateTeacher(Teacher teacher);
        //Delete a Teacher
        Task<Teacher> DeleteTeacher(int teacherId);
    }
}
