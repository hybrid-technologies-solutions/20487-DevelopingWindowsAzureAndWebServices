﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlueYonder.Entities;
using BlueYonder.DataAccess.Interfaces;
using BlueYonder.DataAccess.Repositories;

namespace BlueYonder.Companion.Controllers
{
    public class TravelersController : ApiController
    {
        private readonly ITravelerRepository travelers;

        public TravelersController()
        {
            travelers = new TravelerRepository();
        }

        public HttpResponseMessage Get(string id)
        {
            var traveler = travelers.FindBy(t => t.TravelerUserIdentity == id).FirstOrDefault();

            // Handling the HTTP status codes
            if (traveler != null)
                return Request.CreateResponse<Traveler>(HttpStatusCode.OK, traveler);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Post(Traveler traveler)
        {
            if(travelers.FindBy(t => t.TravelerUserIdentity == traveler.TravelerUserIdentity).Any())
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            // saving the new order to the database
            travelers.Add(traveler);
            travelers.Save();

            // creating the response, the newly saved entity and 201 Created status code
            var response = Request.CreateResponse(HttpStatusCode.Created, traveler);

            response.Headers.Location = new Uri(Request.RequestUri, "travelers/" + traveler.TravelerUserIdentity);
            return response;
        }

        public HttpResponseMessage Put(string id, Traveler traveler)
        {
            // returning 404 if the entity doesn't exist 
            if (travelers.FindBy(t => t.TravelerUserIdentity == id).FirstOrDefault() == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            if(traveler.TravelerId == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            travelers.Edit(traveler);
            travelers.Save();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(string id)
        {
            var traveler = travelers.FindBy(t => t.TravelerUserIdentity == id).FirstOrDefault();

            // returning 404 if the entity doesn't exist 
            if (traveler == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            travelers.Delete(traveler);
            travelers.Save();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}