﻿    using end.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace end.Controllers
{
    public class DestinationsController : ApiController
    {
        private List<Destination> _destinations;
        public DestinationsController()
        {
            _destinations = new List<Destination>();

            _destinations.Add(new Destination { Id = 1, CityName = "Seattle", Airport = "Sea-Tac" });
            _destinations.Add(new Destination { Id = 2, CityName = "New-york", Airport = "JFK" });
            _destinations.Add(new Destination { Id = 3, CityName = "Amsterdam", Airport = "Schiphol" });
            _destinations.Add(new Destination { Id = 4, CityName = "London", Airport = "Heathrow" });
            _destinations.Add(new Destination { Id = 5, CityName = "Paris", Airport = "Charles De Gaulle" });
        }

        // GET api/destinations/5
        public Destination Get(int id)
        {
            var destination = _destinations.Find(d=>d.Id == id);

            if (destination == null)
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.NotFound));

            return destination;
        }
    }
}