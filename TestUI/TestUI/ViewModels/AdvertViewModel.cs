using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUI.Models;

namespace TestUI.ViewModels
{
    class AdvertViewModel : Screen
    {
        private String _loremIpsum;
        private AdvertsModel _currentAdvert;

        public AdvertsModel CurrentAdvert
        {
            get { return _currentAdvert; }
            set { _currentAdvert = value; }
        }

        public String LoremIpsum
        {
            get { return _loremIpsum; }
            set { _loremIpsum = value; }
        }

        public AdvertViewModel(AdvertsModel CurrentAdvert)
        {
            this.CurrentAdvert = CurrentAdvert;
            LoremIpsum = File.ReadAllText(@"Resources\Text\PovidkaOChlebu.txt");
        }
    }
}
