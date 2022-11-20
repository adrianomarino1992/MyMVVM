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
    public class RemovibleControlBuilder : IControlBuilder<RemovibleControl>
    {
        public RemovibleControl? CreateControl(PropertyInfo info)
        {            
            RemovibleControl? box = new RemovibleControl(null);
            box.Dock = DockStyle.Top;          

            return box;
        }

        public RemovibleControl? CreateControl(Control control)
        {
            RemovibleControl? box = new RemovibleControl(control);
            box.Dock = DockStyle.Top;
            box.AutoSize = true;
            return box;
        }
    }
}