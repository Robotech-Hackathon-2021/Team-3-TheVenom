using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Model
{
    public interface IAnonymous
    {
        //All Details
        Task<IEnumerable<Anonymous>> GetAnonymous();
        //Single Details
        Task<Anonymous> GetAnonymous(int anonymousId);
        //Add an Anonymous
        Task<Anonymous> AddAnonymous(Anonymous anonymous);
        //Update an Anonymous
        Task<Anonymous> UpdateAnonymous(Anonymous anonymous);
        //Delete an Anonymous
        Task<Anonymous> DeleteAnonymous(int anonymousId);
    }
}
