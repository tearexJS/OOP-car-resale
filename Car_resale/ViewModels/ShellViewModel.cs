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
        BrowseViewModel BrowseViewModel = new BrowseViewModel();
        AdvertViewModel AdvertViewModel;
        NewAdvertViewModel NewAdvertViewModel = new NewAdvertViewModel();
        public ShellViewModel()
        {

            ActivateItemAsync(BrowseViewModel);
        }
        public void LoadBrowseView()
        {
            ActivateItemAsync(BrowseViewModel);
        }
        public void LoadNewAdvertView()
        {
            ActivateItemAsync(NewAdvertViewModel);
        }
        public void LoadAdvertView(/*AdvertsModel advert*/)
        {
            AdvertViewModel = new AdvertViewModel(/*advert*/);
            ActivateItemAsync(AdvertViewModel);
        }
    }
}
