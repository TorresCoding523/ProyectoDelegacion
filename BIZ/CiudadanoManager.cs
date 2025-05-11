using COMMON.Entidades;
using COMMON.Modelos;
using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class CiudadanoManager : GenericManager<Ciudadano>
    {
        Random r;
        public CiudadanoManager(AbstractValidator<Ciudadano> validator) : base(validator)
        {
            r = new Random(DateTime.Now.Microsecond);
        }

        public override Task<Ciudadano> Agregar(Ciudadano entidad)
        {
            try
            {
                entidad.URLFoto = string.IsNullOrEmpty(entidad.URLFoto) ? "Temp.jpg" : entidad.URLFoto;
                entidad.URLFotoFachada = string.IsNullOrEmpty(entidad.URLFotoFachada) ? "Temp.jpg" : entidad.URLFotoFachada;
                entidad.Notas = string.IsNullOrEmpty(entidad.Notas) ? "Ninguna" : entidad.Notas;
                entidad.FechaUltimoIngreso = new DateTime(2000, 1, 1);

                // Usa los primeros caracteres disponibles (sin asumir longitud mínima)
                var nombrePart = entidad.Nombre.Length >= 2 ? entidad.Nombre.Substring(0, 2) : entidad.Nombre;
                var apellidosPart = entidad.Apellidos.Length >= 2 ? entidad.Apellidos.Substring(0, 2) : entidad.Apellidos;

                entidad.IdCiudadano = $"{nombrePart}{apellidosPart}{r.Next(10, 99)}";

                return base.Agregar(entidad);
            }
            catch (Exception ex)
            {
                Error = $"Error al agregar ciudadano: {ex.Message}";
                return null;
            }
        }

        public async Task<Ciudadano> Login(LoginModel datos)
        {
            try
            {
                var c = JsonConvert.SerializeObject(datos);
                var body = new StringContent(c, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await
                    _httpClient.PostAsync($"api/Login", body).ConfigureAwait(false);
                var content = await
                    response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Error = "";
                    var respuesta = JsonConvert.DeserializeObject<Ciudadano>
                       (content);
                    return respuesta;
                }
                else
                {
                    Error = content;
                    return null;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }
    }
}
