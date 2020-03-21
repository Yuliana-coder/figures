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
    class Rectangle : Figure
    {
        private int x;
        private int y;
        private int a = 40;
        private int b = 40;

        public Rectangle()
        {
            x = 0;
            y = 0;
        }

        public Rectangle(int x_, int y_)
        {
            x = x_ - a / 2;
            y = y_ - b / 2;
            Point point1 = new Point(x - a / 2, y - b / 2);
            Point point2 = new Point(x + a / 2, y - b / 2);
            Point point3 = new Point(x + a / 2, y - b / 2);
            Point point4 = new Point(x + a / 2, y + b / 2);
            Point[] points =
            {
                point1,
                point2,
                point3,
                point4
             };
            figurePath.AddPolygon(points);
        }

        public int getA()
        {
            return a;
        }

        public void setA(int a_)
        {
            a = a_;
        }

        public int getB()
        {
            return b;
        }

        public void setB(int b_)
        {
            b = b_;
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

        public override int getX()
        {
            return x;
        }

        public override int getY()
        {
            return y;
        }

        public override bool countDist(int clickx_, int clicky_)
        {
            bool retDist = false;
            int d = (int)Math.Sqrt(a * a + b * b) / 2;
            int dx = Math.Abs((clickx_ - a / 2) - x);
            int dy = Math.Abs((clicky_ - b / 2) - y);
            if ((int)Math.Sqrt(dx * dx + dy * dy) < d)
            {
                retDist = true;
            }
            return retDist;
        }

        public override void Draw(PaintEventArgs e)
        {
            Point point1 = new Point(x - a/2, y - b/2);
            Point point2 = new Point(x + a/2, y - b/2);
            Point point3 = new Point(x + a / 2, y - b / 2);
            Point point4 = new Point(x + a / 2, y + b / 2);
            Point[] points =
            {
                point1,
                point2,
                point3,
                point4
             };
            figurePath.Reset();
            figurePath.AddPolygon(points);
            if (chosen == true)
            {
                Pen pen1 = new Pen(Brushes.Red, 2);
                e.Graphics.DrawRectangle(pen1, x, y, a, b);
            }
            else
            {
                Pen pen2 = new Pen(color, 2);
                e.Graphics.DrawRectangle(pen2, x, y, a, b);
            }
        }

        public override void changeSize(string moving, int max_w_, int max_h_)
        {
            if (up_down == 1)
            {
                a = a - 5;
                b = b - 5;
                if (a < 5 || b < 5)
                {
                    a = 5;
                    b = 5;
                }
            }

            if (up_down == 2)
            {
                a = a + 5;
                b = b + 5;
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
            if (((Y_ - b / 2) > 10) && ((X_ - a / 2) > 0) && ((Y_ - b / 2) < max_h_ - (b + 5)) && ((X_ - a / 2) < max_w_ - (a + 5)))
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
                    if (x > 5)
                        return true;
                    break;
                case "down":
                    if (y < max_h - (b + 5))
                        return true;
                    break;
                case "right":
                    if (x < max_w - (a + 5))
                        return true;
                    break;
                case "add":
                    if ((x < max_w - (a + 5)) && (y < max_h - (b + 5)))
                        return true;
                    break;
                case "substract":
                    return true;
            }
            return false;
        }

        public override void save(StreamWriter writer)
        {
            writer.WriteLine("<rect x=\"" + x + "\" y=\"" + y + "\" width=\"" + a + "\" height=\"" + b + "\" " + "style=\"fill:rgba(0,0,0,0);stroke: rgb(" + color.R + "," + color.G + "," + color.B + ");stroke-width:2\"/>");

        }

        public override void load(StreamReader reader, FigureFactory factory, XmlReader rdr)
        {
            //считывание значений атрибутов
            x = Convert.ToInt32(rdr.GetAttribute("x"));
            y = Convert.ToInt32(rdr.GetAttribute("y"));
            a = Convert.ToInt32(rdr.GetAttribute("width"));
            b = Convert.ToInt32(rdr.GetAttribute("height"));
            //считывание значений для цвета
            string[] s = rdr.GetAttribute("style").Split(';');
            string[] arb_;
            arb_ = s[1].Replace(")", "").Replace("stroke: rgb(", "").Split(',');
            color = Color.FromArgb(Convert.ToInt32(arb_[0]), Convert.ToInt32(arb_[1]), Convert.ToInt32(arb_[2]));
        }
    }
}
