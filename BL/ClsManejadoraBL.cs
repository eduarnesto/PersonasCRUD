﻿using DAL;
using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClsManejadoraBL
    {
        public static ClsPersona buscarPersonaPorId(int id)
        {
            return ClsManejadoraDAL.buscarPersonaPorId(id);
        }

        /// <summary>
        /// Elimina una persona de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int eliminarPersona(int id)
        {
            return ClsManejadoraDAL.eliminarPersona(id);
        }

        /// <summary>
        /// Modifica una persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int modificarPersona(ClsPersona persona)
        {
            return ClsManejadoraDAL.modificarPersona(persona);
        }

        /// <summary>
        /// Modifica una persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int agregarPersona(ClsPersona persona)
        {
            return ClsManejadoraDAL.agregarPersona(persona);
        }
    }
}