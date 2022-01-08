using settings_saver.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace settings_saver.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject, ICloseableWindow
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand AppsViewCommand { get; set; }

        private RelayCommand _closeCommand;
        public RelayCommand CloseCommand 
        { 
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(o => { CloseWindow(); });
                return _closeCommand;
            }
        }

        void CloseWindow()
        {
            Close?.Invoke();
        }

        public HomeViewModel HomeView { get; set; }

        public AppsViewModel AppsView { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public Action Close { get; set; }

        public MainViewModel()
        {
            HomeView = new HomeViewModel();
            AppsView = new AppsViewModel();

            CurrentView = HomeView;

            HomeViewCommand = new RelayCommand(o => { CurrentView = HomeView; });
            AppsViewCommand = new RelayCommand(o => { CurrentView = AppsView; });
        }
    }

    interface ICloseableWindow
    {
        Action Close { get; set; }
    }
}
