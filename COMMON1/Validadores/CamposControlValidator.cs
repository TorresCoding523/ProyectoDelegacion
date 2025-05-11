using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMMON1.Entidades;
using FluentValidation;

namespace COMMON.Validadores
{
    public class CamposControlValidator<T>:AbstractValidator<T> where T: CamposControl
    {
        public CamposControlValidator()
        {
            RuleFor(c=>c.FechaAlta).NotEmpty().GreaterThanOrEqualTo(new DateTime(2025,1,1));
            RuleFor(c=>c.UsuarioAlta).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(c=>c.UsuarioMod).MaximumLength(50);

        }
    }
}
