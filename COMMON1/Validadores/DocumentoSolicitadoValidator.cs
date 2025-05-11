using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Validadores
{
	public class DocumentoSolicitadoValidator:CamposControlValidator<DocumentoSolicitado>
	{
		public DocumentoSolicitadoValidator() 
		{
            RuleFor(d => d.IdDocumento).NotEmpty();
            RuleFor(d => d.IdCiudadanoSolicitante).NotEmpty();
            RuleFor(d => d.FechaSolicitud).NotEmpty();
            RuleFor(d => d.FechaEntrega).NotEmpty().When(d => d.FechaEntrega.HasValue);
            RuleFor(d => d.FechaPago).NotEmpty().When(d => d.FechaPago.HasValue);
            RuleFor(d => d.IdUsuarioGenerador).NotEmpty();
            RuleFor(d => d.Finalidad).NotEmpty().MaximumLength(150);
            RuleFor(d => d.Notas).MaximumLength(500);
        }
	}
}
