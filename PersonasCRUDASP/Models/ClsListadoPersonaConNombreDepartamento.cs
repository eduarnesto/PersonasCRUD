using BL;
using ENT;

namespace PersonasCRUDASP.Models
{
    public class ClsListadoPersonaConNombreDepartamento
    {
        #region Atributos
        private List<ClsPersonaConNombreDepartamento> personasConNombreDept;
        #endregion

        #region Propiedades
        public List<ClsPersonaConNombreDepartamento> PersonasConNombreDept
        {
            get { return personasConNombreDept; }
        }
        #endregion

        #region Constructores
        public ClsListadoPersonaConNombreDepartamento()
        {
            List<ClsPersona> personas = ClsListadosBL.ListadoCompletoPersonasBL();
            personasConNombreDept = new List<ClsPersonaConNombreDepartamento>();

            foreach (ClsPersona persona in personas)
            {
                ClsPersonaConNombreDepartamento personaNombreDept = new ClsPersonaConNombreDepartamento(persona);
                personasConNombreDept.Add(personaNombreDept);
            }
        }
        #endregion
    }
}
