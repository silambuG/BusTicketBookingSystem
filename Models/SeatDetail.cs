using System;
using System.Collections.Generic;

namespace BusTicketBookingSystem.Models
{
    public partial class SeatDetail
    {
        public int SeatId { get; set; }
        public int SeatNumber { get; set; }
        public string SeatType { get; set; } = null!;
    }
}
