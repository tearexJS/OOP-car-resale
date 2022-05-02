using App.Commands;
using App.Messages;
using App.Services;
using App.ViewModels.Interfaces;
using App.Wrappers;
using Caliburn.Micro;
using CarResale.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {

        public ShellViewModel(
                IMediator mediator,
                IBrowseViewModel browseViewModel,
                IAdvertViewModel advertViewModel,
                INewAdvertViewModel newAdvertViewModel
            )
        {
            CurrentView = (BrowseViewModel)browseViewModel;
            ShowBrowseView = new RelayCommand<IBrowseViewModel>(OnClickShowBrowseView);
            ShowNewAdvertView = new RelayCommand<INewAdvertViewModel>(OnClickShowNewAdvertView);
            BrowseViewModel = browseViewModel;
            AdvertViewModel = advertViewModel;
            NewAdvertViewModel = newAdvertViewModel;
            mediator.Register<SelectMessage<CarWrapper>>(OnCarSelected);
            mediator.Register<AddMessage<CarWrapper>>(OnCarAdded);
        }
        public IBrowseViewModel BrowseViewModel { get; }
        public IAdvertViewModel AdvertViewModel { get; set; }
        public INewAdvertViewModel NewAdvertViewModel { get; set; }
        public ICommand ShowBrowseView { get; }
        public ICommand ShowNewAdvertView { get; }

        public ViewModelBase CurrentView { get; set; }
        
        private void OnClickShowBrowseView(IBrowseViewModel? browseViewModel)
        {
            CurrentView = (BrowseViewModel)BrowseViewModel;
        }
        private void OnClickShowNewAdvertView(INewAdvertViewModel? newAdvertViewModel)
        {
            NewAdvertViewModel.LoadAsync(default);
            CurrentView = (NewAdvertViewModel)NewAdvertViewModel;
        }
        private void OnCarSelected(SelectMessage<CarWrapper> message)
        {
            SelectCar(message.Id);
        }
        private void OnCarAdded(AddMessage<CarWrapper> message)
        {
            CarAdded(message.Id);
        }
        private void SelectCar(Guid? Id)
        {
            if (Id is null)
            {
                CurrentView = (BrowseViewModel)BrowseViewModel;
            }
            else
            {
                AdvertViewModel.LoadAsync((Guid)Id);
                CurrentView = (AdvertViewModel)AdvertViewModel;
            }
        }
        private void CarAdded(Guid? Id)
        {
            if(Id is null)
            {
                CurrentView = (BrowseViewModel)BrowseViewModel;
            }
            else
            {
                AdvertViewModel.LoadAsync((Guid)Id);
                CurrentView = (AdvertViewModel)AdvertViewModel;
            }
            
        }
    }
}
