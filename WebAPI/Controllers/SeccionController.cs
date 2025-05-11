using COMMON.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SeccionController : GenericController<Seccion>
	{
        public SeccionController() : base(Parametros.FabricaRepository.SeccionRepository())
        {

        }
    }
}
