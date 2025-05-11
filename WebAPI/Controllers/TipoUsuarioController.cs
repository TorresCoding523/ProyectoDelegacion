using COMMON.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoUsuarioController : GenericController<TipoUsuario>
	{
        public TipoUsuarioController() : base(Parametros.FabricaRepository.TipoUsuarioRepository())
        {

        }
    }
}
