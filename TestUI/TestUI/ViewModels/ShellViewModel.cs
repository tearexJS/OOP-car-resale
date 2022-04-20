using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUI.Models;

namespace TestUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public BindableCollection<AdvertsModel> Adverts { set; get; }
        HomeViewModel HomeViewModel = new HomeViewModel();
        BrowseViewModel BrowseViewModel = new BrowseViewModel();
        MyAccountViewModel MyAccountViewModel = new MyAccountViewModel();
        public ShellViewModel()
        {
            
            ActivateItemAsync(HomeViewModel);
        }
        public void LoadPage1()
        {
            ActivateItemAsync(HomeViewModel);
        }

        public void LoadPage2()
        {
            ActivateItemAsync(BrowseViewModel);
        }

        public void LoadPage3()
        {
            ActivateItemAsync(HomeViewModel);
        }

        public void LoadPageMyAccount()
        {
            ActivateItemAsync(MyAccountViewModel);
        }




    }
}
