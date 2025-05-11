using COMMON.Entidades;
using COMMON.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DocumentoSolicitadoController : GenericController<DocumentoSolicitado>
	{
        public DocumentoSolicitadoController() : base(Parametros.FabricaRepository.DocumentoSolicitadoRepository())
        {

        }

        [HttpGet("ObtenerDocumentosSolicitadosDeCiudadano/{idCiudadano}")]
        public ActionResult <List<DocumentoSolicitado>> ObtenerDocumentosSolicitadosDeCiudadano(string idCiudadano)
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("Operacion", "3");
            parametros.Add("IdCiudadano", idCiudadano);
            var datos=
            _repositorio.EjecutarProcedimiento<DocumentoSolicitadoPorCiudadanoModel>("PROC_Ciudadano",parametros);
            if(datos != null)
            {
                return Ok(datos);
            }
            else
            {
                return BadRequest(_repositorio.Error);
            }
        }
    }
}
