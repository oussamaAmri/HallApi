using HallDomain.Interfaces;
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
    }
}
