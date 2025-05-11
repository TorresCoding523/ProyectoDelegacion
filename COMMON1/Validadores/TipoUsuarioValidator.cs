using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMMON.Entidades;
using FluentValidation;


namespace COMMON.Validadores
{
    public class TipoUsuarioValidator:CamposControlValidator<TipoUsuario>
    {
        public TipoUsuarioValidator() 
        {
            RuleFor(t => t.IdTipoUsuario).NotEmpty();
            RuleFor(t => t.Nombre).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(t => t.Notas).MaximumLength(500);
           
        }
    }
}
