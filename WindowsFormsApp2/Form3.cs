using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;


namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        bool mark = false,DataGriedViewisChecking = true;
        static Random rnd = new Random();
        int[,] nums,D;
        System.Windows.Forms.Timer Timer;
        int x= 3, y = 3;
        D_Matrix_Form d_Matrix_Form;
        Form2 form2;
        public Form3(Form2 form2)
        {
            this.form2 = form2;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            nums = new int[3,3];
            nums = array_filling_rnd(nums);
            dataGridView_Fill(nums);
        }
        public static int[,] array_filling_rnd (int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i,j] =  rnd.Next(100);
            return a;
        }
        public void dataGridView_Fill(int[,] a)
        {
            DataGriedViewisChecking = false;
            dataGridView1.RowCount = a.GetLength(0);
            dataGridView1.ColumnCount = a.GetLength(1);
            try 
            { 
                int Number = 1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.HeaderCell.Value = "Row " + Number;
                    Number++;
                }
                Number = 1;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Value = "Column " + Number;
                    Number++;
                }
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error");
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    dataGridView1.Rows[i].Cells[j].Value = a[i,j];
            if (mark) 
                dataGridView1.TopLeftHeaderCell.Value = "D:";
            else
                dataGridView1.TopLeftHeaderCell.Value = "A:";
            DataGriedViewisChecking = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    Timer.Interval = Convert.ToInt32(textBox1.Text);
                }
                catch (Exception ex)
                {
                    Timer.Stop();
                    form2.Ex_Log(ex);
                    MessageBox.Show("Нужно Вводить цифры! ");
                    Timer.Start();
                }
            }
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {            
            x = Convert.ToInt32(numericUpDown2.Value);
            try
            {
                nums = New_array_filling_rnd(nums,x,y);
                dataGridView_Fill(nums);
                if (nums.Length>1)
                {
                    numericUpDown4.Visible = true;
                    if (numericUpDown3.Value > nums.Length - 2) numericUpDown3.Value = nums.Length - 2;
                    numericUpDown3.Maximum = nums.Length - 2;
                    if (numericUpDown4.Value > nums.Length - 1) numericUpDown4.Value = nums.Length - 1;
                    numericUpDown4.Maximum = nums.Length - 1;
                }
                else
                {
                    numericUpDown3.Value = 0;
                    numericUpDown3.Maximum = 0;
                    numericUpDown4.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
                form2.Ex_Log(ex);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            y = Convert.ToInt32(numericUpDown1.Value);
            try
            {
                nums = New_array_filling_rnd(nums, x, y);
                dataGridView_Fill(nums);
                if (nums.Length > 1)
                {
                    numericUpDown4.Visible = true;
                    if (numericUpDown3.Value > nums.Length - 2) numericUpDown3.Value = nums.Length - 2;
                    numericUpDown3.Maximum = nums.Length - 2;
                    if (numericUpDown4.Value > nums.Length - 1) numericUpDown4.Value = nums.Length - 1;
                    numericUpDown4.Maximum = nums.Length - 1;
                }
                else
                {
                    numericUpDown3.Value = 0;
                    numericUpDown3.Maximum = 0;
                    numericUpDown4.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
                form2.Ex_Log(ex);
            }
        }
        public static int[,] New_array_filling_rnd(int[,] a,int x, int y)
        {
            int[,] b = new int[x, y];
            for (int i = 0; i < b.GetLength(0); i++)
            {
                if (i == a.GetLength(0) || i > a.GetLength(0))
                {
                    for (int j = 0; j < b.GetLength(1); j++)
                    {
                        b[i, j] = rnd.Next(100);
                    }
                }
                else 
                {
                    for (int j = 0; j < b.GetLength(1); j++)
                    {
                        if (j == a.GetLength(1) || j > a.GetLength(1))
                            b[i, j] = rnd.Next(100);
                        else b[i, j] = a[i, j];
                    }
                }                
            }
            return b;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    Timer = new System.Windows.Forms.Timer() { Interval = Convert.ToInt32(textBox1.Text) };
                    Timer.Tick += Timer_Tick;
                }
                catch (Exception ex)
                {
                    form2.Ex_Log(ex);
                    Timer = new System.Windows.Forms.Timer() { Interval = 100 };
                    Timer.Tick += Timer_Tick;
                }
                finally
                {
                    Timer.Start();
                }
            }
            else
            {
                progressBar1.Value = 0;
                Timer.Stop();
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.ForeColor = SystemColors.WindowText;
            try
            {
                D = array_D_Created(nums);
                switch (comboBox1.Text)
                {
                    case ("Отображать справа"):
                        mark = false;
                        comboBox2.Visible = false;
                        dataGridView_Fill(nums);
                        D_right(D);                        
                        break;
                    case ("Отображать снизу"):
                        mark = false;
                        comboBox2.Visible = false;
                        dataGridView_Fill(nums);
                        D_bottom(D);                        
                        break;
                    case ("Отображать вместо"):
                        mark = true;
                        dataGridView_Fill(D);
                        comboBox2.Visible = true;                        
                        break;
                    case ("В отдельную форму"):
                        mark = false;
                        if (!(d_Matrix_Form == null || d_Matrix_Form.IsDisposed))
                        {
                            d_Matrix_Form.UpdateData(D);
                        }
                        else
                        {
                            comboBox2.Visible = false;
                            d_Matrix_Form = new D_Matrix_Form(D);
                            d_Matrix_Form.Show();
                        }                        
                        break;
                    case ("отоброжение"):
                        comboBox1.ForeColor = Color.Red;
                        MessageBox.Show("Нужно выбрать значение!");
                        break;
                    default:
                        MessageBox.Show("Выбор же дан. Он конечен, и больше функций я не написал. Ну зачем так делать?");
                        break;
                }
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error");
            }
        }
        public static int[,] array_D_Created(int[,] a)
        {
            int[,] D = new int[a.GetLength(0), a.GetLength(1)];
            int count = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (count < 10)
                    {
                        D[i, j] = a[i, j] + ((i + 1) * (j + 1));
                        count++;
                    }                        
                    else
                        D[i, j] = a[i, j] - ((i + 1) * (j + 1));

            return D;
        }
        void D_bottom(int[,] D)
        {
            DataGriedViewisChecking = false;
            int n = dataGridView1.RowCount;
            dataGridView1.RowCount += D.GetLength(0)+1;
            for (int j = 0; j< dataGridView1.ColumnCount;j++)
            dataGridView1.Rows[n - 1].Cells[j].Value = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[j].Value;
            for (int i = 0; i < D.GetLength(0); i++)
                for (int j = 0; j < D.GetLength(1); j++)
                    dataGridView1.Rows[i+n+1].Cells[j].Value = D[i, j];
            dataGridView1.Rows[n].Cells[0].Value = "Матрица D:";
            DataGriedViewisChecking = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            nums = array_filling_rnd(nums);
            dataGridView_Fill(nums);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (mark) D = Matrix_save(D,"D");
                else nums = Matrix_save(nums, "A");
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error");
            }
        }
        private int[,] Matrix_save(int[,] a,string name)
        {
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
            MessageBox.Show("Изменения внесены в матрицу "+name);
            return a;
        }
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text == "A:")
                    dataGridView_Fill(nums);
                else
                    dataGridView_Fill(D);
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGriedViewisChecking = false;
            try
            {
                if(nums.Length > 1)
                {
                    double buf;
                    int count = 0;
                    bool marks = false;
                    for (int i = 0; i < nums.GetLength(0); i++)
                        for (int j = 0; j < nums.GetLength(1); j++)
                        {
                            if (!(count< numericUpDown3.Value)&&!(count > numericUpDown4.Value))
                            {
                                try
                                {
                                    Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                                }
                                catch
                                {
                                    marks = true;
                                }
                                buf = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                                buf = 1 / buf;
                                if (marks && buf > 1)
                                    buf = Math.Round(buf);
                                dataGridView1.Rows[i].Cells[j].Value = buf.ToString();
                                marks = false;
                            }
                            count++;                                
                        }                         
                }
                else
                {
                    double buf = Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value);
                    buf = 1 / buf;
                    dataGridView1.Rows[0].Cells[0].Value = buf.ToString();
                }
            }
            catch (Exception ex)
            {
                form2.Ex_Log(ex);
                MessageBox.Show("Error");
            }
            DataGriedViewisChecking = true;
        }


        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown4.Minimum = numericUpDown3.Value + 1;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Maximum = numericUpDown4.Value - 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (mark) dataGridView_Fill(D);
            else dataGridView_Fill(nums);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В левой верхней части интерфейса есть 3 кнопки: “Создать случайный”, “Обновить”, “Подтвердить изменения в матрице”. Кнопка “Создать случайный” создаёт и добавляет на форму новую случайную матрицу вместо текущей. Кнопка “Обновить” обновляет отображение текущей матрицы. Кнопка “Подтвердить изменения в матрице” вносит внесённые в таблицу изменения в текущую матрицу. Так же там отображается 2 элемента numericUpDown для регулирования количества столбцов и строк в нашей матрице. Эти параметры лежат в диапазоне от 1 до 10, а при изменении параметра и массив и его отображение тут же меняются.Так же в этой части интерфейса есть CheckBox “Изменять со временем”, при нажатии на него начнёт заполняться шкала справа от него, а когда она будет, то создастся и отобразится новый массив с текущими параметрами(значения случайны).Время для заполнения показывает строка слева(изначально в ней значение 100).Это время в десятых долях секунды – значение 100 это 10 секунд. В правой части интерфейса мы видим кнопки “Построить матрицу D” и “ Запустить”. Над кнопкой “Построить матрицу D” находится поле для выбора варианта отображения матрицы D: “Отображать справа”,” Отображать снизу”,” Отображать вместо”,” в отдельную форму”.При нажатии кнопка реализует первую часть задания(Из элементов массива А(предусмотреть возможность ввода массива случайно и случайно с заданной частотой) сформировать массив D той же размерности по правилу: первые 10 элементов - Di = Ai + i, остальные - Di = Ai - i.).Кнопка “Запустить” реализует вторую часть задания (Заменить минимальный по модулю положительный элемент массива А нулем. Заменить элементы с k1-го по k2-й на обратные), k1 и k2 показаны с помощью numericUpDown, но как i1 и i2.");
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!DataGriedViewisChecking)
                return;
            MessageBox.Show("В таблицу внесены некоректные изменения");
        }

        void D_right(int[,] D)
        {
            DataGriedViewisChecking = false;
            int n = dataGridView1.ColumnCount;
            dataGridView1.ColumnCount += D.GetLength(1) + 1;
            for (int i = 0; i < D.GetLength(0); i++)
                for (int j = 0; j < D.GetLength(1); j++)
                    dataGridView1.Rows[i].Cells[j + n + 1].Value = D[i, j];
            dataGridView1.Rows[0].Cells[n].Value = "Матрица D:";
            DataGriedViewisChecking = true;
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if (progressBar1.Value == progressBar1.Maximum)
            {
                progressBar1.Value = progressBar1.Minimum;
                nums = array_filling_rnd(nums);
                dataGridView_Fill(nums);
            }
        }
        
    }
}
