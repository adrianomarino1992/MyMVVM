using System.Windows.Forms;
using System.Reflection;
using MyMVVM.Attributes;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public class PanelBuilder : IControlBuilder<Panel>
    {
        public Panel CreateControl(PropertyInfo info)
        {
            return CreateControl();
        }

        public Panel CreateControl()
        {
            Panel container = new Panel();
            container.AutoSize = true;
            container.BackColor = System.Drawing.Color.AliceBlue;
            container.Dock = DockStyle.Top;
            container.Padding = new Padding(2, 2, 2, 2);

            return container;
        }
    }
}
