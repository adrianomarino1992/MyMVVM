using System.Windows.Forms;
using System.Reflection;
using MyMVVM.Attributes;
using MyMVVM.Controls;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;
using System;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public class RemovibleControlContainerBuilder : IControlBuilder<GenericContainer<RemovibleControl>>
    {

        public GenericContainer<RemovibleControl>? CreateControl(PropertyInfo info)
        {
           throw new NotImplementedException();
        }

        public GenericContainer<RemovibleControl>? CreateControl(BaseContainer control)
        {
            Panel container = new PanelBuilder().CreateControl();

            RemovibleControl? box = new RemovibleControlBuilder().CreateControl(control.ControlContainer!);

            container.Controls.Add(box);

            box?.BringToFront();

            RemovibleControlContainer removibleControlContainer = new RemovibleControlContainer(control, container, box, null);

            return removibleControlContainer;
        }

    }
}