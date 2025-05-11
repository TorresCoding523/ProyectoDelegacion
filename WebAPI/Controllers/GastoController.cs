using COMMON.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GastoController : GenericController<Gasto>
	{
        public GastoController() : base(Parametros.FabricaRepository.GastoRepository())
        {

        }
    }
}
