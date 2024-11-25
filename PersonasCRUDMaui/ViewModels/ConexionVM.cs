using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasCRUDMaui.ViewModels
{
    public class ConexionVM
    {

    }

    private async void EditarCommand_Executed()
    {
        Dictionary<String, object> diccionarioMandar = new Dictionary<string, object>();
        diccionarioMandar.Add("Persona", personaSeleccionada);
        await Shell.Current.GoToAsync("DetallePersona", diccionarioMandar);
    }

    private void DeleteCommand_Executed()
    {

    }
}
