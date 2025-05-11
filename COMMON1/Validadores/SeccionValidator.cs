using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMMON.Entidades;
using FluentValidation;

namespace COMMON.Validadores
{
    public class SeccionValidator:CamposControlValidator<Seccion>
    {
        public SeccionValidator() 
        {
            RuleFor(s => s.IdSeccion).NotEmpty();
            RuleFor(s => s.Nombre).NotEmpty().MinimumLength(5).MaximumLength(100);
            RuleFor(s => s.Notas).MaximumLength(500);
        }
    }
}
