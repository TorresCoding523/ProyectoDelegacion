using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class TipoUsuarioManager : GenericManager<TipoUsuario>
    {
        public TipoUsuarioManager(AbstractValidator<TipoUsuario> validator) : base(validator)
        {
        }

        public override async Task<TipoUsuario> Agregar(TipoUsuario entidad)
        {
            try
            {
                var tipoUsuarios = await ObtenerTodos(); // 👈 Usa el nombre real del método aquí

                int nuevoId = (tipoUsuarios?.Any() ?? false) ? tipoUsuarios.Max(s => s.IdTipoUsuario) + 1 : 1;

                entidad.IdTipoUsuario = nuevoId;

                return await base.Agregar(entidad);
            }
            catch (Exception ex)
            {
                Error = $"Error al agregar sección: {ex.Message}";
                return null;
            }
        }
    }
}
