using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunctionGraph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "X0";
            label2.Text = "XN";
            label3.Text = "DX";
            AllLeabelErorrClear();
        }

        private void AllLeabelErorrClear()
        {
            labelErorr1.Text = "";
            labelErorr2.Text = "";
            labelErorr3.Text = "";
        }

        public event Action act;
        private void button1_Click(object sender, EventArgs e)
        {
            double x0 = -10, xn = 10, dx = 0.1, x, y;
            AllLeabelErorrClear();
            int flagAct = 0;
            if (InputErorr(labelErorr1, () => x0 = double.Parse(textBox1.Text)))
                flagAct++;
            if (InputErorr(labelErorr2, () => xn = double.Parse(textBox2.Text)))
                flagAct++;
            if (InputErorr(labelErorr3, () => dx = double.Parse(textBox3.Text)))
                flagAct++;
            if (flagAct == 3)
            {
                this.chart1.Series[0].Points.Clear();//Очищаем точки
                x = x0;
                while (x<=xn)
                {
                    y = Math.Sin(x);
                    this.chart1.Series[0].Points.AddXY(x, y);
                    x += dx;
                }
            }
            

        }
        private bool InputErorr(Label label, Action act)
        {
            
            try
            {
                act();
                return true;
            }
            catch (Exception)
            {
                label.Text = "Введите число!";
                return false;
            }

        }
    }
}
