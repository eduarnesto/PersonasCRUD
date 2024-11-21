using ENT;

namespace PersonasCRUDASP.Models
{
    public class ClsPersonaConNombreDepartamento
    {
        #region Propiedades
        public ClsPersona persona { get; set; }
        public int id { get; set; }
        public string nombre { get; set; }
        #endregion


        #region constructores
        public ClsPersonaConNombreDepartamento()
        {

        }

        public ClsPersonaConNombreDepartamento(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        #endregion
    }
}
