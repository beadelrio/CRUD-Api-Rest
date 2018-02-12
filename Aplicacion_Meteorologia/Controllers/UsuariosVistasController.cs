using Aplicacion_Meteorologia.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion_Meteorologia.Controllers
{
    public class UsuariosVistasController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:54313/";

        public async Task<List<Usuario>> GetUsuarios()
        {
            List<Usuario> ListaDeUsuarios = new List<Usuario>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Usuarios");
                if (Res.IsSuccessStatusCode)
                {
                    var UsuariosResponse = Res.Content.ReadAsStringAsync().Result;
                    ListaDeUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(UsuariosResponse);
                }
            }

            return ListaDeUsuarios;
        }

        public async Task<Usuario> GetUsuarioById(String id)
        {
            Usuario usuario = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(string.Concat("api/Usuarios/", id));
                if (Res.IsSuccessStatusCode)
                {
                    var UsuarioResponse = Res.Content.ReadAsStringAsync().Result;
                    usuario = JsonConvert.DeserializeObject<Usuario>(UsuarioResponse);
                }
            }

            return usuario;
        }

        public async Task<Usuario> DeleteUsuarioById(String id)
        {
            Usuario usuario = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.DeleteAsync(string.Concat("api/Usuarios/", id));
                if (Res.IsSuccessStatusCode)
                {
                    var UsuarioResponse = Res.Content.ReadAsStringAsync().Result;
                    usuario = JsonConvert.DeserializeObject<Usuario>(UsuarioResponse);
                }
            }

            return usuario;
        }

        // GET: UsuariosVistas
        public async Task<ActionResult> Index()
        {
            List<Usuario> ListaDeUsuarios = await GetUsuarios();
            return View(ListaDeUsuarios);
        }

        // GET: UsuariosVistas/Details/beariocalderon
        public async Task<ActionResult> Details(String id)
        {
            Usuario usuario = await GetUsuarioById(id);
            return View(usuario);
        }

        // GET: UsuariosVistas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosVistas/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            Usuario usuario = new Usuario();
            usuario.Id = collection.Get("Id");
            usuario.Password = collection.Get("Password");
            usuario.NombreCompleto = collection.Get("NombreCompleto");
            usuario.Dni = collection.Get("Dni");
            usuario.Localizacion = collection.Get("Localizacion");
            usuario.Meteorologia = collection.Get("Meteorologia");

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PostAsJsonAsync(string.Concat("api/Usuarios/"), usuario);
                    if (Res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(usuario);
                    }
                }
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: UsuariosVistas/Edit/beariocalderon
        public async Task<ActionResult> Edit(String id)
        {
            Usuario usuario = await GetUsuarioById(id);
            return View(usuario);
        }

        // POST: UsuariosVistas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(String id, FormCollection collection)
        {
            try
            {
                Usuario usuario = await GetUsuarioById(id);
                if ( usuario != null )
                {
                    usuario.Password = collection.Get("Password");
                    usuario.NombreCompleto = collection.Get("NombreCompleto");
                    usuario.Dni = collection.Get("Dni");
                    usuario.Localizacion = collection.Get("Localizacion");
                    usuario.Meteorologia = collection.Get("Meteorologia");
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage Res = await client.PutAsJsonAsync(string.Concat("api/Usuarios/", id), usuario);
                        if (Res.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return View();
                        }
                    }
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosVistas/Delete/beariocalderon
        public async Task<ActionResult> Delete(String id)
        {
            Usuario usuario = await GetUsuarioById(id);
            return View(usuario);
        }

        // POST: UsuariosVistas/Delete/beariocalderon
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(String id, FormCollection collection)
        {
            try
            {
                Usuario usuarioBorrado = await DeleteUsuarioById(id);
                if ( usuarioBorrado != null )
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
