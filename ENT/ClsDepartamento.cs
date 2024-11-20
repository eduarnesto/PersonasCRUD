using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsDepartamento
    {
        #region Propiedades
        public int id { get; set; }
        public string nombre { get; set; }
        #endregion


        #region constructores
        public ClsDepartamento()
        {

        }

        public ClsDepartamento(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        #endregion
    }
}
