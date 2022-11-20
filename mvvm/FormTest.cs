using System.Windows.Forms;
using mvvm.Classes;

namespace mvvm
{
    public partial class FormTest : Form
    {
        TemplateViewModel _tp;
        public FormTest()
        {
            InitializeComponent();

            _tp = new TemplateViewModel
            {
                Email = "adrinao@gmail.com",
                Salario = 5000.5,
                Idades = new System.Collections.Generic.List<long>
                {
                    1, 4, 5
                },
                Carro = new Car()
            };


            panel1.AutoScroll = true;

            _tp.AppendControls(panel1);

            _tp.UpdateValues();


        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _tp.GetValues();

            MessageBox.Show("Olha ai");

        }
    }
}