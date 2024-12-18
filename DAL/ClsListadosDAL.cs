﻿using Microsoft.Data.SqlClient;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsListadosDAL
    {
        /// <summary>
        /// Devuelve un listado completo de las personas
        /// </summary>
        public static List<ClsPersona> ListadoCompletoPersonasDAL()
        {


            SqlConnection miConexion = new SqlConnection();

            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona;

            try
            {
                miConexion = ClsConnection.getConexion();
                miComando.CommandText = "SELECT * FROM personas";
                miComando.Connection = miConexion;
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
                        listadoPersonas.Add(oPersona);
                    }
                }
                miLector.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                miConexion.Close();
            }

            return listadoPersonas;
        }

        /// <summary>
        /// Devuelve un listado completo de los departamentos
        /// </summary>
        public static List<ClsDepartamento> ListadoCompletoDepartamentosDAL()
        {


            SqlConnection miConexion = new SqlConnection();

            List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsDepartamento oDepartamento;

            try
            {
                miConexion = ClsConnection.getConexion();
                miComando.CommandText = "SELECT * FROM departamentos";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oDepartamento = new ClsDepartamento();
                        oDepartamento.id = (int)miLector["ID"];
                        oDepartamento.nombre = (string)miLector["Nombre"];
                        listadoDepartamentos.Add(oDepartamento);
                    }
                }
                miLector.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                miConexion.Close();
            }

            return listadoDepartamentos;
        }

    }
}
