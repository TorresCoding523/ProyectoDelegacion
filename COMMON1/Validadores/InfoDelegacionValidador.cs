using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Validadores
{
    public class InfoDelegacionValidador: CamposControlValidator<InfoDelegacion>
    {
        public InfoDelegacionValidador()
        {
            RuleFor(j => j.Nombre).NotEmpty().MaximumLength(225);
            RuleFor(j => j.Descripcion).NotEmpty().MaximumLength(225);
            RuleFor(j => j.Direccion).NotEmpty().MaximumLength(225);
            RuleFor(j => j.Telefono).NotEmpty().MaximumLength(20);
            RuleFor(j => j.Correo).NotEmpty().MaximumLength(100);
        }
    }
}
