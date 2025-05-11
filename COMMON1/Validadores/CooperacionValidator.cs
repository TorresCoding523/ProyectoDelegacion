using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Validadores
{
	public class CooperacionValidator:CamposControlValidator<Cooperacion>
	{
		public CooperacionValidator() 
		{
			RuleFor(c => c.Nombre).NotEmpty().MaximumLength(50);
			RuleFor(c => c.Descripcion).NotEmpty().MaximumLength(500);
			RuleFor(c => c.Monto).NotEmpty();
            RuleFor(c => c.FechaDeInicio).NotEmpty();
            RuleFor(c => c.FechaLimiteDePago).NotEmpty();

        }
    }
}
