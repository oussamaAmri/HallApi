using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallDomain.Interfaces
{
    public interface IHallRepository
    {
        IEnumerable<string> GetHalls();
        IEnumerable<string> GetPeople();
    }
}
