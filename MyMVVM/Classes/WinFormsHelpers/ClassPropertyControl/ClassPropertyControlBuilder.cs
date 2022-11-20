using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using MyMVVM.Attributes;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;
using MyMVVM.Delegates;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public class ClassPropertyControlBuilder : IControlBuilder<ClassPropertyControl>
    {        
        public ClassPropertyControl? CreateControl(PropertyInfo info)
        {
            return CreateControl(info.PropertyType);
        }

        public ClassPropertyControl? CreateControl(System.Type type)
        {
            ClassPropertyControl? box = new ClassPropertyControl((ViewModelBase)System.Activator.CreateInstance(type)!);
            box.Dock = DockStyle.Top;

            return box;
        }

        public ClassPropertyControl? CreateControl(ViewModelBase viewModel)
        {
            ClassPropertyControl? box = new ClassPropertyControl(viewModel);
            box.Dock = DockStyle.Top;

            return box;
        }

    }
}