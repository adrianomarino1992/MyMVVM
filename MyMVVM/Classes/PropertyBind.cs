using System.Reflection;
using System.Windows.Forms;
using System;
using MyMVVM.Controls;

namespace MyMVVM.Classes
{    
    public class PropertyBind
    {
        public PropertyInfo PropertyInfo { get; }

        public BaseContainer Container { get; }

        public PropertyBind(PropertyInfo propertyInfo, BaseContainer container)
        {
            PropertyInfo = propertyInfo;
            Container = container;
        }   
    }
}
