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
    public partial class RemovibleControl : UserControl
    {
        public Button Button => this.btnRemove;

        public Control Control { get; }
        public RemovibleControl(Control control)
        {
            InitializeComponent();

            Control = control;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (Control != null)
            {
                this.pnlContainer.Controls.Add(Control);
                this.pnlContainer.AutoSize = true;
            }

        }
      
    }


    
}
