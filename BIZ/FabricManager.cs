using COMMON.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public static class FabricManager
    {
        public static AvisoManager AvisoManager => new AvisoManager(new AvisoValidator());

        public static CiudadanoManager CiudadanoManager => new CiudadanoManager(new CuidadanoValidator());

        public static CooperacionManager CooperacionManager => new CooperacionManager(new CooperacionValidator());

        public static CooperacionesDeCiudadanoManager cooperacionesDeCiudadanoManager => new CooperacionesDeCiudadanoManager(new CooperacionesDeCiudadanoValidator());

        public static DocumentoManager DocumentoManager => new DocumentoManager(new DocumentoValidator());

        public static DocumentoSolicitadoManager DocumentoSolicitadoManager => new DocumentoSolicitadoManager(new DocumentoSolicitadoValidator());

        public static GastoManager GastoManager => new GastoManager(new GastoValidator());

        public static SeccionManager SeccionManager => new SeccionManager(new SeccionValidator());

        public static TipoUsuarioManager TipoUsuarioManager => new TipoUsuarioManager(new TipoUsuarioValidator());

        public static InfoDelegacionManager InfoDelegacionManager => new InfoDelegacionManager(new InfoDelegacionValidador());


    }
}
