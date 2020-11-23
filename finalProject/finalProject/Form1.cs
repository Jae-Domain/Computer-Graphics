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


namespace finalProject
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
        Coordinate light = new Coordinate(3, 8, 3);
        Coordinate camera = new Coordinate(5, 8, -10);
        Sphere ball = new Sphere(1, -3, 3, 5);
        Sphere ball2 = new Sphere(1, 13, 3, 5);
        Bitmap bm;
        BufferedGraphics buffer; //provides graphics buffer for double buffering
        BufferedGraphicsContext context = BufferedGraphicsManager.Current; //gives methods for graphics buffer
        Timer timer = new Timer();
        int col = 0;

        //manual buffer
        const int FRAMENUM = 60;
        Bitmap[] frames = new Bitmap[FRAMENUM];
        bool buffDone = false;

        //sound
        SoundPlayer bounce = new SoundPlayer(finalProject.Properties.Resources.bounce);
        SoundPlayer clink = new SoundPlayer(finalProject.Properties.Resources.bounce);


        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Camera = ", camera.x, " ", camera.y, " ", camera.z);

            bm = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height);
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
                    if (frame < FRAMENUM) //ball bouncing up
                    {
                        if (frame == col)
                        {
                            clink.Play();
                        }
                        if (frame % 10 == 0 && (frame / 10) % 2 == 1 && frame > 0)
                        {
                            bounce.Play();
                        }

                        picCanvas.Image = frames[frame];
                    }
                    else
                    {
                        frame = -1;
                    }
                }
            }
        }



        private void drawPts(object sender, EventArgs e) //creates pre-rendered frames
        {
            for (int f = 0; f < FRAMENUM; ++f) //frames
            {
                frames[f] = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height); //save frame
                using (Graphics g = Graphics.FromImage(frames[f]))
                {
                    g.Clear(Color.FromArgb(200, 100, 140)); //background color
                    double ux, uy;

                    updateBalls(f);
                    //scan each pixel

                    progressBar1.Value += 1;
                    for (int i = 0; i < picCanvas.ClientSize.Height; ++i) //y
                    {
                        for (int j = 0; j < picCanvas.ClientSize.Width; ++j) //x
                        {

                            //convert from screen to user coordinates
                            ux = j / (picCanvas.ClientSize.Width / 10.0);
                            uy = 10 - (i / (picCanvas.ClientSize.Height / 10.0));
                            double t = 0;
                            double t2 = 0;
                            Coordinate screen = new Coordinate(ux, uy, 0);

                            //calculate if ray intersects spheres
                            t = intersects(camera, screen, ball);
                            t2 = intersects(camera, screen, ball2);

                            if (t > 0) // if ray intersects ball
                            {
                                double costh = bounceBall(ball, screen, t);
                                //color pixels
                                if (costh < 0)
                                {
                                    costh = -costh;
                                    frames[f].SetPixel(j, i, Color.FromArgb((int)(costh * 90), (int)(costh * 110), (int)(costh * 100))); //simulate reflection of floor
                                }
                                else
                                {
                                    frames[f].SetPixel(j, i, Color.FromArgb((int)(costh * 250), (int)(costh * 200), (int)(costh * 155))); //color pixel
                                }
                            }
                            else if (t2 > 0) //if ray intersects ball
                            {
                                double costh = bounceBall(ball2, screen, t2);

                                if (costh < 0)
                                {
                                    costh = -costh;
                                    frames[f].SetPixel(j, i, Color.FromArgb((int)(costh * 90), (int)(costh * 110), (int)(costh * 100))); //simulate reflection of floor
                                }
                                else
                                {
                                    frames[f].SetPixel(j, i, Color.FromArgb((int)(costh * 200), (int)(costh * 250), (int)(costh * 155))); //color pixel
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
                                        frames[f].SetPixel(j, i, Color.FromArgb((int)(costh * 55), (int)(costh * 155), (int)(costh * 95))); //ball casts shadow on floor
                                    }
                                    else if (0 < intersects(light, new Coordinate(ix, 0, iz), ball2))
                                    {
                                        frames[f].SetPixel(j, i, Color.FromArgb((int)(costh * 55), (int)(costh * 155), (int)(costh * 95))); //ball casts shadow on floor
                                    }
                                    else
                                    {
                                        frames[f].SetPixel(j, i, Color.FromArgb((int)(costh * 155), (int)(costh * 255), (int)(costh * 195))); //color floor
                                    }
                                }
                            }
                        }
                    }
                }
            }
            buffDone = true;
        }

        private double bounceBall(Sphere ball, Coordinate screen, double t)
        {
            //calculate intersection
            Coordinate inter = calculateIntersect(t, camera, screen);

            //take vector from center of ball and light source
            Coordinate ci = new Coordinate(inter.x - ball.x, inter.y - ball.y, inter.z - ball.z);
            Coordinate il = new Coordinate(light.x - inter.x, light.y - inter.y, light.z - inter.z);

            double costh = dotProduct(ci, il); // (ci.x * il.x)/(mag1 * mag2) 

            return costh;
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

        private double intersects(Coordinate src, Coordinate dest, Sphere ball) //returns t if intersection, else, returns -100
        {
            double t = -100;

            //calculate (X(t), Y(t), Z(t)

            double a = Math.Pow(src.x - dest.x, 2) + Math.Pow(src.y - dest.y, 2) + Math.Pow(src.z - dest.z, 2);
            double b = (src.x - dest.x) * (src.x - ball.x) + (src.y - dest.y) * (src.y - ball.y) + (src.z - dest.z) * (src.z - ball.z);
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

        private bool collide(Sphere b1, Sphere b2) //calculates if spheres collide
        {
            return (Math.Abs(Math.Abs(b1.x) - Math.Abs(b2.x)) <= (b1.r + b2.r));
        }

        private void updateBalls(int f) //updates sphere movement
        {
            //horizontal movement
            if (col > 0)
            {
                ball.x -= .35;
                ball2.x += .35;
            }
            else if (collide(ball, ball2))
            {
                col = f;
            }
            else
            {
                ball.x += .35; //move ball sideways
                ball2.x -= .35;
            }

            //vertical movement
            if ((f / 10) % 2 == 0)
            {
                ball.y -= .25;
                ball2.y -= .25;
            }
            else
            {
                ball.y += .25;
                ball2.y += .25;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            using (Graphics g = Graphics.FromImage(bm))
            {
                //initialization of buffered graphics cited from  CodeProject

                buffer = context.Allocate(g, new Rectangle(0, 0, picCanvas.ClientSize.Width, picCanvas.ClientSize.Height)); //set buffer position
                timer.Enabled = true; //run timer on
                timer.Tick += OnTimer;
                timer.Interval = 40;
                timer.Start();
            }
            ball.r = trackBar1.Value * .5;
            ball2.r = trackBar2.Value * .5;
            drawPts(sender, e);
        }

    }
}

