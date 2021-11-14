using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Model
{
    public class AnonymousRepo : IAnonymous
    {
        private readonly AppDbContext appDbContext;
        public AnonymousRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Anonymous> AddAnonymous(Anonymous anonymous)
        {
            var result = await appDbContext.Anonymouss.AddAsync(anonymous);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Anonymous> DeleteAnonymous(int anonymousId)
        {
            var result = await appDbContext.Anonymouss.FirstOrDefaultAsync(a => a.Id == anonymousId);
            if (result != null)
            {
                appDbContext.Anonymouss.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IEnumerable<Anonymous>> GetAnonymous()
        {
            return await appDbContext.Anonymouss.ToListAsync();
        }

        public async Task<Anonymous> GetAnonymous(int anonymousId)
        {
            return await appDbContext.Anonymouss.FirstOrDefaultAsync(a => a.Id == anonymousId);
        }

        public async Task<Anonymous> UpdateAnonymous(Anonymous anonymous)
        {
            var result = await appDbContext.Anonymouss.FirstOrDefaultAsync(a => a.Id == anonymous.Id);
            if (result != null)
            {
                result.Type = anonymous.Type;
                result.Title = anonymous.Title;
                result.Description = anonymous.Description;
                

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
