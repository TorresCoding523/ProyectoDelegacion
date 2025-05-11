using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Validadores
{
	public class DocumentoValidator:CamposControlValidator<Documento>
	{
		public DocumentoValidator() 
		{
			RuleFor(d => d.Nombre).NotEmpty().MaximumLength(150);
			RuleFor(d => d.Costo).NotEmpty().GreaterThan(20);
			RuleFor(d => d.URLPlantilla).NotEmpty().MaximumLength(250);
		}
	}
}
