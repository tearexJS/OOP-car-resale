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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        List<infoHolder> items = new List<infoHolder>();    //Bude ti drzet veskery informace o produktech
        List<string> lon = new List<string>() { "name1", "name2", "name3", "name4", "name5", "name6", "name7" }; //tohle je jen pro naplneni tech dat
        List<SolidColorBrush> colors = new List<SolidColorBrush>() { new SolidColorBrush(Colors.Red), new SolidColorBrush(Colors.Blue), new SolidColorBrush(Colors.Orange), new SolidColorBrush(Colors.Yellow) }; //tohle je jen pro naplneni tech dat
        public MainWindow()
        {
            for (int i = 0; i < 5; i++) //zmen i < ... a muzes si tak vykreslit vicemene jakykoliv pocet tech "produktu"
            {
                items.Add(new infoHolder {name = lon[i % lon.Count], color = colors[i % colors.Count], info = $"info info {i}"});
            } //Naplneni dat
            InitializeComponent();
            for (int i = 0; i < items.Count; i++)
            {
                interpreter intp = new interpreter(items[i].color, items[i].name, items[i].info);
                panel.Children.Add(intp);
                NotifyPropertyChanged();
            } //Vytvoreni nove instance produktu a vlozeni informaci z infoHolderu do vizualniho interpreteru
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged; //Tyhle dve funkce na konci opis, to oznamuje gui, ze se neco zmenilo a ze se ma updatovat

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
