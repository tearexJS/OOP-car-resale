using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.BL.Models;
namespace App.Wrappers
{
    public class CarWrapper : ModelWrapper<CarDetailModel>
    {
        public CarWrapper(CarDetailModel model) : base(model)
        {

        }
        public decimal Mileage
        {
            get => GetValue<decimal>();
            set => SetValue(value);
        }
        public int YearOfManufacture
        {
            get => GetValue<int>();
            set => SetValue(value);
        }
        public CarModelListModel CarModel
        {
            get => GetValue<CarModelListModel>();
            set => SetValue(value);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Mileage > 0)
            {
                yield return new ValidationResult($"{nameof(Mileage)} is required", new[] { nameof(Mileage) });
            }
            if(YearOfManufacture > 0)
            {
                yield return new ValidationResult($"{nameof(YearOfManufacture)} is required", new[] { nameof(YearOfManufacture) });
            }
        }
        public static implicit operator CarWrapper(CarDetailModel detailModel)
            => new CarWrapper(detailModel);
        public static implicit operator CarDetailModel(CarWrapper wrapper)
            => wrapper.Model;
    }
}
