using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Validadores
{
	public class AvisoValidator:CamposControlValidator<Aviso>
	{
		public AvisoValidator()
		{
            RuleFor(a => a.Titulo).NotEmpty().MaximumLength(50).MinimumLength(5);
            RuleFor(a=>a.Texto).NotEmpty().MaximumLength(500).MinimumLength(5);
			RuleFor(a=>a.Fecha).NotEmpty().GreaterThanOrEqualTo(new DateTime(2025,1,1));
			RuleFor(a=>a.IdCuidadanoResponsable).NotEmpty();
			
		}
	}
}
