using Aplicacion_Meteorologia.Singleton;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Aplicacion_Meteorologia.Controllers
{
    public class CiudadesController : ApiController
    {
        [HttpGet]
        [Route("Ciudades")]
        public HttpResponseMessage GetCityFileAsListDictionary()
        {
            Dictionary<String,String> queryString = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
            String filtro = null;
            queryString.TryGetValue("filtro", out filtro);
            SingletonCiudades singletonCiudades = SingletonCiudades.GetInstance();
            List<Dictionary<String, Object>> cities = singletonCiudades.findCitiesByFilter( filtro == null ? null : filtro.ToString());
            string json = JsonConvert.SerializeObject(cities);
            if (!string.IsNullOrEmpty(json))
            {
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
