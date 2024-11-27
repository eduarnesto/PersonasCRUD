using PersonasCRUDMaui.ViewModels;

namespace PersonasCRUDMaui.Views;

public partial class ListadoPersonas : ContentPage
{
    Boolean appeared = false;

    public ListadoPersonas()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Función que recarga el listado cuando aparece la vista, ignorando la primera vez
    /// que se carga
    /// <br></br>
    /// Pre: ninguna
    /// <br></br>
    /// Post: ninguna
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (!appeared)
        {
            appeared = true;
        }
        else
        {
            ClsListadoPersonaVM miVM = this.BindingContext as ClsListadoPersonaVM;
            miVM.cargarListado();
        }
    }
}