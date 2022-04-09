using GUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.MWM.ViewModel
{

    class MainViewModel : ObservableObject
    {

        public RelayComand HomeViewCommand { get; set; }
        public RelayComand MyAdvertViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }

        public MyAdvertViewModel MyAdvertVM { get; set; }

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

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            MyAdvertVM = new MyAdvertViewModel();
            CurrentView = HomeVM;
            HomeViewCommand = new RelayComand(o =>
            {
                CurrentView = HomeVM;
            });

            MyAdvertViewCommand = new RelayComand(o =>
            {
                CurrentView = MyAdvertVM;
            });
        }
    
    }
}
