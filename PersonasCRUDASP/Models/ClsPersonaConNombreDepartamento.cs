using BL;
using DAL;
using ENT;

namespace PersonasCRUDASP.Models
{
    public class ClsPersonaConNombreDepartamento: ClsPersona
    {
        #region Atributos
        public string nombreDepartamento { get; set; }
        #endregion


        #region Constructores

        public ClsPersonaConNombreDepartamento(ClsPersona persona)
        {
            this.id = persona.id;
            this.nombre = persona.nombre;
            this.apellidos = persona.apellidos;
            this.telefono = persona.telefono;
            this.direccion = persona.direccion;
            this.foto = persona.foto;
            this.fechaNacimiento = persona.fechaNacimiento;
            this.idDepartamento = persona.idDepartamento;

            string dep = ClsManejadoraBL.buscarDepartamentoPorId(idDepartamento).nombre;

            if (dep != null)
            {
                this.nombreDepartamento = dep;
            }
        }

        public ClsPersonaConNombreDepartamento(int idPersona)
        {
            ClsPersona persona = ClsManejadoraDAL.buscarPersonaPorId(idPersona);

            if (persona != null)
            {
                this.id = persona.id;
                this.nombre = persona.nombre;
                this.apellidos = persona.apellidos;
                this.telefono = persona.telefono;
                this.direccion = persona.direccion;
                this.foto = persona.foto;
                this.fechaNacimiento = persona.fechaNacimiento;
                this.idDepartamento = persona.idDepartamento;

                string dep = ClsManejadoraBL.buscarDepartamentoPorId(idDepartamento).nombre;

                if (dep != null)
                {
                    this.nombreDepartamento = dep;
                }
            }

        }
        #endregion
    }
}
