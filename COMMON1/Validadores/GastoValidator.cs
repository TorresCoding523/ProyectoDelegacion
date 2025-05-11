using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Validadores
{
	public class GastoValidator:CamposControlValidator<Gasto>
	{
		public GastoValidator() 
		{
			RuleFor(g => g.FechaGasto).NotEmpty();
			RuleFor(g => g.Descripcion).NotEmpty().MaximumLength(150);
			RuleFor(g => g.Monto).NotEmpty().GreaterThan(0);
			RuleFor(g => g.IdUsuarioAutorizado).NotEmpty();
		}
	}
}
