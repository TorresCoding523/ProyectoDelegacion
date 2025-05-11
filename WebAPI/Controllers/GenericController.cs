using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using COMMON1.Entidades;
using COMMON.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericController<T> : ControllerBase where T : CamposControl
    {
        //CRUD
        //Create->Post
        //Read->Get
        //Update->Put
        //Delete->Delete

        public IDB<T> _repositorio;

        public GenericController(IDB<T> repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]

        // Obtener Todos
        public ActionResult<List<T>> Get()
        {
            try
            {
                var datos = _repositorio.ObtenerTodos();
                if (datos != null)
                {
                    return Ok(datos);
                }
                else
                {
                    return BadRequest(_repositorio.Error);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<T> GetById(string id)
        {
            try
            {
                T datos;

                if (int.TryParse(id, out int idEntero))
                {
                    // Llamamos a la sobrecarga que usa int
                    datos = _repositorio.ObtenerPorId(idEntero);
                }
                else
                {
                    // Llamamos a la sobrecarga que usa string
                    datos = _repositorio.ObtenerPorId(id);
                }

                if (datos != null)
                {
                    return Ok(datos);
                }
                else
                {
                    return NotFound($"No se encontró el elemento con ID {id}.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }



        [HttpPost]
        public ActionResult<T> Post(T entidad)
        {
            try
            {
                var datos = _repositorio.Insertar(entidad);
                if (datos != null)
                {
                    return Ok(datos);
                }
                else
                {
                    return BadRequest(_repositorio.Error);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult<T> Put(T entidad)
        {
            try
            {
                var datos = _repositorio.Actualizar(entidad);
                if (datos != null)
                {
                    return Ok(datos);
                }
                else
                {
                    return BadRequest(_repositorio.Error);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                T entidad;

                if (int.TryParse(id, out int idEntero))
                {
                    // Buscar por ID numérico
                    entidad = _repositorio.ObtenerPorId(idEntero);
                }
                else
                {
                    // Buscar por ID alfanumérico
                    entidad = _repositorio.ObtenerPorId(id);
                }

                if (entidad == null)
                {
                    return NotFound($"No se encontró el recurso con ID {id}.");
                }

                // Intentar eliminar la entidad
                var resultado = _repositorio.Eliminar(entidad);
                if (resultado)
                {
                    return NoContent(); // 204 No Content si la eliminación fue exitosa
                }
                else
                {
                    return BadRequest($"No se pudo eliminar el recurso con ID {id}. Error: {_repositorio.Error}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }
    }
}
