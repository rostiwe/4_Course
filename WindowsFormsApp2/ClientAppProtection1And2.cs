using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WindowsFormsApp2
{
    public partial class ClientAppProtection1And2 : Form
    {
        Form2 form2;
        
        public ClientAppProtection1And2(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("При нажатие на кнопку \"Получить хэш\" в тектовой строке появится значение хэш-функции от лога ошибок, созданой по алгоритму SHA-512");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("При нажатие на кнопку \"Получить хэш\" вам будет предложено выбрать файл формата .txt, выбрав который вы получите в текстовой строке значение хэш-функции от содержимого файла, созданой по алгоритму SHA-512");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("При нажатие на кнопку \"Сравнить хэш\" будет сравнён введёный вами в текстовою строку хэш, с тем который получится от лога ошибок. Используется алгоритм SHA-512");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("При нажатие на кнопку \"Сравнить хэш\" вам будет предложено выбрать файл формата .txt, а значение хэш-функции содержимого этого файла будет сравнено с тем, что вы введёте в текстовую строку. Используется алгоритм SHA-512");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = GetHash(form2.GetLogString());
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error");
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            try
            {
                if (textBox3.Text == "")
                {
                    label2.Visible = true;
                    return;
                }
                string str = GetHash(form2.GetLogString());
                if (str == textBox3.Text)
                {
                    MessageBox.Show("Хэши равны");
                }
                else
                {
                    MessageBox.Show("Хэши не равны");
                }
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error");
            }
        }
        static string GetHash(string str)
        {
            byte[] data = Encoding.ASCII.GetBytes(str);
            SHA512 shaM = new SHA512Managed();
            byte[] result = shaM.ComputeHash(data);
            str = BitConverter.ToString(result);
            return str;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Text files(*.txt)|*.txt";
                if (openFile.ShowDialog() == DialogResult.Cancel) return;
                string filename = openFile.FileName;
                string filetext = System.IO.File.ReadAllText(filename);
                textBox2.Text = GetHash(filetext);
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            try
            {
                if (textBox4.Text == "")
                {
                    label3.Visible = true;
                    return;
                }
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Text files(*.txt)|*.txt";
                if (openFile.ShowDialog() == DialogResult.Cancel) return;
                string filename = openFile.FileName;
                string filetext = System.IO.File.ReadAllText(filename);
                string str = GetHash(filetext);
                if (str == textBox4.Text)
                {
                    MessageBox.Show("Хэши равны");
                }
                else
                {
                    MessageBox.Show("Хэши не равны");
                }
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error");
            }
        }
    }
}
