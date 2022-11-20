using System.Windows.Forms;
using System.Reflection;
using MyMVVM.Attributes;
using MyMVVM.Classes.WinFormsHelpers.Interfaces;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public class TextBoxBuilder : IControlBuilder<TextBox>
    {
        public TextBox? CreateControl(PropertyInfo info)
        {
            TextBox? box = CreateControl()!;

            string? labelText = LabelAttribute.GetLabel(info);
            string? placeholder = PlaceHolderAttribute.GetPlaceHolder(info);

            if (labelText == null)
                box.PlaceholderText = placeholder ?? info.Name;

            if (placeholder != null)
                box.PlaceholderText = placeholder;

            return box;
        }

        public TextBox? CreateControl()
        {
            TextBox? box = new TextBox();
            box.Dock = DockStyle.Top;

            return box;
        }
    }
}