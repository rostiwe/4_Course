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
    public partial class Form2 : Form
    {
        ToolStripLabel datelabe1, timelabe1, infolabe1;
        ToolStripProgressBar toolStripProgressBar2;
        Timer Timer;
        
        void Timer_Tick(object sender, EventArgs e)
        {
            datelabe1.Text = DateTime.Now.ToLongDateString();
            timelabe1.Text = DateTime.Now.ToLongTimeString();
            toolStripProgressBar2.PerformStep();

        }
        public string filename;
        public Form2()
        {
            InitializeComponent();
            datelabe1 = new ToolStripLabel();
            timelabe1 = new ToolStripLabel();
            infolabe1 = new ToolStripLabel();
            toolStripProgressBar2 = new ToolStripProgressBar();
            infolabe1.Text = "текущая дата и время";
            statusStrip1.Items.Add(datelabe1);
            statusStrip1.Items.Add(timelabe1);
            statusStrip1.Items.Add(infolabe1);
            statusStrip1.Items.Add(toolStripProgressBar2);
            Timer = new Timer() { Interval = 10 };
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void лР1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientAppProtection1And2 ClientAppProtection1 = new ClientAppProtection1And2(this);
            ClientAppProtection1.Show();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, textBox2.Text);
            MessageBox.Show("Файл сохранён");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e){
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            filename = openFileDialog1.FileName;
            string filetext = System.IO.File.ReadAllText(filename);
            textBox2.Text = filetext;
            MessageBox.Show("Файл открыт");
        }

        private void лабораторнаяРабота2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);
            Form3.Show();
        }

        private void лабораторнаяРабота1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1(this);
            Form1.Show();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, textBox2.Text);
            textBox2.Text = "";
            MessageBox.Show("Ну всё");
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void лР3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientAppProtection3 clientAppProtection3 = new ClientAppProtection3(this);
            clientAppProtection3.Show();
        }

        public void Ex_Log (Exception ex)
        {
            textBox2.Text += ex.Message + "\n\r" + ex.Source + "\n\r" + ex.StackTrace + "\n\r" + ex.TargetSite + "\n\r" + "\n\r" + "\n\r";
        }
        public void Ex_Log(string Message, string Source, string TargetSite)
        {
            textBox2.Text += Message + "\n\r" + Source + "\n\r"+ TargetSite + "\n\r" + "\n\r" + "\n\r";
        }
        public string GetLogString ()
        {
            return textBox2.Text;
        }

    }
}
