using System;
using System.Collections.Generic;

namespace BlueYonder.Core.Model
{
    public partial class Reservations
    {
        public int ReservationId { get; set; }
        public int TravelerId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ConfirmationCode { get; set; }
        public int DepartFlightScheduleId { get; set; }
        public int? ReturnFlightScheduleId { get; set; }

        public virtual Trips DepartFlightSchedule { get; set; }
        public virtual Trips ReturnFlightSchedule { get; set; }
    }
}
