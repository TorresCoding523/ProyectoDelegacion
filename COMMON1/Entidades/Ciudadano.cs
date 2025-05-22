using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMMON1.Entidades;

namespace COMMON.Entidades
{
    public class Ciudadano:CamposControl
    {
		public string IdCiudadano { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Habilitado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int IdSeccion { get; set; }
        public string Direccion { get; set; }
        public string NoCasa { get; set; }
        public string Sexo { get; set; }
        public bool EstaEnUSA { get; set; }
        public string TelefonoCasa { get; set; }
        public string TelefonoCelular { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public string URLFoto { get; set; }
        public string URLFotoFachada { get; set; }
        public DateTime FechaUltimoIngreso { get; set; }
        public string Notas { get; set; }
        public bool EsAdministrador { get; set; }
    }
}
