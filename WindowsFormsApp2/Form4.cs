using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form4 : Form
    {
        Form2 form2;
        public Form4(Form2 form2)
        {
            this.form2 = form2;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value*3600 + numericUpDown2.Value * 60 + numericUpDown3.Value >= (numericUpDown6.Value * 3600 + numericUpDown5.Value * 60 + numericUpDown4.Value))
            {
                MessageBox.Show("Начало больше конца");
                return;
            }
            form2.Pars(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown6.Value), Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown4.Value));
        }
    }
}
