using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMMON1.Entidades;

namespace COMMON.Entidades
{
    public class Aviso:CamposControl
    {
        public int IdAviso { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public string IdCuidadanoResponsable { get; set; }
    }
}
