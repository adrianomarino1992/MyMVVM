using System.Windows.Forms;
using System.Reflection;
using MyMVVM.Attributes;
using MyMVVM.Controls;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;
using System;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public class IEnumerableContainerBuilder : IControlBuilder<GenericContainer<IEnumerableControl>>
    {

        public GenericContainer<IEnumerableControl>? CreateControl(PropertyInfo info)
        {
            Panel container = new PanelBuilder().CreateControl(info);

            Label? lbl = new LabelBuilder().CreateControl(info);

            IEnumerableControl? box = new IEnumerableControlBuilder().CreateControl(info);

            if (lbl != null)
                box!.Label = lbl.Text;
            else
            {
                box!.Label = info.Name;
            }
                

            container.Controls.Add(box);           

            box?.BringToFront();

            IEnumerableContainer comBoxContainer = new IEnumerableContainer(container, box, lbl);            

            return comBoxContainer;
        }
                
    }
}