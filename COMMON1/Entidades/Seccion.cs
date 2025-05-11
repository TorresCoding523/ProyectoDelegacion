using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMMON1.Entidades;

namespace COMMON.Entidades
{
    public class Seccion: CamposControl
    {
        public int IdSeccion { get; set; }
        public string Nombre { get; set; }
        public string Notas { get; set; }
    }
}
