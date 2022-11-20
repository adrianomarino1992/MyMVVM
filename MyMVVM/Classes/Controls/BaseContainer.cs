using System;
using System.Reflection;
using System.Windows.Forms;

using MyRefs.Extensions;
using MyMVVM.Classes;
using MyMVVM.Enums;
using MyMVVM.Delegates;
using MyMVVM.Attributes;

namespace MyMVVM.Controls
{

    public abstract class BaseContainer
    {
        public virtual ControlType ControlType { get; protected set; }

         public virtual Panel? ControlContainer {get; protected set;}

        public virtual Control? Control {get; protected set;}

        public virtual Label? Label { get; protected set; }

        public virtual Button? RemoveButton { get; protected set; }

        public BaseContainer(Panel? panel, Control? control, Label? label, ControlType? controlType)
        {
            ControlContainer = panel;
            Control = control;
            Label = label;
            ControlType = ControlType;
        }

        public virtual void SetValue(ViewModelBase @object, PropertyInfo info)
        {

            if (info.PropertyType.Equals(typeof(String)))
            {
                (Control as TextBox)!.Text = @object.GetPropertyValue<string>(info.Name);
            }

            if (info.PropertyType.Equals(typeof(long)) || info.PropertyType.Equals(typeof(int)) || info.PropertyType.Equals(typeof(float)) || info.PropertyType.Equals(typeof(double)))
            {
                (Control as NumericUpDown)!.Value = decimal.Parse(@object.GetPropertyValue(info.Name).ToString()!);
            }
                        
        }

        public virtual object? GetValue(PropertyInfo info)
        {            

            if (Control is TextBox txt)
            {
                return txt.Text;
            }

            if (Control is NumericUpDown num)
            {
                return num.Value;
            }

            return null;
        }

    }

    public class GenericContainer<T> : BaseContainer where T :  Control
    {
        
        public T? GenericControl 
        {
            get{

                if(this.Control is null)
                    return null;
                  
                if(Control.GetType().IsAssignableFrom(typeof(T)))
                    return (T)(object)Control;
                
                return null;      
            }            
        }
        public GenericContainer(Panel? panel, T? control, Label? label, ControlType? controlType) : base(panel, control, label, controlType)
        {
            
        }
    }
}