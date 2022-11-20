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
    public class IEnumerableControlBuilder : IControlBuilder<IEnumerableControl>
    {
        public IEnumerableControl? CreateControl(PropertyInfo info)
        {
            IEnumerableControl? box = new IEnumerableControl(info);
            box.Dock = DockStyle.Top;

            return box;
        }
    }
}