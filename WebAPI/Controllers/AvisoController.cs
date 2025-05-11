using COMMON.Entidades;
using COMMON.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AvisoController : GenericController<Aviso>
	{
		public AvisoController () : base(Parametros.FabricaRepository.AvisoRepository())
		{

		}
	}
}
