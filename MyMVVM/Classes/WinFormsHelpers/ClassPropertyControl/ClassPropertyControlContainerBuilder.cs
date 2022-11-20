using System.Windows.Forms;
using System.Reflection;
using MyMVVM.Attributes;
using MyMVVM.Controls;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public class ClassPropertyControlContainerBuilder : IControlBuilder<GenericContainer<ClassPropertyControl>>
    {       

        public GenericContainer<ClassPropertyControl>? CreateControl(PropertyInfo info)
        {
            Panel container = new PanelBuilder().CreateControl(info);

            Label? lbl = new LabelBuilder().CreateControl(info);

            ClassPropertyControl? box = new ClassPropertyControlBuilder().CreateControl(info);

            if (lbl != null)
                container.Controls.Add(lbl);

            container.Controls.Add(box);
           

            box?.BringToFront();

            ClassPropertyControlContainer comBoxContainer = new ClassPropertyControlContainer(container, box, lbl);            

            return comBoxContainer;
        }


        public GenericContainer<ClassPropertyControl>? CreateControl(System.Type type)
        {
            Panel container = new PanelBuilder().CreateControl();            

            ClassPropertyControl? box = new ClassPropertyControlBuilder().CreateControl(type);
          
            container.Controls.Add(box);
          

            box?.BringToFront();

            ClassPropertyControlContainer comBoxContainer = new ClassPropertyControlContainer(container, box, null);

            return comBoxContainer;
        }
    }
}