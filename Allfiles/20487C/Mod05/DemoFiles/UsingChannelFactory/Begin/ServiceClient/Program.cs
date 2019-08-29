using HotelBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IHotelBookingService proxy = null; // TODO channel Factory 

            Reservation reservation = new Reservation
            {
                HotelName = "HotelA",
                GuestName = "John",
                NumberOfDays = 3,
                CheckinDate = DateTime.Now
            };

            BookingResponse response = proxy.BookHotel(reservation);

            Console.WriteLine
                ("Booking response: {0}, booking reference: {1}",
                response.IsApproved ? "Approved" : "Declined",
                response.BookingReference);

            Console.ReadLine();
        }
    }
}
