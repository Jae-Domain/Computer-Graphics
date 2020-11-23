using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//graphs JuliaSets 
//Computer Graphics Janelle Domantay Hw 2
//Dr. Yfantis
namespace juliaSet
{
    public partial class Form1 : Form
    {
        // global variables
        bool itC = false; //iterative coloring
        double c1 = 0;
        double c2 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height);
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

                textC0.Text = "Current C1: " + c1;
                textC1.Text = "Current C2: " + c2;

                //declare variables

                double dX = (4.0/picCanvas.ClientSize.Width);
                double dY = (4.0/picCanvas.ClientSize.Height);

                //user coordinates
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
                    for (int j = 0; j < picCanvas.ClientSize.Height; ++j) //y screen coordinates
                    {
                        for (int k = 0; k < picCanvas.ClientSize.Width; ++k) // x screen coordinates
                        {
                        
                        //calculate user coordinates
                            x = Math.Round(-2 + (k * dX),5);
                            y = Math.Round(-2 + (j * dY),5);

                        //compute next generation
                            for (int i = 0; i < N; ++i) //iterations
                            {
                                xn = Math.Round(Math.Pow(x, 2) - Math.Pow(y, 2) + c1, 5);
                                yn = Math.Round(2 * (x * y) + c2, 5);
                                mag = Math.Round(Math.Pow(xn,2) + Math.Pow(yn,2), 5);

                                if (mag > T)
                                {
                                    if (itC)
                                    {
                                     
                                    Console.WriteLine(g);
                                        switch (i % 5) //round down to tens
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
                            //picCanvas.Image = bm;
                        }
                    }
            }
            picCanvas.Image = bm; //updates canvas image
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //checks for iterative coloring
        {
            itC = !itC; //toggles iterative coloring
        }

        private void button1_Click(object sender, EventArgs e) //reloads piccanvas
        {
            Form1_Load(sender, e);
        }

        private void inputButton_Click(object sender, EventArgs e) //changes c constants
        {
            c1 = Convert.ToDouble(textUser2.Text);
            c2 = Convert.ToDouble(textUser1.Text);
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            Random random = new Random(); //initialize new random
            c1 = randomC(random);
            c2 = randomC(random);
            Form1_Load(sender, e);
        }

        //cited from StackOverflow
        double randomC(Random random)
        {
            double dec = random.NextDouble(); //returns random double b/w 0 and 1
            double num = random.Next(-2, 2); //generates random value from -2 to 2
            return num + dec;
        }

    }
}
