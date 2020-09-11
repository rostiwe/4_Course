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
    public partial class Grafic : Form
    {
        double[] points;
        public Grafic(double[] points, int M)
        {
            InitializeComponent();
            this.points = points;
            chart1.Series[0].Points.Clear();
            for (int i = 0; i< points.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i + 1,points[i]);
            }
            if (M <= 6)
                chart1.Titles[0].Text = "Масштаб 1 к 1";
            else
                chart1.Titles[0].Text = "Масштаб 1 к 10^"+Convert.ToString(M-6);
        }
    }
}
