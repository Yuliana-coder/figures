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
    class Circle : Figure
    {
        private int x;
        private int y;
        private int r = 30;

        public Circle()
        {
            x = 0;
            y = 0;
        }

        public Circle(int x_, int y_)
        {
            x = x_ - r;
            y = y_ - r;
            figurePath.AddEllipse(x, y, r * 2, r * 2);
        }

        public int getR()
        {
            return r;
        }

        public override int getX()
        {
            return x;
        }

        public override int getY()
        {
            return y;
        }

        public override void move_withMouse(int dx, int dy)
        {
            x = x + dx;
            y = y + dy;
        }

        public override void setX(int x_)
        {
            x = x_;
        }

        public override void setY(int y_)
        {
            y = y_;
        }

        public void setR(int r_)
        {
            r = r_;
        }

        public override bool countDist(int clickx_, int clicky_) // подсчет расстояния между двуми точками
        {
            bool retDist = false;
            int dx = Math.Abs((clickx_ - r) - x);
            int dy = Math.Abs((clicky_ - r) - y);
            if ((int)Math.Sqrt(dx * dx + dy * dy) < r)
            {
                retDist = true;
            }
            return retDist;
        }

        public override void Draw(PaintEventArgs e) // рисует круги
        {
            figurePath.Reset();
            figurePath.AddEllipse(x, y, r * 2, r * 2);
            if (chosen == true)
            {
                Pen pen2 = new Pen(Brushes.Red, 2);
                e.Graphics.DrawEllipse(pen2, x, y, r * 2, r * 2);
            }
            else
            {
                Pen pen1 = new Pen(color, 2);
                e.Graphics.DrawEllipse(pen1, x, y, r * 2, r * 2);
            }
        }

        public override void changeSize(string moving, int max_w_, int max_h_)
        {
            if ((up_down == 1) && (r > 5))
            {
                r = r - 5;
                if (r < 0)
                {
                    r = 5;
                }
            }
            if (up_down == 2)
            {
                r = r + 5;
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
            if (((Y_ - r) > 10) && ((X_ - r) > 5) && ((Y_ - r) < max_h_ - (r * 2 + 5)) && ((X_ - r) < max_w_ - (r * 2 + 5)))
            {
                retCheck = true;
            }
            return retCheck;
        }

        public override bool canmove(string moving, int max_w, int max_h)
        {
            switch (moving)
            {
                case "u":
                    if (y > 10)
                        return true;
                    break;
                case "left":
                    if (x > 5)
                        return true;
                    break;
                case "down":
                    if (y < max_h - (r * 2 + 5))
                        return true;
                    break;
                case "add":
                    if ((y < max_h - (r * 2 + 5)) && (x < max_w - (r * 2 + 5)))
                        return true;
                    break;
                case "right":
                    if (x < max_w - (r * 2 + 5))
                        return true;
                    break;
                case "substract":
                    return true;
            }
            return false;
        }

        public override void save(StreamWriter writer)
        {
            writer.WriteLine("<circle cx=\"" + (x + r) + "\" cy=\"" + (y + r) + "\" r=\"" + r + "\" " + "style=\"fill:rgba(0,0,0,0);stroke: rgb(" + color.R + "," + color.G + "," + color.B + ");stroke-width:2\"/>");
        }

        public override void load(StreamReader reader, FigureFactory factory, XmlReader rdr)
        {
            /*string x_;
            x_ = reader.ReadLine();
            x = Convert.ToInt32(x_);
            string y_;
            y_ = reader.ReadLine();
            y = Convert.ToInt32(y_);
            string r_;
            r_ = reader.ReadLine();
            r = Convert.ToInt32(r_);
            string color_;
            color_ = reader.ReadLine();
            string[] split = color_.Split(new Char[] { '[', ']' });
            color = Color.FromName(split[1]);*/
            /*string read = reader.ReadLine();
            string[] split = read.Split(new string[] { "<circle cx=\"", "\" cy=\"" , "\" r=\"" , "\"", "style = \"fill:rgba( ", "," , "," , ")"}, StringSplitOptions.None);
            x = Convert.ToInt32(split[1]);
            y = Convert.ToInt32(split[2]);
            r = Convert.ToInt32(split[3]);
            color = Color.FromArgb(Convert.ToInt32(split[6]), Convert.ToInt32(split[7]), Convert.ToInt32(split[8]));*/
            r = Convert.ToInt32(int.Parse(rdr.GetAttribute("r")));
            x = Convert.ToInt32(int.Parse(rdr.GetAttribute("cx")));
            y = Convert.ToInt32(int.Parse(rdr.GetAttribute("cy")));
            string[] s = rdr.GetAttribute("style").Split(';');
            string[] arb_;
            arb_ = s[1].Replace(")", "").Replace("stroke: rgb(", "").Split(',');
            color = Color.FromArgb(Convert.ToInt32(arb_[0]), Convert.ToInt32(arb_[1]), Convert.ToInt32(arb_[2]));
        }
    }
} //"30\" style=\"fill:rgba(0"
  //<circle cx="384" cy="-5" r="30" style="fill:rgba(0,0,0,0);stroke: rgb(0,255,128);stroke-width:2"/>