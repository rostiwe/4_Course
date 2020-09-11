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
        bool mark = true;
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
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранён");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e){
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            filename = openFileDialog1.FileName;
            string filetext = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = filetext;
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
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            richTextBox1.Text = "";
            MessageBox.Show("Ну всё");
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void лР3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientAppProtection3 clientAppProtection3 = new ClientAppProtection3(this);
            clientAppProtection3.Show();
        }

        public void Ex_Log (Exception ex)
        {
            mark = false;
            richTextBox1.Text += "Вемя записи: "+DateTime.Now.ToString() + "\n" + ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + ex.TargetSite + "\n" + "\n\r";

            mark = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                richTextBox1.SelectAll();
                richTextBox1.SelectionColor = Color.Black;
                string str = richTextBox1.Text.ToUpper();
                int x = 0, z = 0;
                while (true)
                {
                    if (str.Contains(textBox2.Text.ToUpper()))
                    {
                        str = str.Remove(str.IndexOf(textBox2.Text.ToUpper()), textBox2.Text.Length);
                        x++;
                    }
                    else break;
                }
                for (int i = 0; i < x; i++)
                {
                    richTextBox1.Find(textBox2.Text, z, RichTextBoxFinds.None);
                    richTextBox1.SelectionColor = Color.Red;
                    z = richTextBox1.Find(textBox2.Text, z, RichTextBoxFinds.None) + textBox2.Text.Length;
                }
                mark = true;
            }
            else MessageBox.Show("Строка поиска пуста");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (mark)
            {
                richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.Text.Length - 1, DateTime.Now.ToString() + " Ручная запись: \n");
                mark = false;
            }
            
        }

        private void лабораторнаяРабота3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4(this);
            Form4.Show();
        }

        public void Ex_Log(string Message, string Source, string TargetSite)
        {

            richTextBox1.Text += "Вемя записи: "+ DateTime.Now.ToString() + "\n" + Message + "\n" + Source + "\n"+ TargetSite + "\n" + "\n" + "\n";
        }
        public string GetLogString ()
        {
            return richTextBox1.Text;
        }
        public void Pars (int StartH, int StartM, int StartS, int EndH, int EndM, int EndS)
        {
            bool b = true;
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;
            int z = 0,x = 0,x1 = 0;
            while (true)
            {
                x = richTextBox1.Find("Вемя записи: ", z, RichTextBoxFinds.None);
                if (x == -1)
                {
                    MessageBox.Show("Попробуйте раньше");
                    return;
                }
                if (b)
                {
                    if (Convert.ToInt32(richTextBox1.Text.Substring(x + 24, 2)) > EndH)
                    {
                        MessageBox.Show("Все записи сделаны позже");
                        return;
                    }
                    else if (Convert.ToInt32(richTextBox1.Text.Substring(x + 24, 2)) == EndH)
                    {
                        if (Convert.ToInt32(richTextBox1.Text.Substring(x + 27, 2)) > EndM)
                        {
                            MessageBox.Show("Все записи сделаны позже");
                            return;
                        }
                        else if (Convert.ToInt32(richTextBox1.Text.Substring(x + 27, 2)) == EndM)
                        {
                            if (Convert.ToInt32(richTextBox1.Text.Substring(x + 30, 2)) > EndS)
                            {
                                MessageBox.Show("Все записи сделаны позже");
                                return;
                            }
                        }
                    }
                    b = false;
                }
                if (Convert.ToInt32(richTextBox1.Text.Substring(x + 24, 2)) > StartH) break;
                else if (Convert.ToInt32(richTextBox1.Text.Substring(x + 24, 2)) == StartH)
                {
                    if (Convert.ToInt32(richTextBox1.Text.Substring(x + 27, 2)) > StartM) break;
                    else if (Convert.ToInt32(richTextBox1.Text.Substring(x + 27, 2)) == StartM)
                    {
                        if (Convert.ToInt32(richTextBox1.Text.Substring(x + 30, 2)) >= StartS) break;
                    }
                }   
                z = x + 2;
            }
            z = x + 2;
            while (true)
            {
                x1 = richTextBox1.Find("Вемя записи: ", z, RichTextBoxFinds.None);
                if (x1 == -1)
                {
                    break;
                }
                if (Convert.ToInt32(richTextBox1.Text.Substring(x1 + 24, 2)) > EndH)
                {
                    break; 
                }
                else if (Convert.ToInt32(richTextBox1.Text.Substring(x1 + 24, 2)) == EndH)
                {
                    if (Convert.ToInt32(richTextBox1.Text.Substring(x1 + 27, 2)) > EndM)
                    {
                        break;
                    }
                    else if (Convert.ToInt32(richTextBox1.Text.Substring(x1 + 27, 2)) == EndM)
                    {
                        if (Convert.ToInt32(richTextBox1.Text.Substring(x1 + 30, 2)) > EndS)
                        {
                            break;
                        }
                    }
                }
                z = x1 + 2;
            }
            string mail = " ( Rostisla.lysenkov@mail.ru ) ";
            z = x;
            if (x1 == -1)
                x1 = richTextBox1.Text.Length;
            while (true)
            {
                if (richTextBox1.Find("String", z, x1, RichTextBoxFinds.None) == -1) break;
                else
                {
                    richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.Find("string", z, x1, RichTextBoxFinds.None) + 6, mail);
                    richTextBox1.Find("String", z, x1, RichTextBoxFinds.None);
                    richTextBox1.SelectionColor = Color.Red;
                    x1 += mail.Length;
                }
                z = richTextBox1.Find("string", z, x1, RichTextBoxFinds.None) + 2;
            }
            z = x;
            if (x1 == -1)
                x1 = richTextBox1.Text.Length;
            while (true)
            {
                if (richTextBox1.Find("String", z, x1, RichTextBoxFinds.None) == -1) break;
                else
                {
                    richTextBox1.Find("String", z, x1, RichTextBoxFinds.None);
                    richTextBox1.SelectionColor = Color.Red;
                }
                z = richTextBox1.Find("string", z, x1, RichTextBoxFinds.None) + 2;
            }
            z = x;
            if (x1 == -1)
                x1 = richTextBox1.Text.Length;
            while (true)
            {
                if (richTextBox1.Find(mail, z, x1, RichTextBoxFinds.None) == -1) break;
                else
                {
                    richTextBox1.Find(mail, z, x1, RichTextBoxFinds.None);
                    richTextBox1.SelectionColor = Color.Green;
                }
                z = richTextBox1.Find(mail, z, x1, RichTextBoxFinds.None) + 2;
            }
            MessageBox.Show("Готово");
        }

    }
}
