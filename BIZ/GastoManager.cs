using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class GastoManager : GenericManager<Gasto>
    {
        public GastoManager(AbstractValidator<Gasto> validator) : base(validator)
        {
        }
    }
}
