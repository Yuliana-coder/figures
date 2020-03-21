using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace ООП_6_ЛАБОРАТОРНАЯ
{
    class Triangle : Figure
    {
        private int x;
        private int y;
        private int h = 50;
        private int f = 50;

        public Triangle()
        {
            x = 0;
            y = 0;
        }

        public Triangle(int x_, int y_)
        {
            x = x_;
            y = y_ - h / 2;
        }

        public int getH()
        {
            return h;
        }

        public override int getX()
        {
            return x;
        }

        public override int getY()
        {
            return y;
        }

        public override void setX(int x_)
        {
            x = x_;
        }

        public override void setY(int y_)
        {
            y = y_;
        }

        public override void move_withMouse(int dx, int dy)
        {
            x = x + dx;
            y = y + dy;
        }

        public void setH(int h_)
        {
            h = h_;
        }

        public int getF()
        {
            return f;
        }

        public void setF(int f_)
        {
            f = f_;
        }

        public override bool countDist(int clickx_, int clicky_)
        {
            bool retDist = false;
            if ((clickx_ <= x + f / 2) && (clickx_ >= x - f / 2) && (clicky_ <= y + h) && (clicky_ >= y) && (clicky_ >= 2 * clickx_ + y - 2 * x) && (clicky_ >= -2 * clickx_ + y + 2 * x))
            {
                retDist = true;
            }
            return retDist;
        }

        public override void Draw(PaintEventArgs e)
        {
            Point point1 = new Point(x, y);
            Point point2 = new Point(x + f / 2, y + h);
            Point point3 = new Point(x - f / 2, y + h);
            Point[] points =
            {
                point1,
                point2,
                point3
             };

            figurePath.Reset();
            figurePath.AddPolygon(points);

            if (chosen == true)
            {
                Pen pen1 = new Pen(Brushes.Red, 2);
                e.Graphics.DrawPolygon(pen1, points);
            }
            else
            {
                Pen pen2 = new Pen(color, 2);
                e.Graphics.DrawPolygon(pen2, points);
            }
        }

        public override void changeSize(string moving, int max_w_, int max_h_)
        {
            if (up_down == 1 && h > 5 && f > 5)
            {
                h = h - 5;
                f = f - 5;
                if (h < 5 || f < 5)
                {
                    h = 5;
                    f = 5;
                }
            }

            if (up_down == 2)
            {
                h = h + 5;
                f = f + 5;
            }
        }

        public override void changeLocate(string moving, int max_w_, int max_h_)
        {
            if (move == 1)
            {
                y = y - 5;
            }
            if (move == 2)
            {
                x = x - 5;
            }
            if (move == 3)
            {
                y = y + 5;
            }
            if (move == 4)
            {
                x = x + 5;
            }
        }

        public override bool check_border(int max_w_, int max_h_, int X_, int Y_)
        {
            bool retCheck = false;
            if (((Y_ - h / 2) > 10) && (X_ > f / 2) && ((Y_ - h / 2) < max_h_ - (h + 5)) && (X_ < max_w_ - (f / 2 + 5)))
            {
                retCheck = true;
            }
            return retCheck;
        }

        public override bool canmove(string moving, int max_w, int max_h)
        {
            switch (moving)
            {
                case "up":
                    if (y > 10)
                        return true;
                    break;
                case "left":
                    if (x > f / 2)
                        return true;
                    break;
                case "down":
                    if (y < max_h - (h + 5))
                        return true;
                    break;
                case "right":
                    if (x < max_w - (f / 2 + 5))
                        return true;
                    break;
                case "add":
                    if ((x < max_w - (f / 2 + 5)) && (x > f / 2) && (y < max_h - (h + 5)))
                        return true;
                    break;
                case "substract":
                    return true;
            }
            return false;
        }


        public override void save(StreamWriter writer)
        {
            writer.WriteLine("Triangle");
            writer.WriteLine(x);
            writer.WriteLine(y);
            writer.WriteLine(h);
            writer.WriteLine(f);
            writer.WriteLine(color);
            writer.WriteLine();
        }

        public override void load(StreamReader reader, FigureFactory factory, XmlReader rdr)
        {
            string x_;
            x_ = reader.ReadLine();
            x = Convert.ToInt32(x_);
            string y_;
            y_ = reader.ReadLine();
            y = Convert.ToInt32(y_);
            string h_;
            h_ = reader.ReadLine();
            h = Convert.ToInt32(h_);
            string f_;
            f_ = reader.ReadLine();
            f = Convert.ToInt32(f_);
            string color_;
            color_ = reader.ReadLine();
            string[] split = color_.Split(new Char[] { '[', ']' });
            color = Color.FromName(split[1]);
        }
    }
}
