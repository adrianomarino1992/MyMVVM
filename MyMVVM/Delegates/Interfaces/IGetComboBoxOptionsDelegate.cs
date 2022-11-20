using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyMVVM.Delegates
{
    public interface IGetValuesDelegate
    {
        object[] GetItens();

        string? GetLabelPropertyName();

        string? GetValuePropertyName();

        object? GetValue(object obj);
        
    }
}
