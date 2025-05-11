﻿using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class AvisoManager : GenericManager<Aviso>
    {
        public AvisoManager(AbstractValidator<Aviso> validator) : base(validator)
        {
        }
    }
}
