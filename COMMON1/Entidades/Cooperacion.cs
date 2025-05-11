﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMMON1.Entidades;

namespace COMMON.Entidades
{
    public class Cooperacion:CamposControl
    {
        public int IdCooperacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaLimiteDePago { get; set; }
    }
}
