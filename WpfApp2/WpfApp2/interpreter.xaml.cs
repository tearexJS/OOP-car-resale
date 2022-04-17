using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for interpreter.xaml
    /// </summary>
    public partial class interpreter : UserControl, INotifyPropertyChanged
    {
        private SolidColorBrush _color;
        public SolidColorBrush color
        {
            get { return _color; }
            set
            {
                _color = value;
                NotifyPropertyChanged();
            }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        private string _info;
        public string info
        {
            get { return _info; }
            set
            {
                _info = value;
                NotifyPropertyChanged();
            }
        }
        public interpreter(SolidColorBrush color, string name, string info)
        {
            InitializeComponent();
            DataContext = this; //Vsechny hodnoty jsou nabindovany a tohle jen oznamuje, do jake tridy se ma program divat pro ten binding
            this.color = color; //Pokazde, kdyz se zmeni hodnota se zavola notifypropertychanged a binding pak uz resim v xaml
            this.name = name;
            this.info = info;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
