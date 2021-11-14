using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Model
{
    public class StudentRepo : IStudent
    {
        private readonly AppDbContext appDbContext;
        public StudentRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Student> AddStudent(Student student)
        {
            var result = await appDbContext.Students.AddAsync(student);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Student> DeleteStudent(int studentId)
        {
            var result = await appDbContext.Students.FirstOrDefaultAsync(s => s.Id == studentId);
            if (result != null)
            {
                appDbContext.Students.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IEnumerable<Student>> GetStudent()
        {
            return await appDbContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudent(int studentId)
        {
            return await appDbContext.Students.FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await appDbContext.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
            if (result != null)
            {
                result.StudName = student.StudName;
                result.StudEmail = student.StudEmail;
                result.StudRollNumber = student.StudRollNumber;
                result.StudPassword = student.StudPassword;
                result.StudPhoneNumber = student.StudPhoneNumber;
                result.StudFatherName = student.StudFatherName;
                result.StudAddress = student.StudAddress;
                result.StudYearAndBranch = student.StudYearAndBranch;
                result.StudDOB = student.StudDOB;
                result.StudGender = student.StudGender;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
