using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.BL.Models;
namespace App.Wrappers
{
    public class CarManufacturerWrapper : ModelWrapper<CarManufacturerDetailModel>
    {
        public CarManufacturerWrapper(CarManufacturerDetailModel model) : base(model)
        {

        }

        public string ManufacturerName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(ManufacturerName))
            {
                yield return new ValidationResult($"{nameof(ManufacturerName)} is required", new[] { nameof(ManufacturerName)});
            }
        }
    }
}
