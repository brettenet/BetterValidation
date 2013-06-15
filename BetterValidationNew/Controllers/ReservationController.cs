using System.Net;
using System.Net.Http;
using System.Web.Http;
using BetterValidation.ActionFilters;
using BetterValidation.Models;

namespace BetterValidation.Controllers
{
    public class ReservationController : ApiController
    {
        [ValidationResponseFilter]
        public HttpResponseMessage Post(Reservation reservation)
        {
            return Request.CreateResponse(HttpStatusCode.OK, reservation);
        }
    }
}