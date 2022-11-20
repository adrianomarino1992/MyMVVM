using System.Windows.Forms;
using System.Reflection;
using MyMVVM.Attributes;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;

namespace MyMVVM.Classes.WinFormsHelpers
{
    internal class LabelBuilder : IControlBuilder<Label>
    {
       
        public Label? CreateControl(PropertyInfo info)
        {
            Label? lbl = null;

            string? labelText = LabelAttribute.GetLabel(info);

            if (labelText == null)
                return null;

            lbl = new Label();
            lbl.Padding = new Padding(2, 2, 2, 2);
            lbl.Text = labelText;
            lbl.AutoSize = true;
            lbl.Dock = DockStyle.Top;

            return lbl;
        }
    }
}
