using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
