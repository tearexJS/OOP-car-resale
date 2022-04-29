using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        //public BindableCollection<> Adverts { set; get; }
        HomeViewModel HomeViewModel = new HomeViewModel();
        BrowseViewModel BrowseViewModel = new BrowseViewModel();
        MyAccountViewModel MyAccountViewModel = new MyAccountViewModel();
        AdvertViewModel AdvertViewModel;
        NewAdvertViewModel NewAdvertViewModel = new NewAdvertViewModel();


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
            ActivateItemAsync(NewAdvertViewModel);
        }

        public void LoadPageMyAccount()
        {
            ActivateItemAsync(MyAccountViewModel);
        }
        public void RowView(AdvertsModel advert)
        {
            AdvertViewModel = new AdvertViewModel(advert);
            ActivateItemAsync(AdvertViewModel);
        }




    }
}
