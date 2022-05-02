using App.Commands;
using App.Extensions;
using App.Messages;
using App.Services;
using App.ViewModels.Interfaces;
using App.Wrappers;
using CarResale.BL.Facades;
using CarResale.BL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App.ViewModels
{
    public class BrowseViewModel : ViewModelBase, IBrowseViewModel
    {
        private readonly IMediator _mediator;
        private readonly CarFacade _carFacade;
        private CarListModel _selectedRow;
        private string _searchedString;
        public BrowseViewModel(
                IMediator mediator,
                CarFacade carFacade
            ) 
        {
            _mediator = mediator;
            _carFacade = carFacade;
            SelectedCar = new RelayCommand<CarListModel>(SelectedCarInDatagrid);
            Search = new RelayCommand(OnSearch);
        }
        public ObservableCollection<CarListModel> Adverts { get; } = new();
        public ICommand SelectedCar { get; }
        public ICommand Search { get; }
        public string SearchedString
        {
            get => _searchedString;
            set
            {
                _searchedString = value;
                OnPropertyChanged(nameof(SearchedString));
            }
        }
        public CarListModel SelectedRow 
        {
            get => _selectedRow;
            set
            {
                _selectedRow = value;
                OnPropertyChanged(nameof(SelectedRow));
            }
        }
        public async Task LoadAsync()
        {
            Adverts.Clear();
            var adverts = await _carFacade.GetAsync();
            Adverts.AddRange(adverts);
        }

        public override void LoadInDesignMode()
        {
            Adverts.Add(new CarListModel(
                ModelName: "Wasdf",
                ManufacturerName: "asdf",
                CarType: "Personal",
                ImagePath: "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png"
                ));
        }
        private void SelectedCarInDatagrid(CarListModel? carListModel)
        {
            _mediator.Send(new SelectMessage<CarWrapper> { Id = _selectedRow.Id });
        }

        private void OnSearch()
        {
            var filtered = Adverts.Where(car => car.ModelName.StartsWith(_searchedString));
            Adverts.Clear();
            Adverts.AddRange(filtered);
        }
    }
}
