using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace circleOperations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Graphics g;
        float cx, cy, px, py;
        float rad = (float)(180 / Math.PI);
      
        int dim = 50;
        int pozy = 250;


        Pen pen0;

        Pen pen1;

        private void button1_Click(object sender, EventArgs e)
        {
            fc();
           
        }

        


        public float distantaintredouapuncte2dxy(float x1, float y1, float x2, float y2)
        {
            float c;
            c = (float)Math.Sqrt(Math.Abs(x1 - x2) * Math.Abs(x1 - x2) + Math.Abs(y1 - y2) * Math.Abs(y1 - y2));
            return c;
        }

        //fail
        public bool isInCircle(float x,float y ) {
            bool r = false;

            float d = distantaintredouapuncte2dxy(pozy, pozy, x, y);
            float dd = distantaintredouapuncte2dxy(x, y, dim, dim);

            //center point is [pozy, pozy]

            float diffX = pozy - x;
            float diffY = pozy - y;
          
           
            
            if ((diffX * diffX + diffY * diffY ) <= dim * dim)
            {
                        r = true;
            }

            return r;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchAllPixelsInsideTheCircle();
        }

        public void searchAllPixelsInsideTheCircle()
        {
            for (float i = 0.0f+pozy-dim; i < 0.0f+(dim+pozy); i += 1.000f)
            {
                for (float j = 0.0f + pozy-dim;j < 0.0f + (dim + pozy); j += 1.000f)
                {
                    if (isInCircle(j,i)==true) {
                        g.DrawEllipse(pen1, j,i, 1, 1);
                       
                    }
                }
            }
         }

        public void fc()
        {

            //3
            py = (float)((Math.Sin(1 / rad))) * dim + pozy;
            px = (float)((Math.Cos(1 / rad))) * dim + pozy;

            g.DrawEllipse(pen0, px, py, 5, 5);
            //6
            py = (float)((Math.Sin(90 / rad))) * dim + pozy;
            px = (float)((Math.Cos(90 / rad))) * dim + pozy;

            g.DrawEllipse(pen0, px, py, 5, 5);
            //9
            py = (float)((Math.Sin(180 / rad))) * dim + pozy;
            px = (float)((Math.Cos(180 / rad))) * dim + pozy;

            g.DrawEllipse(pen0, px, py, 5, 5);
            //12
            //center
            py = (float)((Math.Sin(270 / rad))) * dim + pozy;
            px = (float)((Math.Cos(270 / rad))) * dim + pozy;

            g.DrawEllipse(pen0, px, py, 5, 5);

            //center
            g.DrawEllipse(pen0, pozy, pozy,  5, 5);

            //corner top left
            g.DrawEllipse(pen0, pozy-dim, pozy-dim, 5, 5);

            //corner bottom right
            g.DrawEllipse(pen0, pozy + dim, pozy + dim, 5, 5);

            //corner top right
            g.DrawEllipse(pen0, pozy + dim, pozy - dim, 5, 5);

            //corner bottom left
            g.DrawEllipse(pen0, pozy - dim, pozy + dim, 5, 5);



            //
            py = (float)((Math.Sin(1 / rad))) * dim + pozy;
            px = (float)((Math.Cos(1 / rad))) * dim + pozy;


            for (float i = 1.0f; i < 360.0f; i += 1.000f)
            {


                cy = (float)((Math.Sin(i / rad))) * dim + pozy;
                cx = (float)((Math.Cos(i / rad))) * dim + pozy;
              
                g.DrawLine(pen0, px, py, cx, cy);

                px = cx;
                py = cy;
            }

          
           
        }
        


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1024;
            g = CreateGraphics();
            pen1 = new Pen(Color.Yellow);
            pen0 = new Pen(Color.Blue);
        }
    }
}
