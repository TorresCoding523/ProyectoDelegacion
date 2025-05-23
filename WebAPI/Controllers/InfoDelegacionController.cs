using COMMON.Entidades;

namespace WebAPI.Controllers
{
    public class InfoDelegacionController : GenericController<InfoDelegacion>
    {
        public InfoDelegacionController() : base(Parametros.FabricaRepository.InfoDelegacionRepository())
        {

        }
    }
}
