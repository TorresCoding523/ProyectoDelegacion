using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class SeccionManager : GenericManager<Seccion>
    {
        public SeccionManager(AbstractValidator<Seccion> validator) : base(validator)
        {
        }

        public override async Task<Seccion> Agregar(Seccion entidad)
        {
            try
            {
                var secciones = await ObtenerTodos(); // 👈 Usa el nombre real del método aquí

                int nuevoId = (secciones?.Any() ?? false) ? secciones.Max(s => s.IdSeccion) + 1 : 1;

                entidad.IdSeccion = nuevoId;

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
