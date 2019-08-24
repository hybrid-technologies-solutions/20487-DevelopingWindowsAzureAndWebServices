using System;
using System.Collections.Generic;

namespace BlueYonder.Core.Model
{
    public partial class Flights
    {
        public Flights()
        {
            FlightSchedules = new HashSet<FlightSchedules>();
        }

        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public int FrequentFlyerMiles { get; set; }
        public int? SourceLocationId { get; set; }
        public int? DestinationLocationId { get; set; }

        public virtual Locations DestinationLocation { get; set; }
        public virtual Locations SourceLocation { get; set; }
        public virtual ICollection<FlightSchedules> FlightSchedules { get; set; }
    }
}
