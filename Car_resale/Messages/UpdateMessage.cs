using CarResale.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Messages
{
    public record UpdateMessage<T> : Message<T>
        where T : IModel
    {
    }
}
