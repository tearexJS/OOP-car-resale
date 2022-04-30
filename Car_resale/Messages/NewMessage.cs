using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.BL.Models;
namespace App.Messages
{
    public record NewMessage<T> : Message<T>
        where T : IModel
    {

    }
}
