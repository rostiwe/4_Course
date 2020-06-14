using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Buf_classes
    {
    }
    class Matrix_D
    {
        public int[,] D { get;  private set; }
        public Matrix_D(int[,] D)
        {
            this.D = D;
        }
    }
}
