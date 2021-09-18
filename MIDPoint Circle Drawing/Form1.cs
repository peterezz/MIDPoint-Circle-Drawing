using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDPoint_Circle_Drawing
{
    public partial class Draw : Form
    {
        public Draw()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int xCenter = Convert.ToInt32(textBox1.Text);
            int yCenter = Convert.ToInt32(textBox2.Text);

            int radius = Convert.ToInt32(textBox3.Text);

            Point p1 = new Point(xCenter, yCenter);
            Bitmap Bit = new Bitmap(this.Width, this.Height);

            if (xCenter>= 0 & yCenter >= 0 & radius >= 0 )
            {
                circleMidPoint(p1, radius,Bit);
            
            }
            else
            {
                string message = "please enter positive numbers";
                string title = "Error";
                MessageBox.Show(message, title);
            }
        }

        private void circleMidPoint(Point p1, int radius,Bitmap Bit)
        {
            int x = 0;
            int y = radius;
            int p = 1 - radius;
            
            circlePlotPoints(p1.X, p1.Y, x, y,Bit);
            while(y>x)
            {
                x++;
                if (p<0) /*select E */
                {
                    p += 2 * x + 1;
                }
                else
                {   /*select SE */
                    y--;
                    p += 2 * (x - y) + 1;
                }
                
                circlePlotPoints(p1.X, p1.Y, x, y,Bit);

            }
;        }

        private void circlePlotPoints(int xCenter, int yCenter, int x, int y,Bitmap Bit)
        {
            
            Bit.SetPixel(xCenter + x, yCenter + y, Color.White);
            Bit.SetPixel(xCenter - x, yCenter + y, Color.White);
            Bit.SetPixel(xCenter + x, yCenter - y, Color.White);
            Bit.SetPixel(xCenter - x, yCenter - y, Color.White);
            Bit.SetPixel(xCenter + y, yCenter + x, Color.White);
            Bit.SetPixel(xCenter - y, yCenter + x, Color.White);
            Bit.SetPixel(xCenter + y, yCenter - x, Color.White);
            Bit.SetPixel(xCenter - y, yCenter - x, Color.White);
            pictureBox1.Image = Bit;



        }
        private void intVal(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            intVal(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            intVal(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            intVal(e);
        }
    }
}
