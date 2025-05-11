using COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class DocumentoManager : GenericManager<Documento>
    {
        public DocumentoManager(AbstractValidator<Documento> validator) : base(validator)
        {
        }
    }
}
