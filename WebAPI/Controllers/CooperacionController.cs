using COMMON.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CooperacionController : GenericController<Cooperacion>
	{
        public CooperacionController() : base(Parametros.FabricaRepository.CooperacionRepository())
        {

        }
    }
}
