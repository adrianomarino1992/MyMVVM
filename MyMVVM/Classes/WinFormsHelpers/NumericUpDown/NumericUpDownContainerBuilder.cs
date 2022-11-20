using System.Windows.Forms;
using System.Reflection;
using MyMVVM.Attributes;
using MyMVVM.Controls;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public class NumericUpDownContainerBuilder : IControlBuilder<GenericContainer<NumericUpDown>>
    {

        public GenericContainer<NumericUpDown>? CreateControl(PropertyInfo info)
        {
            Panel container = new PanelBuilder().CreateControl(info);

            Label? lbl = new LabelBuilder().CreateControl(info);

            NumericUpDown? box = new NumericUpDownBuilder().CreateControl(info);

            if (lbl != null)
                container.Controls.Add(lbl);

            container.Controls.Add(box);

            box?.BringToFront();

            GenericContainer<NumericUpDown> numericUpDownContainer = new GenericContainer<NumericUpDown>(container, box, lbl, Enums.ControlType.NUMERIC);            

            return numericUpDownContainer;
        }


        public GenericContainer<NumericUpDown>? CreateControl(System.Type type)
        {
            Panel container = new PanelBuilder().CreateControl();

            NumericUpDown? box = new NumericUpDownBuilder().CreateControl(type);
            
            container.Controls.Add(box);

            box?.BringToFront();

            GenericContainer<NumericUpDown> numericUpDownContainer = new GenericContainer<NumericUpDown>(container, box, null, Enums.ControlType.NUMERIC);

            return numericUpDownContainer;
        }
    }
}