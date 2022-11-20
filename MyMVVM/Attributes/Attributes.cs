using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MyMVVM.Delegates;

namespace MyMVVM.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class LabelAttribute : Attribute
    {
        public string Label { get; set; }
        public LabelAttribute(string label)
        {
            Label = label;
        }

        public static string? GetLabel(PropertyInfo info)
        {
            if (info == null)
                return null;

            LabelAttribute? lbl = info.GetCustomAttribute<LabelAttribute>();

            if (lbl == null)
                return null;

            return lbl.Label;
        }
    }


    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PlaceHolderAttribute : Attribute
    {
        public string Text { get; set; }
        public PlaceHolderAttribute(string label)
        {
            Text = label;
        }

        public static string? GetPlaceHolder(PropertyInfo info)
        {
            if (info == null)
                return null;

            PlaceHolderAttribute? txt = info.GetCustomAttribute<PlaceHolderAttribute>();

            if (txt == null)
                return null;

            return txt.Text;
        }
    }


    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ComboAttribute : Attribute
    {
        public Type Delegate{ get; set; }
        public ComboAttribute(Type @delegate)
        {
            if (!@delegate.IsAssignableTo(typeof(IGetValuesDelegate)))
                throw new ArgumentException($"The type {@delegate.Name} do not implements the {nameof(IGetValuesDelegate)} interafce");

            Delegate = @delegate;
        }

        public static IGetValuesDelegate? GetDelegate(PropertyInfo info)
        {
            if (info == null)
                return null;

            ComboAttribute? lbl = info.GetCustomAttribute<ComboAttribute>();

            if (lbl == null)
                return null;

            return (IGetValuesDelegate)Activator.CreateInstance(lbl.Delegate)!;
        }
    }



}
