﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallDomain.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int PersonId { get; set; }

        public DateTime BookingDate { get; set; }

        public int StartSlot { get; set; }

        public int EndSlot { get; set; }
    }
}
