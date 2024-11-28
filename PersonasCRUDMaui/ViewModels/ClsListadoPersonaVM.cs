using BL;
using CommunityToolkit.Maui.Alerts;
using ENT;
using PersonasCRUDMaui.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core;
using PersonasCRUDMaui.ViewModels.Utils;

namespace PersonasCRUDMaui.ViewModels
{
    public class ClsListadoPersonaVM: INotifyPropertyChanged
    {
        #region Atributos
        private ClsPersonaConNombreDepartamento? personaSeleccionada;
        private ObservableCollection<ClsPersonaConNombreDepartamento> listadoPersonasNombreDept;
        private List<ClsPersona> listadoPersonas;
        private DelegateCommand detallesCommand;
        private DelegateCommand insertarCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand borrarCommand;
        private bool showError;
        private bool showContent;
        private string error;
        #endregion

        #region Propiedades
        public ClsPersonaConNombreDepartamento PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                if (value != null)
                {

                    personaSeleccionada = value;


                    NotifyPropertyChanged("PersonaSeleccionada");
                    editarCommand.RaiseCanExecuteChanged();
                    borrarCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public ObservableCollection<ClsPersonaConNombreDepartamento> ListadoPersonasNombreDept
        {
            get { return listadoPersonasNombreDept; }
        }
        public DelegateCommand DetallesCommand
        {
            get { return detallesCommand; }
        }
        public DelegateCommand InsertarCommand
        {
            get { return insertarCommand; }
        }
        public DelegateCommand EditarCommand
        {
            get { return editarCommand; }
        }
        public DelegateCommand BorrarCommand
        {
            get { return borrarCommand; }
        }
        public bool ShowError
        {
            get { return showError; }
        }
        public bool ShowContent
        {
            get { return !showError; }
        }
        public string Error
        {
            get { return error; }
        }
        #endregion

        #region Constructores
        public ClsListadoPersonaVM()
        {
            cargarListado();
            detallesCommand = new DelegateCommand(detallesCommandExecuted);
            insertarCommand = new DelegateCommand(insertarCommandExecuted);
            editarCommand = new DelegateCommand(editarCommandExecuted, editarCommandCanExecute);
            borrarCommand = new DelegateCommand(borrarCommandExecuted, borrarCommandCanExecute);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Función que carga el listado de la base de datos,
        /// le añade el nombre de departamento a las personas y las 
        /// añade al listado final.
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        public async void cargarListado()
        {
            if (listadoPersonas != null && listadoPersonas.Count > 0)
            {
                listadoPersonas.Clear();
            }

            try
            {
                listadoPersonas = ClsListadosBL.ListadoCompletoPersonasBL();
                listadoPersonasNombreDept = new ObservableCollection<ClsPersonaConNombreDepartamento>();

                // se crea una lista de departamentos
                List<ClsDepartamento> listaDept = ClsListadosBL.ListadoCompletoDepartamentosBL();

                foreach (ClsPersona persona in listadoPersonas)
                {
                    ClsPersonaConNombreDepartamento personaNombreDept = new ClsPersonaConNombreDepartamento(persona, listaDept);
                    listadoPersonasNombreDept.Add(personaNombreDept);
                }

                NotifyPropertyChanged("ListadoPersonasNombreDept");
            }
            catch (Exception e)
            {
                showError = true;
                error = "No se ha podido cargar el listado";
                NotifyPropertyChanged("ShowError");
                NotifyPropertyChanged("Error");
            }
        }
        #endregion

        #region Comandos
        /// <summary>
        /// Función que va a la pantalla de detalles de la persona
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        public async void detallesCommandExecuted()
        {
            await Shell.Current.GoToAsync("///DetallesPersona");
        }

        /// <summary>
        /// Función que va a la pantalla insertar
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        public async void insertarCommandExecuted()
        {
            await Shell.Current.GoToAsync("///insertarPersona");
        }

        /// <summary>
        /// Función que va a la pantalla editar
        /// <br></br>
        /// Pre: Persona no null
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        public async void editarCommandExecuted()
        {
            if (personaSeleccionada != null)
            {
                ClsPersona persona = ClsManejadoraBL.buscarPersonaPorId(personaSeleccionada.id);
                var queryParams = new Dictionary<string, object>
                {
                    { "persona", persona}
                };

                await Shell.Current.GoToAsync("///EditarPersona", queryParams);
            }
        }

        /// <summary>
        /// Función que comprueba cuando puede mostrarse el command
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        /// <returns>Devuelve si puede mostrarse o no</returns>
        public bool editarCommandCanExecute()
        {
            bool canExecute = false;

            if (personaSeleccionada != null)
            {
                canExecute = true;
            }

            return canExecute;
        }

        /// <summary>
        /// Función que elimina a una persona de la BD
        /// <br></br>
        /// Pre: Persona no null
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        public async void borrarCommandExecuted()
        {
            // Mostrar un cuadro de confirmación
            bool isConfirmed = await Application.Current.MainPage.DisplayAlert(
                "Confirmar Borrado",
                "¿Estás seguro de que deseas borrar a " + personaSeleccionada.nombre + "?",
                "Sí",
                "No");

            // Si el usuario confirma, ejecutar la lógica de borrado
            if (isConfirmed)
            {
                try
                {
                    int lineas = ClsManejadoraBL.eliminarPersona(personaSeleccionada.id);

                    if (lineas > 0)
                    {
                        listadoPersonasNombreDept.Remove(PersonaSeleccionada);
                        NotifyPropertyChanged("ListadoPersonasNombreDept");
                        CancellationTokenSource token = new CancellationTokenSource();
                        var toast = Toast.Make(PersonaSeleccionada.nombre + " eliminado correctamente", ToastDuration.Short, 14);
                        personaSeleccionada = null;
                        editarCommand.RaiseCanExecuteChanged();
                        borrarCommand.RaiseCanExecuteChanged();
                        await toast.Show(token.Token);
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Ha ocurrido un error", "OK");
                }
            }
        }

        /// <summary>
        /// Función que comprueba cuando puede mostrarse el command
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        /// <returns>Devuelve si puede mostrarse o no</returns>
        public bool borrarCommandCanExecute()
        {
            bool canExecute = false;

            if (personaSeleccionada != null)
            {
                canExecute = true;
            }

            return canExecute;
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
