﻿using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ClsManejadoraDAL
    {
        /// <summary>
        /// Devuelve una persona de la base de datos segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve una persona vacía si no se encuentra la persona</returns>
        public static ClsPersona buscarPersonaPorId(int id)
        {
            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona = new ClsPersona();

            try
            {
                miConexion = ClsConnection.getConexion();
                miComando.CommandText = "SELECT * FROM personas WHERE ID=@id";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@id", id);
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();
                        oPersona.id = (int)miLector["ID"];
                        oPersona.nombre = (string)miLector["Nombre"];
                        oPersona.apellidos = (string)miLector["Apellidos"];
                        oPersona.foto = (string)miLector["Foto"];
                        if (miLector["FechaNacimiento"] != System.DBNull.Value)
                        {
                            oPersona.fechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        }
                        oPersona.direccion = (string)miLector["Direccion"];
                        oPersona.telefono = (string)miLector["Telefono"];
                        oPersona.idDepartamento = (int)miLector["IDDepartamento"];
                    }
                }
                miLector.Close();
            }
            finally
            {
                miConexion.Close();
            }

            return oPersona;
        }

        /// <summary>
        /// Devuelve una persona de la base de datos segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un departamento vacío si no se encuentra la persona</returns>
        public static ClsDepartamento buscarDepartamentoPorId(int id)
        {
            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsDepartamento oDepartamento = new ClsDepartamento();

            try
            {
                miConexion = ClsConnection.getConexion();
                miComando.CommandText = "SELECT * FROM departamentos WHERE ID=@id";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@id", id);
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oDepartamento = new ClsDepartamento();
                        oDepartamento.id = (int)miLector["ID"];
                        oDepartamento.nombre = (string)miLector["Nombre"];
                    }
                }
                miLector.Close();
            }
            finally
            {
                miConexion.Close();
            }

            return oDepartamento;
        }

        /// <summary>
        /// Devuelve una persona de la base de datos segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un departamento vacío si no se encuentra la persona</returns>
        public static string buscarIdDepartamento(string dept)
        {
            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            string nombre = "";

            try
            {
                miConexion = ClsConnection.getConexion();
                miComando.CommandText = "SELECT id FROM departamentos WHERE Nombre=@nombre";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@nombre", dept);
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        nombre = (string)miLector["Nombre"];
                    }
                }
                miLector.Close();
            }
            finally
            {
                miConexion.Close();
            }

            return nombre;
        }

        /// <summary>
        /// Elimina una persona de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int eliminarPersona(int id)
        {

            int numeroFilasAfectadas;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            try

            {
                miConexion = ClsConnection.getConexion();

                miComando.CommandText = "DELETE FROM Personas WHERE ID=@id";

                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@id", id);

                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }

            catch (Exception ex)

            {
                throw ex;
            }

            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Modifica una persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int modificarPersona(ClsPersona persona)
        {
            int numeroFilasAfectadas;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            try

            {
                miConexion = ClsConnection.getConexion();

                miComando.CommandText = "UPDATE Personas SET Nombre=@nombre, Apellidos=@apellidos, Telefono=@telefono, Direccion=@direccion, FechaNacimiento=@fechaNacimiento, IDDepartamento=@idDepartamento WHERE ID=@id";
                miComando.Connection = miConexion;

                // Agregar los parámetros
                miComando.Parameters.AddWithValue("@nombre", persona.nombre);
                miComando.Parameters.AddWithValue("@apellidos", persona.apellidos);
                miComando.Parameters.AddWithValue("@telefono", persona.telefono);
                miComando.Parameters.AddWithValue("@direccion", persona.direccion);
                miComando.Parameters.AddWithValue("@fechaNacimiento", persona.fechaNacimiento);
                miComando.Parameters.AddWithValue("@id", persona.id);
                miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.idDepartamento;

                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }

            catch (Exception ex)

            {
                throw ex;
            }

            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Modifica una persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int agregarPersona(ClsPersona persona)
        {
            int numeroFilasAfectadas;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            try

            {
                miConexion = ClsConnection.getConexion();

                miComando.CommandText = "INSERT INTO Personas VALUES (@nombre, @apellidos, @telefono, @direccion, @fechaNacimiento, @idDepartamento)";
                miComando.Connection = miConexion;

                // Agregar los parámetros
                miComando.Parameters.AddWithValue("@nombre", persona.nombre);
                miComando.Parameters.AddWithValue("@apellidos", persona.apellidos);
                miComando.Parameters.AddWithValue("@telefono", persona.telefono);
                miComando.Parameters.AddWithValue("@direccion", persona.direccion);
                miComando.Parameters.AddWithValue("@fechaNacimiento", persona.fechaNacimiento);
                miComando.Parameters.AddWithValue("@idDepartamento", persona.idDepartamento);

                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }

            catch (Exception ex)

            {
                throw ex;
            }

            return numeroFilasAfectadas;
        }

    }
}
