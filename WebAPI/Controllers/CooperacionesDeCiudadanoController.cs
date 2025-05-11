using COMMON.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CooperacionesDeCiudadanoController : GenericController<CooperacionesDeCiudadano>
	{
        public CooperacionesDeCiudadanoController() : base(Parametros.FabricaRepository.CooperacionesDeCiudadanoRepository())
        {

        }
    }
}
