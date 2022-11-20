using System.Windows.Forms;
using System.Reflection;
using MyMVVM.Attributes;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public class NumericUpDownBuilder : IControlBuilder<NumericUpDown>
    {
        public NumericUpDown? CreateControl(PropertyInfo info)
        {
            NumericUpDown? box = new NumericUpDown();

            box.Dock = DockStyle.Top;

            if (info.PropertyType.Equals(typeof(double)) || info.PropertyType.Equals(typeof(float)))
                box.DecimalPlaces = 2;

            box.Minimum = decimal.MinValue;
            box.Maximum = decimal.MaxValue;

            return box;
        }

        public NumericUpDown? CreateControl(System.Type type)
        {
            NumericUpDown? box = new NumericUpDown();

            box.Dock = DockStyle.Top;

            if (type.Equals(typeof(double)) || type.Equals(typeof(float)))
                box.DecimalPlaces = 2;

            box.Minimum = decimal.MinValue;
            box.Maximum = decimal.MaxValue;

            return box;
        }
    }
}