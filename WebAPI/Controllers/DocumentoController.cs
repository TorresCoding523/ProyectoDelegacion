using COMMON.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DocumentoController : GenericController<Documento>
	{
        public DocumentoController() : base(Parametros.FabricaRepository.DocumentoRepository())
        {

        }
    }
}
