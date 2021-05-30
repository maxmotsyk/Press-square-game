using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MouseClick += MouseClickLeft;
        }

        private int x = 350, y = 200,i=0;

        private Label label = new Label();

        private Random random = new Random();

        private void MovingMouse(object sender, MouseEventArgs e)
        {

            int temp = random.Next(0, 5);
            switch (temp)
            {
                case 1:
                    if (x < this.ClientSize.Width - 100)
                    {
                        label.Location = new Point(x += 15, y);
                        label.Refresh();
                    }
                    break;
                case 2:

                    if (x > 100)
                    {
                        label.Location = new Point(x -= 15, y);
                        label.Refresh();
                    }
                    break;
                case 3:
                    if (y < this.ClientSize.Height - 100)
                    {
                        label.Location = new Point(x, y += 15);
                        label.Refresh();
                    }
                    break;
                case 4:
                    if (y > 100)
                    {
                        label.Location = new Point(x, y -= 15);
                        label.Refresh();
                    }
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   if(i<200)
            {
                Text = $"{++i}";

                if(i == 30)
                {
                    label.BackColor = Color.Transparent;
                }

                if (i == 90)
                {
                    label.BackColor = Color.DeepSkyBlue;
                }
            }
            else
            {
                timer1.Stop();
                Controls.Remove(label);
                MessageBox.Show(":((((((( ");
                x = 350;
                y = 200;
                i = 0;
            }
        }


        private void MouseClicRight(object sender, MouseEventArgs e)
        {
            Controls.Remove(label);
            MessageBox.Show("You Win!!!");
            x = 350;
            y = 200;
        }

        private void MouseClickLeft(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                    timer1.Enabled = true;
                    label.BackColor = Color.DeepSkyBlue;
                    label.Location = new Point(x, y);
                    label.MouseMove += MovingMouse;
                    label.MouseClick += MouseClicRight;
                    label.Size = new Size(50, 50);
                    Controls.Add(label);
            }
        }




    }
}
