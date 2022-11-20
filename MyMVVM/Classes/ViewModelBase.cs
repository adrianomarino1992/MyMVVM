using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Linq.Expressions;


using MyMVVM.Attributes;
using MyMVVM.Classes.WinFormsHelpers;
using MyMVVM.Controls;
using MyMVVM.Delegates;
using MyMVVM.Exceptions;


using MyRefs.Extensions;

namespace MyMVVM.Classes
{
    public abstract class ViewModelBase
    {
        protected List<PropertyBind> _binds;

        public ViewModelBase()
        {
            _binds = new List<PropertyBind>();
        }

        public BaseContainer? GetControl<R>(Expression<Func<ViewModelBase, R>> expression)
        {
            if (expression is System.Linq.Expressions.MemberExpression exp)
            {
                if (exp.Member is PropertyInfo info)
                {
                    return _binds.FirstOrDefault(s => s.PropertyInfo.Equals(info))?.Container;
                }
            }

            return null;
        }

        public void UpdateValues()
        {
            _binds.ForEach(s =>
            {
                s.Container.SetValue(this, s.PropertyInfo);
            });
        }

        public void GetValues()
        {
            _binds.ForEach(s =>
            {
                if (
                    s.PropertyInfo.PropertyType.Equals(typeof(long)) ||
                    s.PropertyInfo.PropertyType.Equals(typeof(int)) ||
                    s.PropertyInfo.PropertyType.Equals(typeof(float)) ||
                    s.PropertyInfo.PropertyType.Equals(typeof(double))
                )
                {
                    s.PropertyInfo.SetValue(this,
                        System.Convert.ChangeType(s.Container.GetValue(s.PropertyInfo), s.PropertyInfo.PropertyType));
                    
                }
                else
                {
                    s.PropertyInfo.SetValue(this, s.Container.GetValue(s.PropertyInfo));
                }
            });
        }

        public void AppendControls(Control control)
        {

            foreach (PropertyInfo info in this.GetAllProperties()!.Reverse())
            {
                if (_binds.Any(s => s.PropertyInfo.GetHashCode() == info.GetHashCode() && s.PropertyInfo.Equals(info)))
                    continue;

                BaseContainer container = WinformsStatics.CreateWinFormsControl(info);
                _binds.Add(new PropertyBind(info, container!));
                control.Controls.Add(container.ControlContainer);
            }
        }





    }
}
