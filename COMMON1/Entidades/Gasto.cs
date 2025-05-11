using COMMON1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Entidades
{
	public class Gasto:CamposControl
	{
		public int IdGasto { get; set; }
		public DateTime FechaGasto { get; set; }
		public string Descripcion { get; set; }
		public decimal Monto { get; set; }
		public string IdUsuarioAutorizado { get; set; }
	}
}
