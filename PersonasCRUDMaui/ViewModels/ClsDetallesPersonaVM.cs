using ENT;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BL;
using PersonasCRUDMaui.ViewModels.Utils;

namespace PersonasCRUDMaui.ViewModels
{
    [QueryProperty(nameof(Persona), "persona")]
    public class ClsDetallesPersonaVM: INotifyPropertyChanged
    {
        #region Atributos
        private ClsPersona persona;
        private DelegateCommand volverCommand;
        private String error;
        private bool showError;
        private bool showContent;
        private string nombreDept;
        #endregion

        #region Propiedades
        public ClsPersona Persona
        {
            get { return persona; }
        }

        public DelegateCommand VolverCommand
        {
            get { return volverCommand; }
        }

        public string Error
        {
            get { return error; }
        }

        public bool ShowError
        {
            get { return showError; }
        }

        public bool ShowContent
        {
            get { return !showError; }
        }

        public string NombreDept
        {
            get { return nombreDept; }
        }
        #endregion

        #region Constructores
        public ClsDetallesPersonaVM()
        {
            volverCommand = new DelegateCommand(volverCommandExecuted);
        }
        #endregion

        #region Commands
        /// <summary>
        /// Función que vuelve al listado
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        public async void volverCommandExecuted()
        {
            await Shell.Current.GoToAsync("///ListadoPersonas");
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
