using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Validadores
{
	public class CuidadanoValidator:CamposControlValidator<Ciudadano>
	{
		public CuidadanoValidator()
		{
			//RuleFor(c => c.IdCiudadano).NotEmpty().MaximumLength(50);
			RuleFor(c => c.IdTipoUsuario).NotEmpty();
			RuleFor(c => c.Email).NotEmpty().EmailAddress();
			RuleFor(c => c.Password).NotEmpty().WithMessage("La contraseña no puede estar vacia").MaximumLength(100);
			//Los bool no se validan
			RuleFor(c => c.Nombre).NotEmpty().MaximumLength(100);
			RuleFor(c => c.Apellidos).NotEmpty().MaximumLength(100);
			RuleFor(c => c.IdSeccion).NotEmpty();
			RuleFor(c => c.Direccion).NotEmpty().MaximumLength(250);
			RuleFor(c => c.NoCasa).NotEmpty();
            RuleFor(c => c.Sexo).NotEmpty().When(c => c.Sexo == "M" || c.Sexo == "F");
            RuleFor(c => c.TelefonoCasa).NotEmpty().MaximumLength(50).MinimumLength(10);
            RuleFor(c=>c.TelefonoCelular).NotEmpty().MaximumLength(50).MinimumLength(10);
			RuleFor(c=>c.Latitud).NotEmpty();
			RuleFor(c=>c.Longitud).NotEmpty();
			RuleFor(c=>c.URLFoto).MaximumLength(250);
			RuleFor(c=>c.URLFotoFachada).MaximumLength(250);
			RuleFor(c=>c.Notas).MaximumLength(500);

		}
	}
}
