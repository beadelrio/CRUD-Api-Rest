using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Aplicacion_Meteorologia.Singleton
{
    public class SingletonCiudades
    {
        private static SingletonCiudades instance = null;
        private static List<Dictionary<String, Object>> ListCities = null;

        private SingletonCiudades() { }

        public static SingletonCiudades GetInstance()
        {
            if (instance == null)
            {
                instance = new SingletonCiudades();

                if ( ListCities == null )
                {
                    String file = HostingEnvironment.MapPath(@"/App_Data/city.list.json");
                    FileStream fs = new FileStream(file, FileMode.Open);
                    StreamReader sw = new StreamReader(fs);
                    var json = sw.ReadToEnd();
                    fs.Close();
                    ListCities = JsonConvert.DeserializeObject<List<Dictionary<String, Object>>>(json);
                }
            }

            return instance;
        }

        public List<Dictionary<String, Object>> findCitiesByFilter(String filter)
        {
            List<Dictionary<String, Object>> cities = new List<Dictionary<String, Object>>();
            if ( filter == null )
            {
                return cities;
            }
            else
            {
                foreach (Dictionary<String,Object> city in ListCities)
                {
                    Object id = null;
                    Object name = null;
                    Object country = null;
                    city.TryGetValue("id", out id);
                    city.TryGetValue("name", out name);
                    city.TryGetValue("country", out country);

                    if ( String.Concat(name,",",country).ToLower().Contains( filter.ToLower() ) )
                    {
                        cities.Add(city);
                    }
                }

                return cities;
            }
        }
    }
}