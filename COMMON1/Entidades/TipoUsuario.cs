using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMMON1.Entidades;

namespace COMMON.Entidades
{
    public class TipoUsuario:CamposControl
    {
        public int IdTipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Notas { get; set; }
        //public bool EsAdministrador { get; set; }
    }
}
