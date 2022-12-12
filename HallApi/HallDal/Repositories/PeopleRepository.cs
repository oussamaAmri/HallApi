using HallDal.Entities;
using HallDomain.Interfaces;
using HallDomain.Models;
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
/*        public IEnumerable<string> GetPeople()
        {
            var db = _dbContext.People.ToList();
            var peopleList = new List<string>();
            foreach (var people in db)
            {
                peopleList.Add(people.FirstName + " " + people.LastName);
            }
            return peopleList;
        }
*/

        public async Task<IEnumerable<People>> GetPeopleAsync()
        {
            return await _dbContext.People.Select(p => new People
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName
            }).ToListAsync();
        }

        /*        public async Task<People> AddPeoplesAsync(People people)
                {
                    var room = new RoomEntity { RoomName = hall.Name };
                    var db = _dbContext.Rooms.Add(room);
                    await _dbContext.SaveChangesAsync();
                    return new Hall { Id = room.Id, Name = room.RoomName };

                }*/
        public async Task<People> GetPeopleByIdAsync(int id)
        {
            var person = await _dbContext.People.SingleOrDefaultAsync(p => p.Id == id);
            if (person == null)
            {
                return null;
            }
            return new People { Id = person.Id, FirstName = person.FirstName, LastName = person.LastName };
        }
        public async Task<People> AddPeoplesAsync(People people)
        {
            var person = new PersonEntity { FirstName = people.FirstName, LastName = people.LastName };
            _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();
            return new People { Id = person.Id, FirstName = person.FirstName, LastName = person.LastName};

        }

        public async Task<People> UpdatePeoplesAsync(int id, People people)
        {
            var person = await _dbContext.People.FindAsync(id);
            var personToUpdate = new PersonEntity { FirstName = people.FirstName, LastName = people.LastName };
            if (person == null)
            {
                return null;
            }
            person.FirstName = personToUpdate.FirstName;
            person.LastName = personToUpdate.LastName;
            await _dbContext.SaveChangesAsync();
            return new People { Id = person.Id, FirstName = person.FirstName, LastName = person.LastName };
        }
    }
}
