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


namespace MyMVVM.Classes.WinFormsHelpers
{
    public class ComboBoxContainer : GenericContainer<ComboBox>
    {
        public ComboBoxContainer(Panel? panel, ComboBox? control, Label? label) : base(panel, control, label, ControlType.COMBO)
        {

        }

        public override void SetValue(ViewModelBase @object, PropertyInfo info)
        {
            IGetValuesDelegate? cmd = ComboAttribute.GetDelegate(info);

            if (cmd != null)
            {
                (Control as ComboBox)!.SelectedItem = cmd.GetValue(@object);

            }
        }

        public override object? GetValue(PropertyInfo info)
        {
            return (Control as ComboBox)!.SelectedValue;
        }
    }
}
