using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:27239", headers:"*",methods:"GET,POST,PUT,DELETE")]
    public class ChargingController : ApiController
    {
        [HttpGet]
        public string GetAllChargingData()
        {
            return "Success";
        }
    }
}
