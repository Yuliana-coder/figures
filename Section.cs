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
    class Section : Figure
    {
        private int x;
        private int y;
        private int lenght = 50;

        public Section()
        {
            x = 0;
            y = 0;
            lenght = 10;
        }

        public Section(int x_, int y_)
        {
            x = x_ - (lenght / 2);
            y = y_;
            figurePath.AddLine(x, y, x + lenght, y);
        }

        public int getLenght()
        {
            return lenght;
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

        public void setLenght(int lenght_)
        {
            lenght = lenght_;
        }

        public override bool countDist(int clickX_, int clickY_) // вернет true если попали в фигуру
        {
            bool retDist = false;
            if ((clickX_ > x) && (clickX_ < (x + lenght)) && (clickY_ > (y - 2)) && (clickY_ < (y + 2)))
            {
                retDist = true;
            }
            return retDist;
        }

        public override void Draw(PaintEventArgs e)
        {
            figurePath.Reset();
            figurePath.AddLine(x, y, x + lenght, y);
            if (chosen == true)
            {
                Pen pen1 = new Pen(Brushes.Red, 4);
                e.Graphics.DrawLine(pen1, x, y, x + lenght, y);
            }
            else
            {
                Pen pen2 = new Pen(color, 4);
                e.Graphics.DrawLine(pen2, x, y, x + lenght, y);
            }
        }

        public override void changeSize(string moving, int max_w_, int max_h_) // передается новая длина, и снова отрисовывается отрезок
        {

            if (up_down == 1)
            {
                lenght = lenght - 5;
                if (lenght < 5)
                {
                    lenght = 5;
                }
            }

            if ((up_down == 2))
            {
                lenght = lenght + 5;
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
            if (Y_ > 10)
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
                    if (y < max_h - 10)
                        return true;
                    break;
                case "right":
                    if (x < max_w - (lenght + 5))
                        return true;
                    break;
                case "add":
                    if (((x + lenght) < (max_w - 5)))
                        return true;
                    break;
                case "substract":
                    return true;
            }
            return false;
        }

        public override void save(StreamWriter writer)
        {
            int x2 = x + lenght;
            writer.WriteLine("<line x1=\"" + x + "\" y1=\"" + y + "\" x2 =\"" + x2 + "\" y2=\"" + y + "\" " + "style=\"fill:rgba(0,0,0,0);stroke: rgb(" + color.R + "," + color.G + "," + color.B + ");stroke-width:2\"/>");

        }

        public override void load(StreamReader reader, FigureFactory factory, XmlReader rdr)
        {
            /*string x_;
            x_ = reader.ReadLine();
            x = Convert.ToInt32(x_);
            string y_;
            y_ = reader.ReadLine();
            y = Convert.ToInt32(y_);
            string lenght_;
            lenght_ = reader.ReadLine();
            lenght = Convert.ToInt32(lenght_);
            string color_;
            color_ = reader.ReadLine();
            string[] split = color_.Split(new Char[] { '[', ']' });
            color = Color.FromName(split[1]);*/
            //считываем значения координат и длины отрезка
            x = Convert.ToInt32(rdr.GetAttribute("x1"));
            y = Convert.ToInt32(rdr.GetAttribute("y1"));
            lenght = Convert.ToInt32(rdr.GetAttribute("x2")) - Convert.ToInt32(rdr.GetAttribute("x1"));
            //считывание значений для цвета
            string[] s = rdr.GetAttribute("style").Split(';');
            string[] arb_;
            arb_ = s[1].Replace(")", "").Replace("stroke: rgb(", "").Split(',');
            color = Color.FromArgb(Convert.ToInt32(arb_[0]), Convert.ToInt32(arb_[1]), Convert.ToInt32(arb_[2]));
        }
    }
}
