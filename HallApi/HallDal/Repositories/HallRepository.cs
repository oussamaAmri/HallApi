using HallDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallDal.Repositories
{
    public class HallRepository:IHallRepository
    {
        private readonly FuwearContext dbContext;

        public HallRepository(FuwearContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<string> GetHalls()
        {
            var db = dbContext.Rooms.ToList();
            var ListRoom = new List<string>();
            foreach (var room in db)
            {
                ListRoom.Add(room.RoomName);   
            }
            return ListRoom;
        }

        public IEnumerable<string> GetPeople()
        {
            var db = dbContext.People.ToList();
            var ListPeople = new List<string>();
            foreach (var people in db)
            {
                ListPeople.Add(people.FirstName);
                ListPeople.Add(people.LastName);
            }
            return ListPeople;
        }
    }
}
