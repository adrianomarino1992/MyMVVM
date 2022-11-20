using MyMVVM.Attributes;
using MyMVVM.Controls;
using MyMVVM.Delegates;
using MyMVVM.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyRefs.Extensions;


namespace MyMVVM.Classes.WinFormsHelpers
{
    public class RemovibleControlContainer : GenericContainer<RemovibleControl>
    {
        private BaseContainer _children;

        public RemovibleControlContainer(BaseContainer container, Panel? panel, RemovibleControl? control, Label? label) : base(panel, control, label, ControlType.REMOVIBLE)
        {
            _children = container;
            this.RemoveButton = control.Button;
        }


        public override void SetValue(ViewModelBase @object, PropertyInfo info)
        {
            _children.SetValue(@object, info);
                
        }

        public override object? GetValue(PropertyInfo info)
        {
            return _children.GetValue(info);
        }

        
    }
}
