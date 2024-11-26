using BL;
using ENT;
using PersonasCRUDMaui.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PersonasCRUDMaui.ViewModels
{
    public class ClsListadoPersonaVM: INotifyPropertyChanged
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
        public ClsListadoPersonaVM()
        {
            List<ClsPersona> personas = ClsListadosBL.ListadoCompletoPersonasBL();
            personasConNombreDept = new List<ClsPersonaConNombreDepartamento>();

            foreach (ClsPersona persona in personas)
            {
                ClsPersonaConNombreDepartamento personaNombreDept = new ClsPersonaConNombreDepartamento(persona.id);
                personasConNombreDept.Add(personaNombreDept);
            }
        }
        #endregion

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new
            PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
