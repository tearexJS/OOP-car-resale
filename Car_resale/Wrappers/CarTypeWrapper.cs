using CarResale.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Wrappers
{
    public class CarTypeWrapper : ModelWrapper<CarTypeDetailModel>
    {
        public CarTypeWrapper(CarTypeDetailModel model) : base(model)
        {

        }

        public string Type
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Type))
            {
                yield return new ValidationResult($"{nameof(Type)} is required.", new[] {nameof(Type)});
            }
        }
    }
}
