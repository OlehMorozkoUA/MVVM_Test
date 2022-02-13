using MVVM_Test.Infrastructure.Commands;
using MVVM_Test.Models;
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
        #region SelectedPageIndex : int - number of choosed tab
        /// <summary>
        /// Number of choosed tab
        /// </summary>
        private int _selectedPageIndex;
        /// <summary>
        /// Number of choosed tab
        /// </summary>
        public int SelectedPageIndex
        {
            get => _selectedPageIndex;
            set => Set(ref _selectedPageIndex, value);
        }
        #endregion

        #region TestDataPoint
        /// <summary>
        /// Test data
        /// </summary>
        private IEnumerable<DataPoint> _testDataPoints;
        /// <summary>
        /// Test data
        /// </summary>
        public IEnumerable<DataPoint> TestDataPoints
        {
            get => _testDataPoints;
            set => Set(ref _testDataPoints, value);
        }
        #endregion

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

        public ICommand ChangeTabIndexCommand { get; }

        private bool canChangeTabIndexCommandExecute(object p) => _selectedPageIndex >= 0;

        private void onChangeTabIndexCommandExecute(object p)
        {
            if (p is null) return;

            SelectedPageIndex += Convert.ToInt32(p);
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Commands

            CloseApplicationCommand = new LambdaCommand(onCloseApplicationCommandExecuted, canCloseApplicationCommand);
            ChangeTabIndexCommand = new LambdaCommand(onChangeTabIndexCommandExecute, canChangeTabIndexCommandExecute);

            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }

            TestDataPoints = data_points;
        }
    }
}
