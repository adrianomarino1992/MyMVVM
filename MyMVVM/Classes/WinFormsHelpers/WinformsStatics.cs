using MyMVVM.Attributes;
using MyMVVM.Controls;
using MyMVVM.Delegates;
using MyMVVM.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public static class WinformsStatics
    {
        public static BaseContainer CreateWinFormsControl(PropertyInfo info)
        {

            if (info.PropertyType != typeof(string) && (info.PropertyType.IsAssignableTo(typeof(ViewModelBase))))
            {
                return new IEnumerableContainerBuilder().CreateControl(info)!;
            }


            if (info.PropertyType != typeof(string) && (info.PropertyType.IsArray || info.PropertyType.IsAssignableTo(typeof(IEnumerable))))
            {
                return new IEnumerableContainerBuilder().CreateControl(info)!;
            }


            IGetValuesDelegate? cmd = ComboAttribute.GetDelegate(info);

            if (cmd != null)
            {
                return new ComBoxContainerBuilder().CreateControl(info)!;

            }

            if (info.PropertyType.Equals(typeof(String)))
            {
                return new TextBoxContainerBuilder().CreateControl(info)!;
            }

            if (info.PropertyType.Equals(typeof(long)) || info.PropertyType.Equals(typeof(int)) || info.PropertyType.Equals(typeof(float)) || info.PropertyType.Equals(typeof(double)))
            {
                return new NumericUpDownContainerBuilder().CreateControl(info)!;
            }

            throw new InvalidTypeException(info.PropertyType, $"The type {info.PropertyType} can not be converted in a WinForms control");
        }

        

    }

    
}
