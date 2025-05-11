﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMMON1.Entidades;

namespace COMMON1.Entidades
{
    public abstract class CamposControl
    {
        public string UsuarioAlta { get; set; }
        public string UsuarioMod { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaMod { get; set; }
    }
}
