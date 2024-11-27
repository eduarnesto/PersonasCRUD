using ENT;
using BL;

namespace PersonasCRUDMaui.Models;

public class ClsPersonaConNombreDepartamento : ClsPersona
{
    #region Atributos
        private string nombreDept;
        #endregion

        #region Propiedades
        public string NombreDept { get { return nombreDept; } }
        #endregion

        #region Constructores
        public ClsPersonaConNombreDepartamento(ClsPersona persona, List<ClsDepartamento> listaDepartamentos)
        {
            if (persona != null)
            {
                id = persona.id;
                nombre = persona.nombre;
                apellidos = persona.apellidos;
                telefono = persona.telefono;
                direccion = persona.direccion;
                foto = persona.foto;
                fechaNacimiento = persona.fechaNacimiento;
                idDepartamento = persona.idDepartamento;

                nombreDept = listaDepartamentos.First(dep => dep.id == persona.idDepartamento).nombre;
            }
        }
        #endregion
}