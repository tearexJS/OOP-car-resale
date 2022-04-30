using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.BL.Models;
using System.Runtime.CompilerServices;
using App.Extensions;
using System.ComponentModel.DataAnnotations;

namespace App.Wrappers
{
    public class AdvertisementWrapper : ModelWrapper<AdvertisementDetailModel>
    {
        public AdvertisementWrapper(AdvertisementDetailModel model) : base(model)
        {
            InitializeCollectionProperties(model);
        }
        public string Title
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string Description
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public decimal Price
        {
            get => GetValue<decimal>();
            set => SetValue(value);
        }
        public DateTime PublicationTime
        {
            get => GetValue<DateTime>();
            set => SetValue(value);
        }


        private void InitializeCollectionProperties(AdvertisementDetailModel model)
        {
            if (model.Images == null)
            {
                throw new ArgumentException("Images cannot be null");
            }
            Images.AddRange(model.Images.Select(e => new ImageWrapper(e)));
            RegisterCollection(Images, model.Images);
        }

        public ObservableCollection<ImageWrapper> Images {get; set;} = new();

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                yield return new ValidationResult($"{nameof(Title)} is required", new[] {nameof(Title)});
            }
            if (string.IsNullOrWhiteSpace(Description))
            {
                yield return new ValidationResult($"{nameof(Description)} is required", new[] {nameof(Description)});
            }
            if(Price > 0)
            {
                yield return new ValidationResult($"{nameof(Price)} is required", new[] {nameof(Price)});
            }
        }

        public static implicit operator AdvertisementWrapper(AdvertisementDetailModel detailModel)
            => new(detailModel);
        public static implicit operator AdvertisementDetailModel(AdvertisementWrapper wrapper)
            => wrapper.Model;
    }
}
