using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interactiveObj3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //globals
        double userMin = 0;
        double userMax = 10;
        Coordinate light = new Coordinate(5, 8, 10);
        Coordinate camera = new Coordinate(5, 7, -10);
        Obj ball = new Obj(1, 5, 1, 5);
        Bitmap bm;

        public struct Coordinate
        {
            public double x;
            public double y;
            public double z;
            public Coordinate(double X, double Y, double Z)
            {
                x = X;
                y = Y;
                z = Z;
            }
        }

        public class Obj
        {
            public double r2;
            public double r3;
            public double r;
            public double x;
            public double y;
            public double z;

            public Obj(double R, double X, double Y, double Z, double R1 = .5, double R2 = 2)
            {
                x = X;
                y = Y;
                z = Z;
                r = R;
                r2 = R1;
                r3 = R2;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bm = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height);

            using (Graphics g = Graphics.FromImage(bm))
            {
                g.Clear(Color.FromArgb(200, 100, 140)); //background color
            }
        }

        private void render(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.Clear(Color.FromArgb(200, 100, 140)); //background color
                for (int i = 0; i < picCanvas.ClientSize.Height; ++i) //y
                {
                    progress.Increment(1);
                    for (int j = 0; j < picCanvas.ClientSize.Width; ++j) //x
                    {
                        //convert from screen to user coordinates
                        double ux = j / (picCanvas.ClientSize.Width / 10.0);
                        double uy = 10 - (i / (picCanvas.ClientSize.Height / 10.0));
                        double t = 0;

                        Coordinate screen = new Coordinate(ux, uy, 0);

                        //draw ray from eye to screen
                        t = intersects(camera, screen, ball); //returns positive t if intersection occurs
                        if (t > 0) //
                        {
                            //calculate intersection
                            Coordinate inter = calculateIntersect(t, camera, screen);

                            //take vector from center of ball and light source
                            Coordinate ci = new Coordinate(inter.x - ball.x, inter.y - ball.y, inter.z - ball.z);
                            Coordinate il = new Coordinate(light.x - inter.x, light.y - inter.y, light.z - inter.z);

                            double costh = dotProduct(ci, il); // (ci.x * il.x)/(mag1 * mag2) 
                            if (costh < 0)
                            {
                                costh = -costh;
                                bm.SetPixel(j, i, Color.FromArgb((int)(costh * 90), (int)(costh * 110), (int)(costh * 100))); //simulate reflection of floor
                            }
                            else
                            {
                                bm.SetPixel(j, i, Color.FromArgb((int)(costh * 255), (int)(costh * 255), (int)(costh * 255))); //color pixel
                            }
                        }
                        else //ray does not intersect sphere
                        {
                            //does Y(t) decrease?
                            if (screen.y < camera.y) //intersects floor
                            {
                                //set Y(t) = 0
                                t = camera.y / (camera.y - screen.y);

                                double ix = camera.x * (1 - t) + screen.x * t;
                                double iz = camera.z * (1 - t) + screen.z * t;

                                Coordinate ci = new Coordinate(0, 5, 0);
                                Coordinate il = new Coordinate(ix - light.x, -light.y, iz - light.z);
                                double costh = dotProduct(ci, il); // (ci.x * il.x)/(mag1 * mag2) 

                                if (costh < 0)
                                {
                                    costh = -costh;
                                }

                                //check if light intersects sphere, ray from light to intersection
                                if (0 < intersects(light, new Coordinate(ix, 0, iz), ball))
                                {
                                    bm.SetPixel(j, i, Color.FromArgb((int)(costh * 55), (int)(costh * 155), (int)(costh * 95))); //ball casts shadow on floor
                                }
                                else
                                {
                                    bm.SetPixel(j, i, Color.FromArgb((int)(costh * 155), (int)(costh * 255), (int)(costh * 195))); //color floor
                                }
                            }
                        }
                    }

                    picCanvas.Image = bm;
                }
            }
        }

        private double dotProduct(Coordinate a, Coordinate b)
        {

            Coordinate c = normalize(a);
            Coordinate d = normalize(b);

            //perform dot product
            return (c.x * d.x + c.y * d.y + c.z * d.z);

        }

        private Coordinate normalize(Coordinate coord)
        {
            double mag = Math.Sqrt(Math.Pow(coord.x, 2) + Math.Pow(coord.y, 2) + Math.Pow(coord.z, 2)); //calculate magnitude
            return (new Coordinate(coord.x / mag, coord.y / mag, coord.z / mag));
        }

        private Coordinate calculateIntersect(double t, Coordinate src, Coordinate dest) //calculate intersection point
        {
            double x = src.x * (1 - t) + dest.x * t;
            double y = src.y * (1 - t) + dest.y * t;
            double z = src.z * (1 - t) + dest.z * t;
            return (new Coordinate(x, y, z));
        }

        private double intersects(Coordinate src, Coordinate dest, Obj ball) //returns t if intersection, else, returns -100
        {
            double t = -100;
            double a, b, c;

            //calculate (X(t), Y(t), Z(t)
            if (objectBox.Text == "Ellipsoid") 
            {
              double x2 = Math.Pow(1/ball.r, 2);
              double y2 = Math.Pow(1/ball.r2, 2);
              a = y2 * Math.Pow(src.x - dest.x, 2) + x2 * Math.Pow(src.y - dest.y, 2) + x2 * y2 * Math.Pow(src.z - dest.z, 2);
              b = y2 * (src.x - dest.x) * (src.x - ball.x) + x2 * (src.y - dest.y) * (src.y - ball.y) + x2*y2*(src.z - dest.z) * (src.z - ball.z);
              c = y2 * Math.Pow(src.x - ball.x, 2) + x2 * Math.Pow(src.y - ball.y, 2) + x2 * y2 * Math.Pow(src.z - ball.z, 2) - ball.r * ball.r - ball.r2 * ball.r2;
            }
            else if (objectBox.Text == "TEST2") //Test for 3 parameters
            {
                double x2 = Math.Pow(ball.r, 2);
                double y2 = Math.Pow(ball.r2, 2);
                double z2 = Math.Pow(ball.r3, 2);
                /*
                a = y2 * z2 * Math.Pow(src.x - dest.x, 2) + x2 * z2 * Math.Pow(src.y - dest.y, 2) + x2 * y2* Math.Pow(src.z - dest.z, 2);
                b = y2* z2 * (src.x - dest.x) * (src.x - ball.x) + x2 * z2 * (src.y - dest.y) * (src.y - ball.y) + x2 * y2 * (src.z - dest.z) * (src.z - ball.z);
                c = y2 * z2 * Math.Pow(src.x - ball.x, 2) + x2 * z2 * Math.Pow(src.y - ball.y, 2) + x2 * y2 * Math.Pow(src.z - ball.z, 2) - 1;
                */
                //cylinder
                a = z2 * y2 * (Math.Pow(src.x, 2) - 2 * (src.x * dest.x) + Math.Pow(dest.x, 2)) +
                    z2 * x2 * (Math.Pow(src.y, 2) - 2 * (src.y * dest.y) + Math.Pow(dest.y, 2)) +
                    x2 * y2 * (Math.Pow(src.z, 2) - 2 * (src.z * dest.y) + Math.Pow(dest.z, 2));
                b = z2 * y2 * 2 * (src.x * dest.x - src.x * src.x + src.x * ball.x - dest.x * ball.x) +
                    x2 * z2 * 2 * (src.y * dest.y - src.y * src.y + src.y * ball.y - dest.y * ball.y) +
                    x2 * y2 * 2 *(src.z * dest.z - src.z * src.z + src.z * ball.z - dest.z * ball.z);
                c = z2 * y2 * (Math.Pow(src.x, 2) - 2 * (src.x * ball.x) + Math.Pow(ball.x, 2)) +
                    z2 * x2 * (Math.Pow(src.y, 2) - 2 * (src.y * ball.y) + Math.Pow(ball.y, 2)) - 1 +
                    x2 * y2 * (Math.Pow(src.z, 2) - 2 * (src.z * ball.z) + Math.Pow(ball.z, 2)) - 1;
                      
            }
            else //render sphere
            {
                a = Math.Pow(src.x - dest.x, 2) + Math.Pow(src.y - dest.y, 2) + Math.Pow(src.z - dest.z, 2);
                b = (src.x - dest.x) * (src.x - ball.x) + (src.y - dest.y) * (src.y - ball.y) + (src.z - dest.z) * (src.z - ball.z);
                c = Math.Pow(src.x - ball.x, 2) + Math.Pow(src.y - ball.y, 2) + Math.Pow(src.z - ball.z, 2) - Math.Pow(ball.r, 2);
            }
           
            double disc = Math.Pow(b, 2) - a * c;

            if (disc > 0) // if discriminant is negative, no intersection
            {
                t = (b - Math.Sqrt(Math.Pow(b, 2) - a * c)) / a;
            }
            else if (disc == 0) //discriminant is 0, exactly one intersection
            {
                t = (2 * b) / (2 * a);
            }
            return t;
        }

        private void button_Click(object sender, EventArgs e)
        {
            ball.x = xBox.Value;
            ball.y = yBox.Value;
            ball.z = zBox.Value;
            progress.Value = 0;

            ball.r = Convert.ToDouble(radiusBox.Text);
            ball.r2 = Convert.ToDouble(radius2Box.Text);
            render(sender, e);
        }

        private void objectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            radius2Box.Visible = false;
            radius3Box.Visible = false;
            radius2Label.Visible = false;
            radius3Label.Visible = false;

            if (objectBox.Text == "Ellipsoid")
            {
                radius2Box.Visible = true;
                radius2Label.Visible = true;
            }
            else if (objectBox.Text == "TEST2")
            {
                radius2Box.Visible = true;
                radius3Box.Visible = true;
                radius2Label.Visible = true;
                radius3Label.Visible = true;
            }
        }
    }
}
