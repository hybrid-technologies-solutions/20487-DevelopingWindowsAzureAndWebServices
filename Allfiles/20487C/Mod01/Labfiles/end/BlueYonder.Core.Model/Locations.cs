using System;
using System.Collections.Generic;

namespace BlueYonder.Core.Model
{
    public partial class Locations
    {
        public Locations()
        {
            FlightsDestinationLocation = new HashSet<Flights>();
            FlightsSourceLocation = new HashSet<Flights>();
        }

        public int LocationId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string ThumbnailImageFile { get; set; }
        public string TimeZoneId { get; set; }

        public virtual ICollection<Flights> FlightsDestinationLocation { get; set; }
        public virtual ICollection<Flights> FlightsSourceLocation { get; set; }
    }
}
