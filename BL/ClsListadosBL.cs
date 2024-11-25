using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClsListadosBL
    {
        /// <summary>
        /// Devuelve un listado de todas las personas
        /// </summary>
        /// <returns></returns>
        public static List<ClsPersona> ListadoCompletoPersonasBL()
        {
            return ClsListadosDAL.ListadoCompletoPersonasDAL();
        }

        /// <summary>
        /// Devuelve un listado de todos los departamentos
        /// </summary>
        /// <returns></returns>
        public static List<ClsDepartamento> ListadoCompletoDepartamentosBL()
        {
            return ClsListadosDAL.ListadoCompletoDepartamentosDAL();
        }
    }
}
