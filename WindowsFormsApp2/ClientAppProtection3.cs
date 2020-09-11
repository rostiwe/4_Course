using System;
using System.Windows;
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
    public partial class ClientAppProtection3 : Form
    {
        TextBox textBox;
        List<Panel> Panels = new List<Panel>();
        List<TextBox> textBoxes = new List<TextBox>();
        List<TextBox> textBoxes2 = new List<TextBox>();
        List<TextBox> textBoxes3 = new List<TextBox>();
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        Form2 form2;
        Pen pen1, pen2;
        Graphics graphics;
        public ClientAppProtection3(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;
            pen1 = (new Pen(Color.Black, 5) { StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor, EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor });
            pen2 = (new Pen(Color.Red, 5) { StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor, EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor });
        }
        void PanelCriete(int x, int y, List<TextBox> textBoxes, int w = 0)
        {
            if (w == 0)
                w = panel1.Width - 20;
            Panels.Add(new Panel() { AutoSize = true, Width = w, Height = 60, Location = new Point(x, y) });
            panel1.Controls.Add(Panels[Panels.Count - 1]);
            textBoxes.Add(TextboxCriete(Panels[Panels.Count - 1], ScrollBars.None));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здесь реализован алгоритм подсчёта первых N членов арифметической прогрессии.\r\n Можно получить решение с визуальной состовляющей или без - для переключения нужно нажать соответсвующие кнопки.\r\n Так же можно переключаться с режима строгого следования алгоритма, в котором предпологается каждый раз расчитывать An а не вычитать из предыдущей d, на быстрый вариант. Для этого есть кнопки переключения (быстрый/долгий вариант).\r\nТак же нужно указать шаг прогрессии (d), первый член (a) и до какого члена считать");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Сначала идут проверки потом запускается основная часть программы (если нет проблем)
            textBox1.ForeColor = SystemColors.WindowText;
            textBox2.ForeColor = SystemColors.WindowText;
            textBox3.ForeColor = SystemColors.WindowText;
            if (!Numb_String_Chek(textBox1.Text))
            {
                textBox1.ForeColor = Color.Red;
                MessageBox.Show("Введено неверное значение для d. Это поле может содержать только цифры");
                return;
            }
            if (!Numb_String_Chek(textBox3.Text))
            {
                textBox3.ForeColor = Color.Red;
                MessageBox.Show("Введено неверное значение для a. Это поле может содержать только цифры");
                return;
            }
            if (!Numb_String_Chek(textBox2.Text))
            {
                textBox2.ForeColor = Color.Red;
                MessageBox.Show("Введён неверный номер. Это поле может содержать только цифры");
                return;
            }
            try
            {
                int N = Convert.ToInt32(textBox2.Text);
                if (N > 100)
                {
                    if (DialogResult.No == MessageBox.Show("Значение, введённое для количества поворений очень большое. Вы уверенны что хотите продолжить?", "Большие значения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        return;
                }
            }
            catch
            {
                if (DialogResult.No == MessageBox.Show("Значение, введённое для количества поворений очень большое. Вы уверенны что хотите продолжить?", "Большие значения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    return;
            }
            try
            {
                StartPlatinum();
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Ошибочка вылезла " + ex.Message);
            }

        }
        static bool Numb_String_Chek(string numberstring)
        {
            // Проверяет строку на наличие символов отличных от цифр
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
        void StartPlatinum()
        {
            // основная часть программы
            int[] d, a, n;
            a = FormatAdapter(textBox3);
            d = FormatAdapter(textBox1);
            n = FormatAdapter(textBox2);
            panel1.Controls.Clear();
            textBoxes.Clear();
            textBoxes2.Clear();
            textBoxes3.Clear();
            Panels.Clear();
            pictureBoxes.Clear();
            textBox = null;
            if ((n.Length == 1 && n[0] == 0))
            {
                MessageBox.Show(" n - 0! И что считать?");
            }
            if (radioButton1.Checked)
            {
                if (textBox == null)
                    textBox = TextboxCriete(panel1, ScrollBars.Vertical);
                if (radioButton4.Checked)
                {
                    NoGrafikCicleEasyMod(d, a, n, textBox);
                }
                else
                {
                    a = EasyCalculationA(d, a, n);                   
                    int[] resoult = { 0 };
                    textBox.Text = "Рекурсивный метод вызывается с параметрами d = " + StringMaker(d) + "; n = " + StringMaker(n) + "; значение для этого номера a = " + StringMaker(a) + "\r\n";
                    NoGrafikCicleHardMod(d, a, n, resoult, textBox);
                }

            }
            else
            {
                a = EasyCalculationA(d, a, n);
                int[] resoult = { 0 };
                GrafikCicleHardMod(d, a, n, resoult);
            }
        }
        void NoGrafikCicleHardMod (int[] d, int[] a, int[] n, int[] resoult, TextBox textBox)
        {
            // В тестовое поле последовательно выводится параметры с которыми вызывается функция и текущая сумма
            resoult = summ(resoult, a);
            if ((n.Length == 1 && n[0] == 1))
                textBox.Text += "Итоговый результат: " + StringMaker(resoult);
            else
            {
                a = difference(a, d);
                n = ArrDec(n);
                textBox.Text += "Рекурсивный метод вызывается с параметрами d = " + StringMaker(d) + "; n = " + StringMaker(n) + "; значение для этого номера a = " + StringMaker(a) + "; Текущая сумма " + StringMaker(resoult) + "\r\n";
                NoGrafikCicleHardMod(d, a, n, resoult, textBox);
            }

        }
        void NoGrafikCicleEasyMod(int[] d, int[] a, int[] n, TextBox textBox)
        {
            // Выводит в тектовое поле сразу результат суммы
            // Используется формулла суммы первых n членов арифметической прогрессии
            int[] resoult = EasyCalculationA(d, a, n);
            resoult = summ(a, resoult);
            resoult = multiplication(resoult, n);
            resoult = DivideByTwo(resoult);
            textBox.Text += StringMaker(resoult);

        }
        void GrafikCicleEasyMod(int[] d, int[] a, int[] n, int x = 0, int y = 0)
        {

        }
        void GrafikCicleHardMod(int[] d, int[] a, int[] n, int[] resoult, int x = 2, int y = 0)
        {
            PanelCriete(x, y, textBoxes);
            textBoxes[textBoxes.Count - 1].Text = "Рекурсивный метод вызывается с параметрами d = " + StringMaker(d) + "; n = " + StringMaker(n) + "; значение для этого номера a = " + StringMaker(a) + "; Cумма до выполнения " + StringMaker(resoult) + "\r\n";
            pictureBoxCriete(x + 200, y + 60, 50, 40);
            graphics = Graphics.FromImage(pictureBoxes[pictureBoxes.Count - 1].Image);
            graphics.DrawLine(pen1, 25, 39, 25, 5);
            PanelCriete(x, y + 100, textBoxes2, 300);
            resoult = summ(resoult, a);
            textBoxes2[textBoxes2.Count - 1].Text = "Cумма после выполнения " + StringMaker(resoult);
            n = ArrDec(n);
            a = difference(a, d);
            if ((n.Length == 1 && n[0] < 1))
            {
                pictureBoxCriete(x + 300, y + 100, 90, 60);
                graphics = Graphics.FromImage(pictureBoxes[pictureBoxes.Count - 1].Image);
                graphics.DrawLine(pen2, 90, 30, 5, 30);
                pictureBoxCriete(x + 390, y + 130, 10, 70);
                graphics = Graphics.FromImage(pictureBoxes[pictureBoxes.Count - 1].Image);
                graphics.DrawLine(pen2, 5, 70, 5, 5);
                PanelCriete(x + 200, y + 200, textBoxes3, 300);
                textBoxes3[textBoxes3.Count - 1].Text = "Всё! Итоговая сумма - " + StringMaker(resoult);
                return;
            }
            else
            {
                PanelCriete(x + 450, y + 100, textBoxes3, 300);
                textBoxes3[textBoxes3.Count - 1].Text = "N - уменьшился и теперь его значение  " + StringMaker(n) + "\r\nПсочитали не всё Вызываем заного!";
                pictureBoxCriete(x + 300, y + 100, 150, 60);
                graphics = Graphics.FromImage(pictureBoxes[pictureBoxes.Count - 1].Image);
                graphics.DrawLine(pen1, 150, 30, 5, 30);
                pictureBoxCriete(x + 450, y + 160, 300, 40);
                graphics = Graphics.FromImage(pictureBoxes[pictureBoxes.Count - 1].Image);
                graphics.DrawLine(pen2, 150, 35, 150, 5);
            }

            y += 200;
            GrafikCicleHardMod(d, a, n, resoult, x, y);
        }
        TextBox TextboxCriete(Panel panel, ScrollBars scrolltype)
        {
            // Создаёт эллемент textBox в panel
            TextBox textBox = new TextBox { Location = new Point(0, 0), Multiline = true, Dock = DockStyle.Fill, ReadOnly = true, BackColor = panel1.BackColor, ScrollBars = scrolltype };
            panel.Controls.Add(textBox);
            return textBox;
        }
        void pictureBoxCriete(int x, int y, int w, int h)
        {
            pictureBoxes.Add(new PictureBox() { AutoSize = true, Width = w, Height = h, Location = new Point(x, y), BorderStyle = BorderStyle.None,Image = new Bitmap(w,h) });
            panel1.Controls.Add(pictureBoxes[pictureBoxes.Count - 1]);
        }

        int[] FormatAdapter(TextBox t)
        {
            // Переводит строку в массив цифр
            // Логика прописанна в int[] StandartCheck
            int n = t.Text.Length / 6 + 1;

            if (t.Text.Length % 6 == 0)
                n--;
            int[] x = new int[n];
            for (int i = 0; i < x.Length; i++)
            {
                if (i == x.Length - 1)
                {
                    x[i] = Convert.ToInt32(t.Text.Substring(0, t.Text.Length - 6 * i));
                }
                else
                {
                    x[i] = Convert.ToInt32(t.Text.Substring((t.Text.Length) - 6 * (i + 1), 6));
                }
            }
            return x;
        }
        int[] FormatAdapter(string t)
        {
            // Переводит строку в массив цифр
            // Логика прописанна в int[] StandartCheck
            int n = t.Length / 6 + 1;

            if (t.Length % 6 == 0)
                n--;
            int[] x = new int[n];
            for (int i = 0; i < x.Length; i++)
            {
                if (i == x.Length - 1)
                {
                    x[i] = Convert.ToInt32(t.Substring(0, t.Length - 6 * i));
                }
                else
                {
                    x[i] = Convert.ToInt32(t.Substring((t.Length) - 6 * (i + 1), 6));
                }
            }
            return x;
        }
        int[] summ(int[] x, int[] y)
        {
            // Суммирует два больших числа
            // Логика прописанна в int[] StandartCheck
            int[] resoult;
            if (x.Length >= y.Length)
                resoult = new int[x.Length];
            else resoult = new int[y.Length];
            for (int i = 0; i < resoult.Length; i++)
            {
                if (i == x.Length || i == y.Length)
                {
                    if (x.Length > y.Length)
                    {
                        for (int j = i; j < x.Length; j++)
                            resoult[j] = x[j];
                        break;
                    }
                    else if (x.Length < y.Length)
                    {
                        for (int j = i; j < y.Length; j++)
                            resoult[j] = y[j];
                        break;
                    }
                }
                resoult[i] = x[i] + y[i];
            }
            resoult = StandartCheck(resoult);
            return resoult;

        }
        T[] ArrIncrease<T>(T[] x)
        {
            // Увеличивает размерность массива
            // В последную ячейку записывается значение по умолчанию для данного типа
            T[] y = new T[x.Length + 1];
            for (int i = 0; i < x.Length; i++)
            {
                y[i] = x[i];
            }
            return y;
        }
        T[] Arrdecrease<T>(T[] x)
        {
            if (x.Length == 1) return x;
            // Удаляет последную ячейку массива
            T[] y = new T[x.Length - 1];
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = x[i];
            }
            return y;
        }

        int[] StandartCheck(int[] x)
        {
            // Проверяет массив на соответствие логике программы
            // Если число отрицательное (определяется по старшему члену) то все члены переводятся в отрицательные значения
            // как если разделить отрицательное число на сумму произведения разряда на 10^6 (по 6 цифр в разряде)
            // Аналогично с положительными
            if (x[x.Length - 1] == 0 && x.Length == 1)
                return x;
            if (x[x.Length - 1] > 0)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] >= 1000000)
                    {
                        int buf1 = x[i] % 1000000;
                        int buf2 = (x[i] - buf1) / 1000000;

                        if (i == x.Length - 1)
                        {
                            x = ArrIncrease(x);
                            x[i] = buf1;
                            x[i + 1] += buf2;
                            return x;
                        }
                        x[i] = buf1;
                        x[i + 1] += buf2;
                    }
                    if (x[i] < 0)
                    {
                        for (int j = i; j < x.Length; j++)
                        {
                            if (x[j] > 0)
                            {
                                x[j]--;
                                for (int j1 = j - 1; j1 >= i; j1--)
                                {
                                    if (j1 == i)
                                    {
                                        x[j1] += 1000000;
                                    }
                                    else
                                    {
                                        x[j1] += 999999;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
            else if (x[x.Length - 1] < 0)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] <= -1000000)
                    {
                        int buf1 = x[i] % 1000000;
                        int buf2 = (x[i] + buf1) / 1000000;

                        if (i == x.Length - 1)
                        {
                            x = ArrIncrease(x);
                            x[i] = buf1;
                            x[i + 1] += buf2;
                            return x;
                        }
                        x[i] = buf1;
                        x[i + 1] += buf2;
                    }
                    if (x[i] > 0)
                    {
                        for (int j = i; j < x.Length; j++)
                        {
                            if (x[j] < 0)
                            {
                                x[j]++;
                                for (int j1 = j - 1; j1 >= i; j1--)
                                {
                                    if (j1 == i)
                                        x[j1] += -1000000;
                                    else
                                        x[j1] += -999999;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = x.Length - 1; i >= 0; i--)
                {

                    if (x[i] == 0 && x.Length!=1)
                    {
                        x = Arrdecrease(x);
                    }
                    else break;
                }
                return StandartCheck(x);
            }
            for (int i = x.Length - 1; i >= 0; i--)
            {
                if (x[i] == 0 && x.Length != 1) x = Arrdecrease(x);
                else break;
            }
            return x;
        }
        Int64[] StandartCheck(Int64[] x)
        {
            if (x[x.Length - 1] == 0 && x.Length == 1)
                return x;
            // Проверка массива для умнажения
            if (x == null)
            {
                throw new System.ArgumentException("тут null пришёл", "n");
            }
            if (x[x.Length - 1] > 0)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] >= 1000000)
                    {
                        Int64 buf1 = x[i] % 1000000;
                        Int64 buf2 = (x[i] - buf1) / 1000000;

                        if (i == x.Length - 1)
                        {
                            x = ArrIncrease(x);
                            x[i] = buf1;
                            x[i + 1] += buf2;
                        }
                        else
                        {
                            x[i] = buf1;
                            x[i + 1] += buf2;
                        }
                    }
                    if (x[i] < 0)
                    {
                        for (int j = i; j < x.Length; j++)
                        {
                            if (x[j] > 0)
                            {
                                x[j]--;
                                for (int j1 = j - 1; j1 >= i; j1--)
                                {
                                    if (j1 == i)
                                    {
                                        x[j1] += 1000000;
                                    }
                                    else
                                    {
                                        x[j1] += 999999;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
            else if (x[x.Length - 1] < 0)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] <= -1000000)
                    {
                        Int64 buf1 = x[i] % 1000000;
                        Int64 buf2 = (x[i] + buf1) / 1000000;

                        if (i == x.Length - 1)
                        {
                            x = ArrIncrease(x);
                            x[i] = buf1;
                            x[i + 1] += buf2;
                        }
                        else
                        {
                            x[i] = buf1;
                            x[i + 1] += buf2;
                        }
                    }
                    if (x[i] > 0)
                    {
                        for (int j = i; j < x.Length; j++)
                        {
                            if (x[j] < 0)
                            {
                                x[j]++;
                                for (int j1 = j - 1; j1 >= i; j1--)
                                {
                                    if (j1 == i)
                                        x[j1] += -1000000;
                                    else
                                        x[j1] += -999999;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            else 
            {
                for (int i = x.Length - 1; i >= 0; i--)
                {

                    if (x[i] == 0 && x.Length != 1)
                    {
                        x = Arrdecrease(x);
                    }
                    else break;
                }
                return StandartCheck(x);
            }
            for (int i = x.Length - 1; i >= 0; i--)
            {
                if (x[i] == 0 && x.Length != 1) x = Arrdecrease(x);
                else break;
            }
            return x;
        }
        string StringMaker(int[] x)
        {
            // Переводит массив назад в строку
            string str = "";
            for (int i = x.Length - 1; i > -1; i--)
            {
                if ((i != x.Length - 1) && (x[i] < 100000))
                {
                    int buf = x[i], count = 6;
                    do
                    {
                        buf = buf / 10;
                        count--;
                    } while (buf != 0);
                    while (count != 0)
                    {
                        str += "0";
                        count--;
                    }
                    str += x[i];
                }
                else
                {
                    str += x[i];
                }

            }
            return str;
        }
        string StringMaker(Int64[] x)
        {
            // Переводит массив назад в строку
            string str = "";
            for (int i = x.Length - 1; i > -1; i--)
            {
                if ((i != x.Length - 1) && (x[i] < 100000))
                {
                    Int64 buf = x[i], count = 6;
                    do
                    {
                        buf = buf / 10;
                        count--;
                    } while (buf != 0);
                    while (count != 0)
                    {
                        str += "0";
                        count--;
                    }
                    str += x[i];
                }
                else
                {
                    str += x[i];
                }

            }
            return str;
        }
        //int[] HardCalculationA(int[] d, int[] a, int[] n)
        //{
        //    // Высчитывается значение эллемента арифметической последовательности по номеру и начальному значению
        //    // Вариант невероятно долгий
        // Не используется
        //    int[] n1 = new int[n.Length];
        //    Array.Copy(n, n1, n.Length);
        //    int[] a1 = new int[a.Length];
        //    Array.Copy(a, a1, a.Length);
        //    bool first = true;
        //    for (int i = 0; i < n1.Length; i++)
        //    {
        //        if (first)
        //            while (n1[i] > 1)
        //            {
        //                a1 = summ(a1, d);
        //                n1[i]--;
        //                if (n1[i] == 1)
        //                    first = false;
        //            }
        //        else
        //            while (n1[i] > 0)
        //            {
        //                a1 = summ(a1, d);
        //                n1[i]--;
        //            }
        //        if (i != (n1.Length - 1))
        //            if (n1[i + 1] > 0)
        //            {
        //                n1[i + 1]--;
        //                n1[i] = 1000000;
        //                i = -1;
        //            }
        //    }
        //    return a1;
        //}
        int[] EasyCalculationA(int[] d, int[] a, int[] n)
        {
            return summ(a, multiplication(d, ArrDec(n)));
        }
        int[] ArrDec(int[] n)
        {
            // Декримент большого числа записаного в массиве (по степеням 10^6)
            int[] Nbuf = new int[n.Length];
            Array.Copy(n, Nbuf, n.Length);
            if (Nbuf[0] > 0)
            {
                Nbuf[0]--;
                return Nbuf;
            }
            if (Nbuf.Length < 2)
            {
                throw new System.ArgumentException("Было переданно 0-е значение номера. Что-то не так!", "n");
            }
            else
            {
                for (int i = 1; i < Nbuf.Length; i++)
                {
                    if (Nbuf[i] > 0)
                    {
                        Nbuf[i]--;
                        for (int j = i - 1; j > -1; j--)
                            Nbuf[j] = 999999;

                    }
                    if (i == Nbuf.Length - 1 && Nbuf[i] == 0)
                    {
                        return Arrdecrease(Nbuf);
                    }

                }
                return Nbuf;
            }

        }
        int[] difference(int[] x, int[] y)
        {
            // Разность двух больших чисел представленных в массиве (по степеням 10^6)
            int[] resoult;
            if (x.Length >= y.Length)
                resoult = new int[x.Length];
            else resoult = new int[y.Length];
            for (int i = 0; i < resoult.Length; i++)
            {
                if (i == x.Length || i == y.Length)
                {
                    if (x.Length > y.Length)
                    {
                        for (int j = i; j < x.Length; j++)
                            resoult[j] = x[j];
                        break;
                    }
                    else if (x.Length < y.Length)
                    {
                        for (int j = i; j < y.Length; j++)
                            resoult[j] = -y[j];
                        break;
                    }
                }
                resoult[i] = x[i] - y[i];
            }
            resoult = StandartCheck(resoult);
            return resoult;

        }
        int[] multiStep(int[] x, int Y, int n)
        {
            // Шаг произведения. 
            // В результат записывается произведение ячейки массива x на y.
            // Int64 используется что бы избежать переполнения
            Int64 y = Convert.ToInt64(Y);
            Int64[] Preresoult = new Int64[x.Length + n];
            for (int i = 0; i < n; i++)
                Preresoult[i] = 0;
            for (int i = 0; i < x.Length; i++)
            {
                Preresoult[i + n] = x[i] * y;
            }
            Preresoult = StandartCheck(Preresoult);
            int[] resoult = new int[Preresoult.Length];
            for (int i = 0; i < Preresoult.Length; i++)
                resoult[i] = Convert.ToInt32(Preresoult[i]);
            return resoult;
        }
        int[] multiplication(int[] x, int[] y)
        {
            // Основной цикл произведения больших чисел (числа представленны ввиде массивов, где каждая ячейка разряд 10^6)
            // Первый массив будет умножаться на значчение ячейки второго и сдвигаться на индекс ячейки в другом методе
            // Здесь будет разделение в цикли на шаги произведения
            int[] resoult = multiStep(x, y[y.Length - 1], y.Length - 1);
            if (y.Length >= 2)
            {
                for (int i = y.Length - 2; i >= 0; i--)
                {
                    int[] buf = multiStep(x, y[i], i);
                    for (int j = i; j < buf.Length; j++)
                        resoult[j] += buf[j];
                }
                resoult = StandartCheck(resoult);
            }
            return resoult;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] d, a, n;
            a = FormatAdapter(textBox3);
            d = FormatAdapter(textBox1);
            n = FormatAdapter(textBox2);
            int a1;
            try
            {
                a1 = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Очень много точек, график не построить");
                return;
            }
            int leng = Convert.ToString(Point_Count(d, a, FormatAdapter(a1.ToString()))).Length;
            double[] points = new double[a1];
            points[points.Length - 1] = First_pointmacker(Point_Count(d, a, FormatAdapter(a1.ToString())));
            for (int i = 1; i < a1;i++)
            {
                points[i-1] = pointmacker(Point_Count(d, a, FormatAdapter(i.ToString())), leng);
            }
            Grafic grafic = new Grafic(points,leng);
            grafic.Show();
        }
        private double First_pointmacker(string str)
        {
            if (str.Length > 6)
                str = str.Substring(0, 6);
            return Convert.ToDouble(str);
        }
        private double pointmacker (string str,int leng)
        {
            if (leng - str.Length > 6)
                return Convert.ToDouble(0);
            if (str.Length>6)
            str = str.Substring(0, 6 - (leng - str.Length));
            return Convert.ToDouble(str);
        }
        string Point_Count(int[] d, int[] a, int[] n)
        {
            // Выводит в тектовое поле сразу результат суммы
            // Используется формулла суммы первых n членов арифметической прогрессии
            int[] Nbuf = new int[n.Length];
            Array.Copy(n, Nbuf, n.Length);
            int[] d1 = new int[d.Length];
            Array.Copy(d, d1, d.Length);
            int[] a1 = new int[a.Length];
            Array.Copy(a, a1, a.Length);
            int[] n1 = new int[n.Length];
            Array.Copy(n, n1, n.Length);
            int[] resoult = EasyCalculationA(d1, a1, n1);
            resoult = summ(a1, resoult);
            resoult = multiplication(resoult, n1);
            resoult = DivideByTwo(resoult);
            return StringMaker(resoult);

        }

        int[] DivideByTwo(int[] x)
        {
            // Деление на 2
            bool triger = false;
            for (int i = x.Length - 1; i >= 0; i--)
            {
                if(triger)
                {
                    if (x[i] % 2 == 1)
                        triger = true;
                    x[i] = x[i] / 2;
                    x[i] += 500000;
                }
                else
                {
                    if (x[i] % 2 == 1)
                        triger = true;
                    x[i] = x[i] / 2;
                }
            }
            return StandartCheck(x);
        }

        
    }
}
