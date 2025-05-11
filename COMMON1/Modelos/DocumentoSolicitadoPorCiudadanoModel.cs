using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Modelos
{
    public class DocumentoSolicitadoPorCiudadanoModel
    {
        public string IdCiudadanoSolicitante { get; set; }
        public int IdDocumentoSolicitante { get; set; }
        public string Documento { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaDePago { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal Costo { get; set; }
    }
}
