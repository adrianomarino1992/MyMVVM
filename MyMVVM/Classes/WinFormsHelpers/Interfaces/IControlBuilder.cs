using System.Reflection;
using MyMVVM.Controls;

namespace MyMVVM.Classes.WinFormsHelpers.Interfaces
{
    public interface IControlBuilder<T> where T : class
    {
        T? CreateControl(PropertyInfo info);
    }
}