using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using MyMVVM.Attributes;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;
using MyMVVM.Delegates;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public class ComboBoxBuilder : IControlBuilder<ComboBox>
    {
        public ComboBox? CreateControl(PropertyInfo info)
        {
            ComboBox? box = new ComboBox();
            box.Dock = DockStyle.Top;

            IGetValuesDelegate? cmd = ComboAttribute.GetDelegate(info);

            if(cmd != null)
            {
                string? label = cmd.GetLabelPropertyName();
                string? value = cmd.GetValuePropertyName();
                box.DropDownStyle = ComboBoxStyle.DropDownList;
                

                if (label != null)
                    box.DisplayMember = label;
                if (value != null)
                    box.ValueMember = value;

                box.DataSource = cmd.GetItens().ToList();


            }



            return box;
        }
    }
}