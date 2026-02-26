using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClasses.Core.Utils
{
    public static class Tools
    {
        //Example to show how compiler can detect the type
        public static void Print<TData> (TData data)
        {
            Console.WriteLine(data);
        }
    }
}
