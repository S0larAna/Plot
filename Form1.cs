using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plot
{
    public partial class Form1 : Form
    {
        public double a;
        public double b;
        public double max;
        public double min;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(A.Text);
                b = Convert.ToDouble(B.Text);
                max = Convert.ToDouble(Max.Text);
                min = Convert.ToDouble(Min.Text);
                if (max <= min) throw new Exception("The upper bound value is greater than (or equal to) the lower bound value");
                Plot.DrawGraph(min, max, a, b, zedGraphControl1);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void A_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(A.Modified) a = Convert.ToDouble(A.Text);
                Plot.DrawGraph(min, max, a, b, zedGraphControl1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void B_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (B.Modified) b = Convert.ToDouble(B.Text);
                Plot.DrawGraph(min, max, a, b, zedGraphControl1);
            }
            catch (Exception ex)
            {
            }
        }

        private void Max_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Max.Modified) max = Convert.ToDouble(Max.Text);
                Plot.DrawGraph(min, max, a, b, zedGraphControl1);
            }
            catch (Exception ex)
            {
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Min.Modified) min = Convert.ToDouble(Min.Text);
                Plot.DrawGraph(min, max, a, b, zedGraphControl1);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
