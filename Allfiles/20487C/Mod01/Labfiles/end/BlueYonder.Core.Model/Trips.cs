using System;
using System.Collections.Generic;

namespace BlueYonder.Core.Model
{
    public partial class Trips
    {
        public Trips()
        {
            ReservationsDepartFlightSchedule = new HashSet<Reservations>();
            ReservationsReturnFlightSchedule = new HashSet<Reservations>();
        }

        public int TripId { get; set; }
        public int FlightScheduleId { get; set; }
        public int Status { get; set; }
        public int Class { get; set; }
        public string ThumbnailImage { get; set; }

        public virtual FlightSchedules FlightSchedule { get; set; }
        public virtual ICollection<Reservations> ReservationsDepartFlightSchedule { get; set; }
        public virtual ICollection<Reservations> ReservationsReturnFlightSchedule { get; set; }
    }
}
