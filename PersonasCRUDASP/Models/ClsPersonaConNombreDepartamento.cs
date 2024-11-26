using BL;
using ENT;

namespace PersonasCRUDASP.Models
{
    public class ClsPersonaConNombreDepartamento: ClsPersona
    {
        #region Atributos
        public string nombreDepartamento { get; set; }
        #endregion


        #region Constructores
        public ClsPersonaConNombreDepartamento(int idPersona)
        {
            ClsPersona persona = ClsManejadoraBL.buscarPersonaPorId(idPersona);

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

        public ClsPersonaConNombreDepartamento(ClsPersona persona, List<ClsDepartamento> departamentos)
        {

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

                string dep = departamentos.FirstOrDefault(p => p.id == persona.idDepartamento).nombre;

                if (dep != null)
                {
                    this.nombreDepartamento = dep;
                }
            }

        }
        #endregion
    }
}
