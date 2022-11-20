using MyMVVM.Attributes;
using MyMVVM.Controls;
using MyMVVM.Delegates;
using MyMVVM.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyRefs.Extensions;


namespace MyMVVM.Classes.WinFormsHelpers
{
    public class IEnumerableContainer : GenericContainer<IEnumerableControl>
    {
        private List<object> Itens { get; init; }

        private List<BaseContainer> _containers;

        public IEnumerableContainer(Panel? panel, IEnumerableControl? control, Label? label) : base(panel, control, label, ControlType.IENUMERABLE)
        {

            Itens = new List<object>();
            _containers = new List<BaseContainer>();
            control!.Button.Click += Control_Click;

        }


        public override void SetValue(ViewModelBase @object, PropertyInfo info)
        {
            if (info.PropertyType.IsAssignableTo(typeof(System.Collections.IEnumerable)))
            {
                var list = info.GetValue(@object) as System.Collections.IEnumerable;

                if (list is null)
                    return;

                foreach (var item in list!)
                {
                    AddItem(item);
                }
            }
            else
            {
                var value = @object.GetPropertyValue(info.Name);
                if(value != null)
                    AddItem(value);
            }
                
        }

        public override object? GetValue(PropertyInfo info)
        {
            IEnumerable<object?> data = this.GenericControl!.GetControls().Select(s =>
            {
                Type type = this.GenericControl.Type;
                object value = s.GetValue(info)!;

                if (type.Equals(typeof(string)))
                {
                    return value!.ToString();
                }

                if (type.Equals(typeof(long)) || type.Equals(typeof(int)) || type.Equals(typeof(float)) || type.Equals(typeof(double)))
                {
                    return System.Convert.ChangeType(value, type);
                }

                return value;


            })!.ToList();

            if (info.PropertyType.IsAssignableTo(typeof(System.Collections.IEnumerable)))
            {

                MethodInfo castMethod = typeof(System.Linq.Enumerable).GetMethod("Cast")!.MakeGenericMethod(this.GenericControl.Type);
                MethodInfo toArray = typeof(System.Collections.Generic.List<>).GetMethod("ToArray")!;
                MethodInfo toList = typeof(System.Linq.Enumerable).GetMethod("ToList")!.MakeGenericMethod(this.GenericControl.Type);

                var castedData = castMethod.Invoke(null, new object[] { data });

                if (info.PropertyType.GetElementType() != null)
                    return toArray.Invoke(castedData, new object[] { });
                else
                    return toList.Invoke(null, new object[] { castedData! });
            }
            else
            {
                return data.FirstOrDefault();
            }

           
        }

        private void Control_Click(object? sender, EventArgs e)
        {
            AddItem(null);            
        }

        private void AddItem(object? value)
        {
            Type type = (this.Control as IEnumerableControl)!.Type;

            if (type.Equals(typeof(string)))
            {
                BaseContainer container = new TextBoxContainerBuilder().CreateControl()!;
               
                if(!(value is null))
                {
                    (container as GenericContainer<TextBox>)!.GenericControl!.Text = value.ToString();
                }

                this.GenericControl!.AddControl(container);
                return;
            }

            if (type.Equals(typeof(long)) || type.Equals(typeof(int)) || type.Equals(typeof(float)) || type.Equals(typeof(double)))
            {
                BaseContainer container = new NumericUpDownContainerBuilder().CreateControl(type)!;

                if (!(value is null))
                {
                    (container as GenericContainer<NumericUpDown>)!.GenericControl!.Value = (decimal)System.Convert.ChangeType(value, typeof(decimal));
                }
                
                this.GenericControl!.AddControl(container);
                return;

            }

            {

                BaseContainer container = new ClassPropertyControlContainerBuilder().CreateControl(type)!;
                BaseContainer removibleContainer = new RemovibleControlContainerBuilder().CreateControl(container)!;

                if (!(value is null))
                {
                    (container as ClassPropertyControlContainer)!.SetValue((ViewModelBase)value);
                }

                this.GenericControl!.AddControl(removibleContainer);

                (removibleContainer as RemovibleControlContainer)!.RemoveButton!.Click += (sender, args) =>
                {
                    this.GenericControl!.RemoveControl(removibleContainer);
                };

                return;
            }

        }

        private void RemoveButton_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
