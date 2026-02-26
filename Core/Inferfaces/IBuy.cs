using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClasses.Core.Inferfaces
{
    public interface IBuy
    {
        int MinPrice { get; }
        int CalcPrice();
    }
}
