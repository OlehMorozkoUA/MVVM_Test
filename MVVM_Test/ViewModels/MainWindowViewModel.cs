using MVVM_Test.Infrastructure.Commands;
using MVVM_Test.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Test.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Header of window
        private string _title = "Analysing of statistic";

        /// <summary>
        /// Title for window
        /// </summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion

        #region Status of window
        private string _status = "Complete!";

        /// <summary>
        /// Status for window
        /// </summary>
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        #endregion

        #region Cammands

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private void onCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool canCloseApplicationCommand(object p) => true;
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Commands

            CloseApplicationCommand = new LambdaCommand(onCloseApplicationCommandExecuted, canCloseApplicationCommand);

            #endregion
        }
    }
}
