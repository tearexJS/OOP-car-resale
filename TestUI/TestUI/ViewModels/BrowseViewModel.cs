using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUI.Models;

namespace TestUI.ViewModels
{
    public class BrowseViewModel : Screen
    {
        public BindableCollection<AdvertsModel> Adverts { set; get; }
        public BrowseViewModel()
        {
            DataAccess da = new DataAccess();
            Adverts = new BindableCollection<AdvertsModel>(da.GetAdverts());
        }
    }
}
