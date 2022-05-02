using CarResale.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Wrappers
{
    public class CarModelWrapper : ModelWrapper<CarModelDetailModel>
    {
        public CarModelWrapper(CarModelDetailModel model) : base(model)
        {

        }
        public string ModelName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public decimal Engine
        {
            get => GetValue<decimal>();
            set => SetValue(value);
        }
        public decimal Power
        {
            get => GetValue<decimal>();
            set => SetValue(value);
        }
        public int Seats
        {
            get => GetValue<int>();
            set => SetValue(value);
        }
        public CarTypeWrapper CarType
        {
            get => GetValue<CarTypeWrapper>();
            set => SetValue(value);
        }
        public CarManufacturerWrapper CarManufacturer
        {
            get => GetValue<CarManufacturerWrapper>();
            set => SetValue(value);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(ModelName))
            {
                yield return new ValidationResult($"{nameof(ModelName)} is required", new[] { nameof(ModelName) });
            }
            if(Engine > 0)
            {
                yield return new ValidationResult($"{nameof(Engine)} is required", new[] {nameof(Engine) });
            }
            if(Power > 0)
            {
                yield return new ValidationResult($"{nameof(Power)} is required", new[] { nameof(Power) });
            }
            if(Seats > 0)
            {
                yield return new ValidationResult($"{nameof(Seats)} is required", new[] { nameof(Seats) });
            }
        }
    }
}
