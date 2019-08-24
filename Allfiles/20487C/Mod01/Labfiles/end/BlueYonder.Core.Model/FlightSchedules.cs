using System;
using System.Collections.Generic;

namespace BlueYonder.Core.Model
{
    public partial class FlightSchedules
    {
        public FlightSchedules()
        {
            Trips = new HashSet<Trips>();
        }

        public int FlightScheduleId { get; set; }
        public DateTime Departure { get; set; }
        public DateTime? ActualDeparture { get; set; }
        public TimeSpan Duration { get; set; }
        public int FlightId { get; set; }

        public virtual Flights Flight { get; set; }
        public virtual ICollection<Trips> Trips { get; set; }
    }
}
