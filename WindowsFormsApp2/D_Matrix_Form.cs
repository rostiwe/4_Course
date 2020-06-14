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
    public partial class D_Matrix_Form : Form
    {
        public D_Matrix_Form(int[,] a)
        {            
            InitializeComponent();
            dataGridView_Fill(a);
        }
        public void dataGridView_Fill(int[,] a)
        {
            dataGridView1.RowCount = a.GetLength(0);
            dataGridView1.ColumnCount = a.GetLength(1);
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    dataGridView1.Rows[i].Cells[j].Value = a[i, j];
        }
        public void UpdateData(int[,] a)
        {
            dataGridView_Fill(a);
        }

        private void D_Matrix_Form_Load(object sender, EventArgs e)
        {
            
        }
    }
}
