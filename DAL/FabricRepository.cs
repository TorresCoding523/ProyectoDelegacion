using COMMON.Entidades;
using COMMON.Interfaces;
using COMMON.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class FabricRepository
	{
		private string _cadenaConexion;
		private TipoBD _tipo;

		public FabricRepository(string cadenaConexion, TipoBD tipo)
		{
			_cadenaConexion = cadenaConexion;
			_tipo = tipo;
		}

		public IDB<Aviso> AvisoRepository()
		{
			switch (_tipo)
			{
				case TipoBD.SQLServer:
					return new DBSqlServer<Aviso>(_cadenaConexion, new AvisoValidator(), "IdAviso", true);
				case TipoBD.MySql:
					return new DBMySql<Aviso>(_cadenaConexion, new AvisoValidator(), "IdAviso", true);
				default:
					return null;
			}
			
		}
		public IDB<Ciudadano> CiudadanoRepository()
		{
			switch (_tipo)
			{
				case TipoBD.SQLServer:
					return new DBSqlServer<Ciudadano>(_cadenaConexion, new CuidadanoValidator(), "IdCiudadano", false);
				case TipoBD.MySql:
					return new DBMySql<Ciudadano>(_cadenaConexion, new CuidadanoValidator(), "IdCiudadano", false);
				default:
					return null;
			}
		}
		public IDB<Cooperacion> CooperacionRepository()
		{
			switch (_tipo)
			{
				case TipoBD.SQLServer:
					return new DBSqlServer<Cooperacion>(_cadenaConexion, new CooperacionValidator(), "IdCooperacion", true);
				case TipoBD.MySql:
					return new DBMySql<Cooperacion>(_cadenaConexion, new CooperacionValidator(), "IdCooperacion", true);
				default:
					return null;
			}
		}
		public IDB<CooperacionesDeCiudadano> CooperacionesDeCiudadanoRepository()
		{
			switch (_tipo)
			{
				case TipoBD.SQLServer:
					return new DBSqlServer<CooperacionesDeCiudadano>(_cadenaConexion, new CooperacionesDeCiudadanoValidator(), "Id", true);
				case TipoBD.MySql:
					return new DBMySql<CooperacionesDeCiudadano>(_cadenaConexion, new CooperacionesDeCiudadanoValidator(), "Id", true);
				default:
					return null;
			}
		}
		public IDB<Documento> DocumentoRepository()
		{
			switch (_tipo)
			{
				case TipoBD.SQLServer:
					return new DBSqlServer<Documento>(_cadenaConexion, new DocumentoValidator(), "IdDocumento", true);
				case TipoBD.MySql:
					return new DBMySql<Documento>(_cadenaConexion, new DocumentoValidator(), "IdDocumento", true);
				default:
					return null;
			}
		}
		public IDB<DocumentoSolicitado> DocumentoSolicitadoRepository()
		{
			switch (_tipo)
			{
				case TipoBD.SQLServer:
					return new DBSqlServer<DocumentoSolicitado>(_cadenaConexion, new DocumentoSolicitadoValidator(), "IdDocumentoSolicitado", true);
				case TipoBD.MySql:
					return new DBMySql<DocumentoSolicitado>(_cadenaConexion, new DocumentoSolicitadoValidator(), "IdDocumentoSolicitado", true);
				default:
					return null;
			}
		}
		public IDB<Gasto> GastoRepository()
		{
			switch (_tipo)
			{
				case TipoBD.SQLServer:
					return new DBSqlServer<Gasto>(_cadenaConexion, new GastoValidator(), "IdGasto", true);
				case TipoBD.MySql:
					return new DBMySql<Gasto>(_cadenaConexion, new GastoValidator(), "IdGasto", true);
				default:
					return null;
			}
		}
		public IDB<Seccion> SeccionRepository()
		{
			switch (_tipo)
			{
				case TipoBD.SQLServer:
					return new DBSqlServer<Seccion>(_cadenaConexion, new SeccionValidator(), "IdSeccion", true);
				case TipoBD.MySql:
					return new DBMySql<Seccion>(_cadenaConexion, new SeccionValidator(), "IdSeccion", true);
				default:
					return null;
			}
		}
		
		public IDB<TipoUsuario> TipoUsuarioRepository()
		{
			switch (_tipo)
			{
				case TipoBD.SQLServer:
					return new DBSqlServer<TipoUsuario>(_cadenaConexion, new TipoUsuarioValidator(), "IdTipoUsuario", true);
				case TipoBD.MySql:
					return new DBMySql<TipoUsuario>(_cadenaConexion, new TipoUsuarioValidator(), "IdTipoUsuario", true);
				default:
					return null;
			}
		}

	}
	public enum TipoBD
	{
		SQLServer,
		MySql,
		Oracle
	}
}
