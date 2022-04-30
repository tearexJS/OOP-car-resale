using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.BL.Models;
using System.Runtime.CompilerServices;

namespace App.Wrappers
{
    public class ImageWrapper : ModelWrapper<ImageDetailModel>
    {
        public ImageWrapper(ImageDetailModel model) : base(model)
        {

        }

        public string ImagePath
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public static implicit operator ImageWrapper(ImageDetailModel detailModel)
            => new(detailModel);
        public static implicit operator ImageDetailModel(ImageWrapper wrapper)
            => wrapper.Model;
    }
}
