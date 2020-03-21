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
using System.Drawing.Drawing2D;
using System.Xml;

//Сделать команды и событие мыши как команда

namespace ООП_6_ЛАБОРАТОРНАЯ
{
    public abstract class Figure: Iobserver
    {
        protected bool chosen;
        protected Color color; // цвет ручки
        protected int up_down = 0; // 1 - уменьшить фигуру, 2- увеличить
        protected int move = 0; // 1 - вверх, 2 - влево, 3 - вниз, 4 - вправо
        protected string movingf;
        protected GraphicsPath figurePath = new GraphicsPath();
        protected int maxForm_h;
        protected int maxForm_w;
        protected bool figure_downm = false;

        public Figure()
        {
            chosen = true;
            color = Color.Black;
        }

        public virtual bool getFigure_downm()
        {
            return figure_downm;
        }

        public virtual void setFigure_downm(bool figure_downm_)
        {
            figure_downm = figure_downm_;
        }

        public void setmaxForm_h_w(int h_, int w_)
        {
            maxForm_h = h_;
            maxForm_w = w_;
        }

        virtual public GraphicsPath GetPathF()
        {
            return figurePath;
        }

        virtual public string getMovingf()
        {
            return movingf;
        }

        virtual public void setMovingf(string movingf_)
        {
            movingf = movingf_;
        }

        virtual public void setMove(int move_) // устанавливает переменную для движения
        {
            move = move_;
        }

        virtual public int getMove()
        {
            return move;
        }

        virtual public void setUp_Down(int up_down_)
        {
            up_down = up_down_;
        }

        virtual public int getUp_Down()
        {
            return up_down;
        }

        virtual public void setChosen(bool chosen_)
        {
            chosen = chosen_;
        }

        virtual public bool getChosen() // возвращает переменную для выделения
        {
            return chosen;
        }

        virtual public void setColor(Color color_)
        {
            color = color_;
        }

        virtual public Color getColor()
        {
            return color;
        }

        public abstract bool countDist(int clickX_, int clickY_);

        public abstract int getX();

        public abstract int getY();

        public abstract void setX(int x_);

        public abstract void setY(int y_);

        public virtual void be_shosen()
        {
            if (chosen == true)
            {
                chosen = false;
            }
            else
            {
                chosen = true;
            }
        }

        public abstract void Draw(PaintEventArgs e); // отрисовывает фигуру

        public abstract void changeSize(string moving, int max_w, int max_h); // отрисовывает фигуру с новым размером

        public abstract void changeLocate(string moving, int max_w, int max_h); // отрисовывает фигуру с новыми координатами

        public abstract bool check_border(int max_w, int max_h, int X, int Y); // проверяет границы при добавлении фигуры на форму

        public abstract void save(StreamWriter writer);

        public abstract void load(StreamReader reader, FigureFactory factory, XmlReader rdr);

        public abstract bool canmove(string moving, int max_w, int max_h);

        public void onSubjectChanged(Iobservable who)
        {
            setMove(((StickyObj)who).getMove());
            changeLocate(((StickyObj)who).getMovingf(), maxForm_w, maxForm_h);
        }

        public abstract void move_withMouse(int dx, int dy);
    }

}
