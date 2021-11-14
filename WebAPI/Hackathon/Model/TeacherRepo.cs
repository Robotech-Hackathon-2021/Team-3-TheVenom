using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Model
{
    public class TeacherRepo : ITeacher
    {
        private readonly AppDbContext appDbContext;
        public TeacherRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            var result = await appDbContext.Teachers.AddAsync(teacher);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Teacher> DeleteTeacher(int teacherId)
        {
            var result = await appDbContext.Teachers.FirstOrDefaultAsync(t => t.Id == teacherId);
            if (result != null)
            {
                appDbContext.Teachers.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IEnumerable<Teacher>> GetTeacher()
        {
            return await appDbContext.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacher(int teacherId)
        {
            return await appDbContext.Teachers.FirstOrDefaultAsync(t => t.Id == teacherId);
        }

        public async Task<Teacher> UpdateTeacher(Teacher teacher)
        {
            var result = await appDbContext.Teachers.FirstOrDefaultAsync(t => t.Id == teacher.Id);
            if (result != null)
            {
                result.TeacherName = teacher.TeacherName;
                result.TeacherEmail = teacher.TeacherEmail;
                result.TeacherID = teacher.TeacherID;
                result.TeacherPassword = teacher.TeacherPassword;
                result.TeacherPhoneNumber = teacher.TeacherPhoneNumber;
                result.TeacherAddress = teacher.TeacherAddress;
                result.TeacherDegree = teacher.TeacherDegree;
                result.TeacherDOB = teacher.TeacherDOB;
                result.TeacherGender = teacher.TeacherGender;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
