using COMMON;
using COMMON1.Entidades;
using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BIZ
{
    public abstract class GenericManager<T> where T : CamposControl
    {
        protected HttpClient _httpClient;
        public string Error { get; protected set; }
        AbstractValidator<T> _validator;
        protected GenericManager(AbstractValidator<T> validator)
        {
            _validator = validator;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Params.UrlAPI);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
                ("application/json"));
        }
        public async Task<List<T>> ObtenerTodos()
        {
            try
            {
                HttpResponseMessage response = await
                    _httpClient.GetAsync($"api/{typeof(T).Name}").ConfigureAwait(false);
                var content = await
                    response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Error = "";
                    var respuesta = JsonConvert.DeserializeObject<List<T>>
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
        public async Task<T> ObtenerPorId(string id)
        {
            try
            {

                HttpResponseMessage response = await
                    _httpClient.GetAsync($"api/{typeof(T).Name}/{id}").ConfigureAwait(false);
                var content = await
                    response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Error = "";
                    var respuesta = JsonConvert.DeserializeObject<T>
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
        public async Task<bool> Eliminar(string id)
        {
            try
            {
                HttpResponseMessage response = await
                    _httpClient.DeleteAsync($"api/{typeof(T).Name}/{id}").ConfigureAwait(false); // ¡Agrega el ID en la URL!
                var content = await
                    response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Error = "";
                    return true; // Cambia esto para devolver directamente true si se eliminó
                }
                else
                {
                    Error = content;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }
        public virtual async Task<T> Agregar(T entidad)
        {
            try
            {
                entidad.UsuarioMod = Params.UsuarioConectado;
                entidad.UsuarioAlta = Params.UsuarioConectado;
                entidad.FechaAlta = DateTime.Now;
                entidad.FechaMod = DateTime.Now;

                var resultadoValidator = _validator.Validate(entidad);
                if (resultadoValidator.IsValid)
                {
                    var c = JsonConvert.SerializeObject(entidad);
                    var body = new StringContent(c, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await
                        _httpClient.PostAsync($"api/{typeof(T).Name}", body).ConfigureAwait(false);
                    var content = await
                        response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        Error = "";
                        var respuesta = JsonConvert.DeserializeObject<T>
                           (content);
                        return respuesta;
                    }
                    else
                    {
                        Error = content;
                        return null;
                    }
                }
                else
                {
                    Error = string.Join(",",
                        resultadoValidator.Errors.Select(e => e.ErrorMessage));
                    return null;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }
        public async Task<T> Modificar(T entidad)
        {
            try
            {
                entidad.UsuarioMod = Params.UsuarioConectado;
                entidad.FechaMod = DateTime.Now;
                var resultadoValidator = _validator.Validate(entidad);
                if (resultadoValidator.IsValid)
                {
                    var c = JsonConvert.SerializeObject(entidad);
                    var body = new StringContent(c, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await
                        _httpClient.PutAsync($"api/{typeof(T).Name}", body).ConfigureAwait(false);
                    var content = await
                        response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        Error = "";
                        var respuesta = JsonConvert.DeserializeObject<T>
                           (content);
                        return respuesta;
                    }
                    else
                    {
                        Error = content;
                        return null;
                    }
                }
                else
                {
                    Error = string.Join(",",
                        resultadoValidator.Errors.Select(e => e.ErrorMessage));
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
