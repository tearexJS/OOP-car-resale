using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestUI.Views;

namespace TestUI.ViewModels
{
    public class MyAccountViewModel : Screen
    {
        private string _name = "Karel";
        private string _surname = "Novak";
        
        private string _nickname = "Karel_007";

        public string Nickname
        {
            get
            {
                return _nickname;
            }
            
            
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
               
                
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                
                
               
                
            }
        }
        public MyAccountView myAccountView = new MyAccountView();
        
        public string FullName
        {
            get
            {
                return _name+" "+_surname;
            }

        }

        
        
        
        public void SubmitChanges(string name,string surname)
        {

            NotifyOfPropertyChange(() => Surname);
            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => FullName);

        }

    }
}
