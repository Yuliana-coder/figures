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

namespace ООП_6_ЛАБОРАТОРНАЯ
{
    class StickyObj : Figure, Iobservable
    {
        private List<Iobserver> _observers; // список наблюдателей
        private Figure sticky; // липкий объект - это фигура, которая "приклеивает" к себе при движении другие фигуры

        public StickyObj(Figure figure_)
        {
            _observers = new List<Iobserver>();
            sticky = figure_;
        }

        public void addObservers(Iobserver o)
        {
            _observers.Add(o);
        }

        public override void be_shosen()
        {
            if (sticky.getChosen() == true)
            {
                sticky.setChosen(false);
            }
            else
            {
                sticky.setChosen(true);
            }
        }

        public void notifyEveryine()
        {
            for (int i = 0; i < _observers.Count(); i++)
            {
                _observers[i].onSubjectChanged(this); // наблюдатели - это фигуры, которые касаются липкого объекта при движении+
            }
        }

        public Figure getFigure()
        {
            return sticky;
        }

        public override void setColor(Color color_)
        {
            sticky.setColor(color_);
        }

        public override Color getColor()
        {
            return sticky.getColor();
        }

        public override int getMove()
        {
            return sticky.getMove();
        }

        public override void setMove(int move_)
        {
            sticky.setMove(move_);
        }

        public override string getMovingf()
        {
            return sticky.getMovingf();
        }

        public override void setMovingf(string movingf_)
        {
            sticky.setMovingf(movingf_);
        }

        public override int getX()
        {
            return sticky.getX();
        }

        public override int getY()
        {
            return sticky.getY();
        }

        public override bool getChosen()
        {
            return sticky.getChosen();
        }

        public override void setChosen(bool chosen_)
        {
            sticky.setChosen(chosen_);
        }

        public override void setX(int x_)
        {
            sticky.setX(x_);
        }

        public override void setY(int y_)
        {
            sticky.setY(y_);
        }

        public override void move_withMouse(int dx, int dy)
        {
            sticky.move_withMouse(dx, dy);
        }

        public override bool getFigure_downm()
        {
            return sticky.getFigure_downm();
        }

        public override void setFigure_downm(bool figure_downm_)
        {
            sticky.setFigure_downm(figure_downm_);
        }

        public override void Draw(PaintEventArgs e)
        {
            sticky.Draw(e);
        }

        public override void changeSize(string moving, int max_w, int max_h)
        {
            sticky.changeSize(moving, max_w, max_h);
        }

        public override void changeLocate(string moving, int max_w, int max_h)
        {
            sticky.changeLocate(moving, max_w, max_h);
            notifyEveryine();
        }

        public override bool check_border(int max_w, int max_h, int X, int Y)
        {
            return sticky.check_border(max_w, max_h, X, Y);
        }

        public override void save(StreamWriter writer)
        {
            sticky.save(writer);
        }

        public override void load(StreamReader reader, FigureFactory factory, XmlReader rdr)
        {
            sticky.load(reader, factory, rdr);
        }

        public override bool canmove(string moving, int max_w, int max_h)
        {
            return sticky.canmove(moving, max_w, max_h);
        }

        public override bool countDist(int clickX_, int clickY_)
        {
            return sticky.countDist(clickX_, clickY_);
        }

        /*public void sticky_bord(Figure near) // добавление наблюдателей при "касании" фигур липкого объекта
        {
            bool iSstickObj = false; // этот объект уже липкий или нет
            for (int i = 0; i < _observers.Count; i++)
            {
                if (_observers[i] == near) // если эта фигура уже "прилипла" мы ее не проверяем
                {
                    iSstickObj = true;
                }
            }

            if (iSstickObj == false)
            {
                foreach (PointF point_near in near.GetPathF().PathPoints) // каждая точка контура фигуры сравнивается с кажой точкой контура липкого объекта
                {
                    foreach (PointF point_sticky in sticky.GetPathF().PathPoints) // GetPathF возвращает контур фигуры
                    {
                        float dx = (Math.Abs(point_sticky.X - point_near.X));
                        float dy = (Math.Abs(point_sticky.Y - point_near.Y));
                        if ((int)Math.Sqrt(dx * dx + dy * dy) <= 3)
                        {
                            addObservers(near);
                            iSstickObj = true;
                            break; // объект подписался, дальше не проверяем
                        }
                    }
                    if (iSstickObj == true) // если объект уже подписался, то проверка закончена
                        break;
                }
            }
        }*/

        public void sticky_bord(Figure near) // добавление наблюдателей при "касании" фигур липкого объекта
        {
            bool iSstickObj = false; // этот объект уже липкий или нет
            for (int i = 0; i < _observers.Count; i++)
            {
                if (_observers[i] == near) // если эта фигура уже "прилипла" мы ее не проверяем
                {
                    iSstickObj = true;
                }
            }

            if (iSstickObj == false)
            {
                foreach (PointF point_sticky in sticky.GetPathF().PathPoints) // точки контура липкого объекта отдаются в count_dist фигуры (вернет true, если попали точкой ы фигуру)
                {
                    if(near.countDist((int)point_sticky.X, (int)point_sticky.Y) == true)
                    {
                        addObservers(near);
                        break; // попав одной точкой, завершаем проверку
                    }
                }
            }
        }
    }
}
     
