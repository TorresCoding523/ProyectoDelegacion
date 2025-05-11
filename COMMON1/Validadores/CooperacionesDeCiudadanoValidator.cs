using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Validadores
{
	public class CooperacionesDeCiudadanoValidator:CamposControlValidator<CooperacionesDeCiudadano>
	{
		public CooperacionesDeCiudadanoValidator()
		{
			RuleFor(c => c.IdCiudadano).NotEmpty();
			RuleFor(c => c.IdCooperacion).NotEmpty();
			RuleFor(c=>c.FechaDePago).NotEmpty();
			RuleFor(c=>c.FechaDePago).NotEmpty();
			RuleFor(c=>c.idUsuarioReceptor).NotEmpty();
			RuleFor(c=>c.Notas).MaximumLength(500);
		}
	}
}
