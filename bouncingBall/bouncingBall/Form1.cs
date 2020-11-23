using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace bouncingBall
{
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

    public struct Sphere
    {
        public double r;
        public double x;
        public double y;
        public double z;

        public Sphere(double R, double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
            r = R;
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //globals
        Coordinate light = new Coordinate(2, 8, 2);
        Coordinate camera = new Coordinate(5, 8, -10);
        Sphere ball = new Sphere(1, 5, 1, 5);
        Bitmap bm;
        BufferedGraphics buffer; //provides graphics buffer for double buffering
        BufferedGraphicsContext context = BufferedGraphicsManager.Current; //gives methods for graphics buffer
        Timer timer = new Timer();
        SoundPlayer bounce = new SoundPlayer(bouncingBall.Properties.Resources.bounce);

        //manual buffer
        Bitmap[] frames = new Bitmap[15];
        bool buffDone = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Camera = ", camera.x, " ", camera.y, " ", camera.z);
   
            bm = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height);

            using (Graphics g = Graphics.FromImage(bm))
            {
                //initialization of buffered graphics cited from  CodeProject
                
                buffer = context.Allocate(g, new Rectangle(0, 0, picCanvas.ClientSize.Width, picCanvas.ClientSize.Height)); //set buffer position
                drawPts(sender, e);
                timer.Enabled = true; //run timer on
                timer.Tick += OnTimer;
                timer.Interval = 40;
                timer.Start();     
            }
        }

        int frame = -1;
        private void OnTimer(object sender, EventArgs e) //flips through frames of animation
        {
            //Console.WriteLine(frame);
            //translate ball
            ++frame;
            if (buffDone) //confirms that all frames have been rendered
            {
                using (Graphics g = Graphics.FromImage(bm))
                {
                    if (frame < 15) //ball bouncing up
                    {
                            picCanvas.Image = frames[frame];
                    }
                    else if (frame < 30) //plays frames backwards
                    {
                            picCanvas.Image = frames[29 - frame];
                    }
                    else
                    {
                        //sounds and reset
                        bounce.Play();
                        frame = -1;
                    }
                }
            }
        }



        private void drawPts(object sender, EventArgs e) //creates pre-rendered frames
        {          
            for (int f = 0; f < 15; ++f) //frames
            {
                frames[f] = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height); //save frame
                using (Graphics g = Graphics.FromImage(frames[f]))
                {               
                    g.Clear(Color.FromArgb(200, 100, 140)); //background color
                    double ux, uy;

                    //scan each pixel               
                    ball.y += .25; //raises ball up

                    for (int i = 0; i < picCanvas.ClientSize.Height; ++i) //y
                    {
                        for (int j = 0; j < picCanvas.ClientSize.Width; ++j) //x
                        {
                            //convert from screen to user coordinates
                            ux = j / (picCanvas.ClientSize.Width / 10.0);
                            uy = 10 - (i / (picCanvas.ClientSize.Height / 10.0));
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
                                    frames[f].SetPixel(j, i, Color.FromArgb((int)(costh * 90), (int)(costh * 110), (int)(costh * 100))); //simulate reflection of floor
                                }
                                else
                                {
                                    frames[f].SetPixel(j, i, Color.FromArgb((int)(costh * 255), (int)(costh * 255), (int)(costh * 255))); //color pixel
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
                                    Coordinate il = new Coordinate(ix - light.x, - light.y, iz - light.z);
                                    double costh = dotProduct(ci, il); // (ci.x * il.x)/(mag1 * mag2) 

                                    //check if light intersects sphere, ray from light to intersection
                                    if (0 < intersects(light, new Coordinate(ix, 0, iz), ball))
                                    {
                                        frames[f].SetPixel(j, i, Color.FromArgb((int)(55), (int)(155), (int)(95))); //ball casts shadow on floor
                                    }
                                    else
                                    {
                                        if (costh < 0)
                                        {
                                            costh = -costh;
                                        }
                                        frames[f].SetPixel(j, i, Color.FromArgb((int)(costh *155), (int)(costh*255), (int)(costh*195))); //color floor
                                    }
                                }
                            }
                        }
                    }
                }
            }
            buffDone = true;
        }

        private double dotProduct(Coordinate a, Coordinate b)
        {

            Coordinate c = normalize(a);
            Coordinate d = normalize(b);

            //perform dot product
            return (c.x * d.x + c.y*d.y + c.z*d.z);

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

        private double intersects(Coordinate src, Coordinate dest, Sphere ball) //returns t if intersection, else, returns -100
        {
            double t = -100;

            //calculate (X(t), Y(t), Z(t)

            double a = Math.Pow(src.x - dest.x, 2) + Math.Pow(src.y - dest.y, 2) + Math.Pow(src.z - dest.z, 2);
            double b = (src.x - dest.x) * (src.x - ball.x) + (src.y - dest.y) * (src.y - ball.y) + (src.z - dest.z)* (src.z - ball.z);
            double c = Math.Pow(src.x - ball.x, 2) + Math.Pow(src.y - ball.y, 2) + Math.Pow(src.z - ball.z, 2) - Math.Pow(ball.r, 2);

            double disc = 4 * Math.Pow(b, 2) - 4 * a * c;

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

    }

}

