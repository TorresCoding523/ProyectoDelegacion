using COMMON.Entidades;
using COMMON.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CiudadanoController : GenericController<Ciudadano>
	{
        public CiudadanoController() : base(Parametros.FabricaRepository.CiudadanoRepository())
        {

        }

        [HttpPost("Login")]
        public ActionResult<Ciudadano> login([FromBody] LoginModel datos)
        {
			try
			{
				Dictionary<string, string> parametros = new Dictionary<string, string>();
				parametros.Add("Operacion","9");
				parametros.Add("user", datos.User);
				parametros.Add("password", datos.Password);
				var resultado = _repositorio.EjecutarProcedimiento<Ciudadano>("PROC_Ciudadano", parametros);
				if (resultado != null)
				{
					return Ok(resultado.SingleOrDefault());
				}
				else
				{
					return BadRequest(resultado.SingleOrDefault());
				}
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
        }
    }
}
