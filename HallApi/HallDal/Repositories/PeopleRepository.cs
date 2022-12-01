using HallDal.Entities;
using HallDomain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallDal.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly FuwearContext _dbContext;
        public PeopleRepository(FuwearContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<string> GetPeople()
        {
            var db = _dbContext.People.ToList();
            var peopleList = new List<string>();
            foreach (var people in db)
            {
                peopleList.Add(people.FirstName + " " + people.LastName);
            }
            return peopleList;
        }

        public async Task<IEnumerable<string>> GetPeopleAsync()
        {
            return await _dbContext.People.Select(p => p.FirstName + " " +  p.LastName).ToListAsync();
        }
    }
}
