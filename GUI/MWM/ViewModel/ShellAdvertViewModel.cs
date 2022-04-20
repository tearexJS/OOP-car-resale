using Caliburn.Micro;
using GUI.MWM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.MWM.ViewModel
{
    public class ShellAdvertViewModel
    {
        public BindableCollection<AdvertsModel> Adverts { get; set; }

        public ShellAdvertViewModel()
        {
            DataAccess da = new DataAccess();
            Adverts = new BindableCollection<AdvertsModel>(da.GetAdverts());
        }

    }
}
