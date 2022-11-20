using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using MyMVVM.Attributes;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;
using MyMVVM.Delegates;
using MyMVVM.Controls;

namespace MyMVVM.Classes.WinFormsHelpers
{

    public class ClassPropertyControlContainer : GenericContainer<ClassPropertyControl>
    {

        public ClassPropertyControlContainer(Panel? panel, ClassPropertyControl? control, Label? label) : base(panel, control, label, Enums.ControlType.CLASS)
        {

        }

        public override void SetValue(ViewModelBase @object, PropertyInfo info)
        {
            this.ControlContainer!.Controls.Remove(GenericControl);
            this.Control = new ClassPropertyControlBuilder().CreateControl((ViewModelBase)info.GetValue(@object)!);
            this.ControlContainer.Controls.Add(this.Control);
        }

        public void SetValue(ViewModelBase value)
        {
            this.ControlContainer!.Controls.Remove(GenericControl);
            this.Control = new ClassPropertyControlBuilder().CreateControl(value);
            this.ControlContainer.Controls.Add(this.Control);
        }

        public override object? GetValue(PropertyInfo info)
        {
            return this.GenericControl!.GetValue();
        }
    }
}