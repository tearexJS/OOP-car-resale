using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Extensions;
using AutoMapper;
using CarResale.BL.Models;
namespace App.Wrappers
{
    public class UserWrapper : ModelWrapper<UserDetailModel>
    {
        public UserWrapper(UserDetailModel model) : base(model)
        {

        }

        public string FirstName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string LastName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string Email
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string PhoneNumber
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string Password
        {
            get=> GetValue<string>();
            set=>SetValue(value);
        }
        private void InintializeCollectionProperties(UserDetailModel model)
        {
            if (model.Advertisements == null)
            {
                throw new ArgumentException(" cannot be null");
            }
            Advertisements.AddRange(model.Advertisements.Select(e => new AdvertisementWrapper(e)));
            RegisterCollection(Advertisements, model.Advertisements);
        }
        public ObservableCollection<AdvertisementWrapper> Advertisements { get; set; } = new();

    }
}
