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
    public partial class Form1 : Form
    {
        public string textbox1, textbox2, textbox3, textbox4;

        Form2 form2;

        public Form1(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Слова надо вводить");
                return;
            }
            try
            {
                textBox10.Text = "";
                textBox9.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                string[] resoult = Shake(textBox7.Text, textBox8.Text);
                string a = "" + textBox7.Text, b = "" + textBox8.Text;
                if (a != "" && b != "")
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        textBox5.Text += "\r\n" + Convert.ToInt32(a[i]);
                    }
                    for (int i = 0; i < b.Length; i++)
                    {
                        textBox6.Text += "\r\n" + Convert.ToInt32(b[i]);
                    }
                }
                textBox10.Text += resoult[0];
                textBox9.Text += resoult[1];
            }
            catch(Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a, b, c;            
            if (!Numb_String_Chek(textBox11.Text))
            {                
                MessageBox.Show("Введёное значение неверно. Попробуй снова!");
                return;
            }
            try
            {
                MessageBox.Show("Вторая цифра числа: " + textBox11.Text[1]);
                numb_entering(out a, "A", textBox12.Text, form2);
                numb_entering(out b, "B", textBox13.Text, form2);
                numb_entering(out c, "C", textBox14.Text, form2);
            }
            catch(Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error: Что то не так с введённым числом");
                return;
            }
            if (a == 0|| b == 0|| c == 0) return;
            try
            {
                a = big_numb_Mod(textBox11.Text, a, form2);
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error: Beda s a");
                return;
            }
            try
            {
                b = big_numb_Mod(textBox11.Text, b, form2);
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error: Beda s b");
                return;
            }
            try
            {
                c = big_numb_Mod(textBox11.Text, c, form2);                
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error: Beda s c");
                return;
            }
            MessageBox.Show(stringmaking(a,"A")+ stringmaking(b, "B")+ stringmaking(c, "C"));

        }
        static string stringmaking (int x, string name)
        {
            if (x == 0)
                return ("Делится на "+ name + ".");
            return ("Не делится на " + name+", остаток: "+ x+".");
        }
        static int big_numb_Mod(string numb, int x, Form2 form2)
        {
            Int64 resoult = 0, buf, resoult_buf = 0;
            int n = int_in_string_counting(numb);
            if (n > 1)
            {
                int ost = ostot_1000000(x);
                for (int i = 0; i < n; i++)
                {
                    buf = 1;
                    for (int j = 0; j < i; j++)
                    {
                        buf *= ost;
                        buf %= x;
                    }
                    if (i != (n - 1))
                        resoult_buf = Convert.ToInt64(numb.Substring((numb.Length) - (i + 1) * 6, 6)) % x;
                    else if (numb.Length % 6 == 0) resoult_buf = Convert.ToInt64(numb.Substring(0, 6));
                    else
                    {
                        try
                        {
                            resoult_buf = Convert.ToInt64(numb.Substring(0, numb.Length % 6));
                        }
                        catch (Exception ex)
                        {
                            form2.Ex_Log(ex);
                            MessageBox.Show("Ошибочка вылезла " + ex.Message + "    numb.Length = " + numb.Length+" i = "+i);
                            return 1;
                        }

                    }
                    resoult += resoult_buf * buf;
                    resoult %= x;
                }
            }
            else
            {
                resoult = (Convert.ToInt32(numb) % x);
            }
            return Convert.ToInt32(resoult);
        }
        static int int_in_string_counting(string str)
        {
            int x;
            if ((str.Length % 6) > 0)
                x = str.Length / 6 + 1;
            else x = str.Length / 6;
            return x;
        }
        static int ostot_1000000(int x)
        {
            x = 1000000 % x;
            return x;
        }
        static bool Numb_String_Chek(string numberstring)
        {
            if (numberstring == "") return false;
            foreach (char a in numberstring)
            {
                if (Convert.ToInt32(a) > 57 || Convert.ToInt32(a) < 48)
                {
                    return false;
                }
            }            
            return true;
        }
        static void numb_entering (out int x, string name,string a, Form2 form2)
        {
            try
            {
                 x = Convert.ToInt32(a);
                if (x == 0) MessageBox.Show("На 0 не делим. Поменяйте строку "+ name);
            }
            catch(Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Введённое для строки "+ name + " значение не подходит. Попробуйте ещё раз"); x = 0; 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            for (int i = 10; i<100;i++)
            {
                int x = i * 2;
                int y = i * 3;
                if (Convert.ToString(x).EndsWith("8") && Convert.ToString(y).EndsWith("4"))
                    textBox15.Text += (" " + i);
            }
            if (textBox15.Text == "") textBox15.Text = "Таких нет";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В этой вкладке представлены решения двух задач. В первой  вы вводите число в левую верхнюю строку и 3 других числа в 3 строки лежащих под ней. По нажатию кнопки «вперёд» выведется сообщение с второй цифрой первого числа, и делится ли оно на остальные 3. В второй вам покажут по нажатию кнопки «часть 2», вам покажут решение задачи сформулированной следующим образом «Найти все двухзначные числа, которые при умножении на 2 заканчиваются на 8, а при умножении на 3 - на 4.».");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("При нажатие кнопки программа обрабатывает введенные слова следующим образом: каждая буква слова представляется в виде кода символа (они выводятся под словами), после чего соответствующие буквы побитого складываются, а итог + хвост большего слова выводятся (хвост также выводится отдельно).");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        public static string[] Shake(string Name, string SurName)
        {
            string[] resoult = new string[2];
            resoult[0] = "";
            resoult[1] = "";           
            for (int i = 0; i < Name.Length; i++)
            {
                resoult[0] += Convert.ToChar(Name[i] ^ SurName[i]);
                if (SurName.Length == (i + 1) && (i + 1) != Name.Length)
                {
                    resoult[1] += Name.Substring((i + 1), (Name.Length - (i + 1)));
                    break;
                }
                if (Name.Length == (i + 1) && (i + 1) != SurName.Length)
                    resoult[1] += SurName.Substring((i + 1), (SurName.Length - (i + 1)));//
            }
            return resoult;
        }
    }
}
