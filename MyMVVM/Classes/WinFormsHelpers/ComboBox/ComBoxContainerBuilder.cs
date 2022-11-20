using System.Windows.Forms;
using System.Reflection;
using MyMVVM.Attributes;
using MyMVVM.Controls;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public class ComBoxContainerBuilder : IControlBuilder<GenericContainer<ComboBox>>
    {

        public GenericContainer<ComboBox>? CreateControl(PropertyInfo info)
        {
            Panel container = new PanelBuilder().CreateControl(info);

            Label? lbl = new LabelBuilder().CreateControl(info);

            ComboBox? box = new ComboBoxBuilder().CreateControl(info);

            if (lbl != null)
                container.Controls.Add(lbl);

            container.Controls.Add(box);

            box?.BringToFront();

            ComboBoxContainer comBoxContainer = new ComboBoxContainer(container, box, lbl);            

            return comBoxContainer;
        }
    }
}