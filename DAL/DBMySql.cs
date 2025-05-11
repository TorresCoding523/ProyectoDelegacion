using COMMON;
using COMMON.Interfaces;
using COMMON1.Entidades;
using FluentValidation;
using MySql.Data.MySqlClient; // Importar el conector de MySQL
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DBMySql<T> : IDB<T> where T : CamposControl
    {
        public string Error { get; private set; }
        private string cadenaDeConexion;
        private string campoId;
        private bool esAutonumerico;
        private AbstractValidator<T> validador;

        public DBMySql(string cadenaDeConexion, AbstractValidator<T> validador, string campoId, bool esAutonumerico)
        {
            this.cadenaDeConexion = cadenaDeConexion;
            this.campoId = campoId;
            this.esAutonumerico = esAutonumerico;
            Error = "";
            this.validador = validador;
        }

        public T Actualizar(T entidad)
        {
            Error = "";
            try
            {
                entidad.UsuarioMod = Params.UsuarioConectado;
                entidad.FechaMod = DateTime.Now;
                var resultadoValidacion = validador.Validate(entidad);
                if (resultadoValidacion.IsValid)
                {
                    string sql = $"UPDATE {typeof(T).Name} SET {string.Join(",", entidad.GetType().GetProperties().Where(p => p.Name != campoId)
                        .Select(p => p.Name + "=@" + p.Name))} WHERE {campoId}=@Id";

                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    foreach (var propiedad in entidad.GetType().GetProperties().Where(p => p.Name != campoId))
                    {
                        parametros.Add("@" + propiedad.Name, propiedad.GetValue(entidad));
                    }
                    parametros.Add("@Id", entidad.GetType().GetProperty(campoId).GetValue(entidad));

                    if (EjecutarComando(sql, parametros) == 1)
                    {
                        return entidad;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    Error = string.Join(",", resultadoValidacion.Errors);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public List<M> EjecutarProcedimiento<M>(string nombre, Dictionary<string, string> parametros) where M : class
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaDeConexion)) // Usar MySqlConnection
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(nombre, conexion)) // Usar MySqlCommand
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (var parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                    }
                    var reader = comando.ExecuteReader();
                    List<M> lista = new List<M>();
                    while (reader.Read())
                    {
                        M entidad = Activator.CreateInstance<M>();
                        foreach (var propiedad in entidad.GetType().GetProperties())
                        {
                            propiedad.SetValue(entidad, reader[propiedad.Name]);
                        }
                        lista.Add(entidad);
                    }
                    return lista;
                }
            }
        }

        public bool Eliminar(T entidad)
        {
            Error = "";
            try
            {
                string sql = $"DELETE FROM {typeof(T).Name} WHERE {campoId}=@Id";
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@Id", entidad.GetType().GetProperty(campoId).GetValue(entidad));
                return EjecutarComando(sql, parametros) == 1;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        private int EjecutarComando(string sql, Dictionary<string, object> parametros)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaDeConexion)) // Usar MySqlConnection
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion)) // Usar MySqlCommand
                {
                    foreach (var parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                    }
                    return comando.ExecuteNonQuery();
                }
            }
        }

        public T Insertar(T entidad)
        {
            Error = "";
            try
            {
                entidad.UsuarioAlta = Params.UsuarioConectado;
                entidad.FechaAlta = DateTime.Now;
                var resultadoValidacion = validador.Validate(entidad);
                if (resultadoValidacion.IsValid)
                {
                    string sql;
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    if (esAutonumerico)
                    {
                        sql = $"INSERT INTO {typeof(T).Name} ({string.Join(",", entidad.GetType().GetProperties().Where
                            (p => p.Name != campoId).Select(p => p.Name))}) VALUES ({string.Join(",", entidad.GetType().GetProperties()
                            .Where(p => p.Name != campoId).Select(p => "@" + p.Name))})";

                        foreach (var propiedad in entidad.GetType().GetProperties().Where(p => p.Name != campoId))
                        {
                            parametros.Add("@" + propiedad.Name, propiedad.GetValue(entidad));
                        }
                    }
                    else
                    {
                        sql = $"INSERT INTO {typeof(T).Name} ({string.Join(",", entidad.GetType().GetProperties().Select(p => p.Name))}) " +
                            $"VALUES ({string.Join(",", entidad.GetType().GetProperties().Select(p => "@" + p.Name))})";

                        foreach (var propiedad in entidad.GetType().GetProperties())
                        {
                            parametros.Add("@" + propiedad.Name, propiedad.GetValue(entidad));
                        }
                    }

                    if (EjecutarComando(sql, parametros) == 1)
                    {
                        if (esAutonumerico)
                        {
                            sql = $"SELECT * FROM {typeof(T).Name} WHERE {campoId} = LAST_INSERT_ID()"; // Usar LAST_INSERT_ID() en lugar de SCOPE_IDENTITY()
                            var consulta = EjecutarConsulta(sql, new Dictionary<string, object>());
                            if (consulta.Count == 1)
                            {
                                return consulta.First();
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            return entidad;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    Error = string.Join(",", resultadoValidacion.Errors);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public T ObtenerPorId(int id)
        {
            return ObtenerPorId(id.ToString());
        }

        public T ObtenerPorId(string id)
        {
            try
            {
                string sql = $"SELECT * FROM {typeof(T).Name} WHERE {campoId}=@Id"; // Corregir la sentencia SQL
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@Id", id);
                return EjecutarConsulta(sql, parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return ObtenerPorId(id.ToString());
            }
        }

        public List<T> ObtenerTodos()
        {
            Error = "";
            try
            {
                string sql = $"SELECT * FROM {typeof(T).Name}";
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                return EjecutarConsulta(sql, parametros);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        private List<T> EjecutarConsulta(string sql, Dictionary<string, object> parametros)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaDeConexion)) // Usar MySqlConnection
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion)) // Usar MySqlCommand
                {
                    foreach (var parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                    }
                    var reader = comando.ExecuteReader();
                    List<T> lista = new List<T>();
                    while (reader.Read())
                    {
                        T entidad = Activator.CreateInstance<T>();
                        foreach (var propiedad in entidad.GetType().GetProperties())
                        {
                            //propiedad.SetValue(entidad, reader[propiedad.Name]);
                            var value = reader[propiedad.Name];
                            if (value == DBNull.Value)
                            {
                                value = null;
                            }
                            propiedad.SetValue(entidad, value);
                        }
                        lista.Add(entidad);
                    }
                    return lista;
                }
            }
        }
    }
}
