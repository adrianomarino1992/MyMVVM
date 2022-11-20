using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMVVM.Controls
{
    public partial class IEnumerableControl : UserControl
    {
        public string Label 
        {
            get => this.grpLabel.Text;
            set => this.grpLabel.Text = value ?? String.Empty;
        }

        public Type Type { get; init; }

        public PropertyInfo PropertyInfo { get; init; }

        public Button Button => this.btnAdd;

        List<BaseContainer> _itens;

        public void AddControl(BaseContainer container)
        {
            _itens.Add(container);
            this.grpLabel.Controls.Add(container.ControlContainer);
        }

        public void RemoveControl(BaseContainer container)
        {
            _itens.Remove(container);
            this.grpLabel.Controls.Remove(container.ControlContainer);
        }

        public List<BaseContainer> GetControls() => _itens;

        public IEnumerableControl(PropertyInfo property)
        {
            _itens = new List<BaseContainer>();
            this.PropertyInfo = property;
            this.Type = property.PropertyType;

            if (property.PropertyType.IsAssignableTo(typeof(System.Collections.IEnumerable)))
            {
                if (property.PropertyType.GetElementType() != null)
                    this.Type = property.PropertyType.GetElementType()!;

                if (property.PropertyType.GetGenericArguments().Any())
                    this.Type = property.PropertyType.GetGenericArguments().First();
            }
                        

            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
