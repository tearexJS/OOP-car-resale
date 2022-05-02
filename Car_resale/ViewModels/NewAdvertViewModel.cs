using App.ViewModels.Interfaces;
using App.Wrappers;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using CarResale.BL.Facades;
using App.Services;
using CarResale.BL.Models;
using System.Collections.ObjectModel;
using App.Extensions;
using System.Windows.Input;
using App.Commands;
using App.Messages;

namespace App.ViewModels
{
    public class NewAdvertViewModel : ViewModelBase, INewAdvertViewModel
    {
        private readonly CarFacade _carFacade;
        private readonly CarModelFacade _carModelFacade;
        private readonly IMediator _mediator;
        private string _filePath;
        public NewAdvertViewModel(
            CarFacade carFacade,
            CarModelFacade carModelFacade,
            IMediator mediator
            )
        {
            _carFacade = carFacade;
            _carModelFacade = carModelFacade;
            _mediator = mediator;
            AddNewCar = new AsyncRelayCommand(SaveAsync);
            ImportCarFromCSV = new RelayCommand(OnImportSave);

        }

        public CarWrapper Model { get; private set; }
        public ObservableCollection<CarModelListModel> CarModels { get; set; } = new();


        public ICommand AddNewCar { get; }
        public ICommand ImportCarFromCSV { get; }
        public string FilePath 
        {
            get => _filePath;
            set
            {
                _filePath = value;
                OnPropertyChanged(nameof(FilePath));
            } 
        }
        public Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            if(Model == null)
            {
                throw new InvalidOperationException("Null model cannot be saved");
            }
            Model = await _carFacade.SaveAsync(Model.Model);
            _mediator.Send(new AddMessage<CarWrapper> { Id = Model.Id});

        }

        public async Task LoadAsync(Guid id)
        {
            Model = await _carFacade.GetAsync(id) ?? CarDetailModel.Empty;
            CarModels.Clear();
            var carModels = await _carModelFacade.GetAsync();
            CarModels.AddRange(carModels);
        }
        private void OnImportSave()
        {
           string data;
           using(StreamReader reader = new StreamReader(_filePath))
           {
                data = reader.ReadToEnd();
           }
           var dataArr = data.Split(';');
           foreach(var carModel in CarModels)
            {
                if(carModel.ModelName == dataArr[0])
                    Model.Model.CarModel = carModel;
            }
            Model.ImagePath = dataArr[4];
            Model.YearOfManufacture = Convert.ToInt32(dataArr[2]);
            Model.Mileage = Convert.ToDecimal(dataArr[3]);
            _ = SaveAsync();
        }
    }
}
