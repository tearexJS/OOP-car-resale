using App.Commands;
using App.Messages;
using App.Services;
using App.ViewModels.Interfaces;
using App.Wrappers;
using CarResale.BL.Facades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App.ViewModels
{
    public class AdvertViewModel : ViewModelBase, IAdvertViewModel
    {
        private readonly IMediator _mediator;
        private readonly CarFacade _carFacade;


        public AdvertViewModel(
                IMediator mediator,
                CarFacade carFacade
            )
        {
            _mediator = mediator;
            _carFacade = carFacade;
            ExportToCSV = new RelayCommand(OnExportToCSV);
            SaveChanges = new AsyncRelayCommand(SaveAsync);
        }
        public CarWrapper Model { get; private set; }
        public ICommand ExportToCSV { get; }
        public ICommand SaveChanges { get; }
        public Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task LoadAsync(Guid Id)
        {
            Model = await _carFacade.GetAsync(Id);
        }

        public async Task SaveAsync()
        {
            Model = await _carFacade.SaveAsync(Model);
            _mediator.Send(new UpdateMessage<CarWrapper> { Model = Model });
        }

        private void OnExportToCSV()
        {
            string data = String.Format("{0};{1};{2};{3};{4}", Model.CarModel.ModelName, Model.CarModel.ManufacturerName, Model.YearOfManufacture, Model.Mileage, Model.ImagePath);

            using (StreamWriter output = new StreamWriter("car.csv"))
            {
                output.Write(data);
            }
        }
    }
}
