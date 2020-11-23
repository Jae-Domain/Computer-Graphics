using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Janelle Domantay Computer Graphics HW
namespace mandelbrot
{
    public partial class Mandelbrot : Form
    {
        public Mandelbrot()
        {
            InitializeComponent();
        }

        //Global Variables
        bool itC = false; //iterative coloring

        //range and start value of x and y user coordinates
        double xRange = 4.0;
        double yRange = 4.0;
        double xBegin = -2;
        double yBegin = -2;

        Bitmap bm;
        private void Mandelbrot_Load(object sender, EventArgs e)
        {
            bm = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height);
            using (Graphics g = Graphics.FromImage(bm))
            {
                if (itC)
                {
                    g.Clear(Color.Black);
                }
                else
                {
                    g.Clear(Color.CadetBlue); //clears canvas, sets convergence color
                }

                //declare variables

                //set zoom range
                xRange = Convert.ToDouble(userBox2.Text) - Convert.ToDouble(userBox1.Text);
                xBegin = Convert.ToDouble(userBox1.Text);

                yRange = Convert.ToDouble(userBox4.Text) - Convert.ToDouble(userBox3.Text);
                yBegin = Convert.ToDouble(userBox3.Text);

                double dX = (xRange / picCanvas.ClientSize.Width);
                double dY = (yRange / picCanvas.ClientSize.Height);

                //user coordinates
                double c1 = 0;
                double c2 = 0;
                double x = 0;
                double y = 0;
                double xn = 0;
                double yn = 0;

                double mag = 0;

                //calculate user coordinates

                //set upper threshold
                const int T = 50;
                //number of generations
                const int N = 100;

                //compute next generation
                //scan line
                for (int j = 0; j < picCanvas.ClientSize.Height; ++j) //c2
                {
                    
                    for (int k = 0; k < picCanvas.ClientSize.Width; ++k) // c1
                    {
              
                        //calculate user coordinates
                        c1 = Math.Round(xBegin + (k * dX), 5);
                        c2 = Math.Round(yBegin + (j * dY), 5);

                        //set x and y
                        x = 0;
                        y = 0;
                        //compute next generation
                        for (int i = 0; i < N; ++i) //iterations
                        {
                            xn = Math.Round(Math.Pow(x, 2) - Math.Pow(y, 2) + c1, 5);
                            yn = Math.Round(2 * (x * y) + c2, 5);
                            mag = Math.Round(Math.Pow(xn, 2) + Math.Pow(yn, 2), 5);

                            if (mag > T)
                            {
                                if (itC)
                                {
                                    switch (i % 5) 
                                    {
                                        case 0:
                                            bm.SetPixel(k, j, Color.Turquoise);
                                            break;
                                        case 1:
                                            bm.SetPixel(k, j, Color.DeepPink);
                                            break;
                                        case 2:
                                            bm.SetPixel(k, j, Color.LightGreen);
                                            break;
                                        case 3:
                                            bm.SetPixel(k, j, Color.BlueViolet);
                                            break;
                                        case 4:
                                            bm.SetPixel(k, j, Color.PowderBlue);
                                            break;
                                        default:
                                            bm.SetPixel(k, j, Color.PeachPuff);
                                            break;
                                    }
                                }
                                else
                                {
                                    bm.SetPixel(k, j, Color.LightPink);
                                }
                                i = N; //exit iterations
                            }

                            if (mag == 0) //operates under the assumption that if magnitude = 0, it will stay 0 for 100 iterations in order to speed up iterations
                            {
                                i = N;
                            }
                            x = xn;
                            y = yn;
                        }
                    }
                }
            }
            picCanvas.Image = bm; //updates canvas image
        }

        private void iterativeCheck_CheckedChanged(object sender, EventArgs e)
        {
            itC = !itC; //toggles iterative coloring
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Mandelbrot_Load(sender, e);
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {           
                //get position of mouse
                this.Cursor = new Cursor(Cursor.Current.Handle); //sets cursor to mouse in relation to canvas
                Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y);
                Cursor.Clip = new Rectangle(this.Location, this.Size);

       
                //convert to picCanvas coordinates location 

                coordinateBox.Text = e.X + ", " + e.Y; //box coordinates for zoom

                double dX = (xRange / picCanvas.ClientSize.Width);
                double dY = (yRange / picCanvas.ClientSize.Height);

                //convert screen coordinates to user coordinates
                double uX = Math.Round(xBegin + (e.X * dX), 5);
                double uY = Math.Round(yBegin + (e.Y * dY), 5);

                //identify scale
                double scale = zoomScale.Value * 4;

                //update textboxes
                //x range
                double range = xRange/(scale*2);
                userBox1.Text = Convert.ToString(uX - range);
                userBox2.Text = Convert.ToString(uX + range);
       
                //y range
                range = yRange / (scale*2);
                userBox3.Text = Convert.ToString(uY - range);
                userBox4.Text = Convert.ToString(uY + range);

                double rectX = picCanvas.ClientSize.Width / (scale * 2);
                double rectY = picCanvas.ClientSize.Height / (scale * 2);

            using (Graphics g = Graphics.FromImage(bm))
            {
                g.DrawRectangle(new Pen(Color.Red, 2), new Rectangle((int)(e.X - (rectX/2.0)), (int)(e.Y - (rectY/2.0)), (int)rectX, (int)rectY));
                picCanvas.Image = bm; //updates canvas image
            }
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            //loads default values
            userBox1.Text = "-2";
            userBox2.Text = "2";
            userBox3.Text = "-2";
            userBox4.Text = "2";
            Mandelbrot_Load(sender, e);
        }

    }
}
