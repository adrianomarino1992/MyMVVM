using System.Windows.Forms;
using System.Reflection;
using MyMVVM.Attributes;
using MyMVVM.Controls;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public class TextBoxContainerBuilder : IControlBuilder<GenericContainer<TextBox>>
    {

        public GenericContainer<TextBox>? CreateControl(PropertyInfo info)
        {
            Panel container = new PanelBuilder().CreateControl(info);

            Label? lbl = new LabelBuilder().CreateControl(info);

            TextBox? box = new TextBoxBuilder().CreateControl(info);

            if (lbl != null)
                container.Controls.Add(lbl);

            container.Controls.Add(box);

            box?.BringToFront();

            GenericContainer<TextBox> textBoxContainer = new GenericContainer<TextBox>(container, box, lbl, Enums.ControlType.TEXT);            

            return textBoxContainer;
        }

        public GenericContainer<TextBox>? CreateControl()
        {
            Panel container = new PanelBuilder().CreateControl();

            TextBox? box = new TextBoxBuilder().CreateControl();
                       
            container.Controls.Add(box);

            box?.BringToFront();

            GenericContainer<TextBox> textBoxContainer = new GenericContainer<TextBox>(container, box, null, Enums.ControlType.TEXT);

            return textBoxContainer;
        }
    }
}