using System;
using System.Collections.Generic;

namespace BusTicketBookingSystem.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            InverseSeatNumberNavigation = new HashSet<UserDetail>();
        }

        public int UserId { get; set; }
        public string Uname { get; set; } = null!;
        public int UmobileNumber { get; set; }
        public string CurentAddress { get; set; } = null!;
        public string NativeAddress { get; set; } = null!;
        public string From { get; set; } = null!;
        public string To { get; set; } = null!;
        public int SeatNumber { get; set; }

        public virtual UserDetail SeatNumberNavigation { get; set; } = null!;
        public virtual ICollection<UserDetail> InverseSeatNumberNavigation { get; set; }
    }
}
