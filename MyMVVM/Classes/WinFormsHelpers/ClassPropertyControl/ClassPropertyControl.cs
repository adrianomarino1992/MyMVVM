using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMVVM.Classes.WinFormsHelpers
{
    public partial class ClassPropertyControl : UserControl
    {
        
        public ViewModelBase Model { get; init; }
        public ClassPropertyControl(ViewModelBase viewModel)
        {
            InitializeComponent();
            Model = viewModel;
        }

        public ViewModelBase GetValue() 
        {
            Model.GetValues();
            return Model;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.AutoSize = true;
            Model.AppendControls(this);
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}
