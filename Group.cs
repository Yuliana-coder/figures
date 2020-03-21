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
    class Group : Figure // группа фигур, хранилище
    {
        private Figure[] group; // массив фигур и групп фигур
        private int max_count; // максимальное кол-во фигур и групп в массиве
        private int count; // количество фигур и групп в массиве

        public Group()
        {
            group = null;
            max_count = 0;
            count = 0;
        }

        public Group(int max_count_)
        {
            group = new Figure[max_count_];
            max_count = max_count_;
            count = 0;
        }

        public int get_gr_count()
        {
            return count;
        }

        public override void move_withMouse(int dx, int dy)
        {
            for(int i = 0; i < count; i++)
            {
                group[i].move_withMouse(dx, dy);
            }
        }

        public override void setX(int x_)
        {
            for(int i = 0; i < count; i++)
            {
                group[i].setX(x_);
            }
        }

        public override void setY(int y_)
        {
            for(int i = 0; i < count; i++)
            {
                group[i].setY(y_);
            }
        }

        public override void be_shosen()
        {
            if (group[0].getChosen() == true)
            {
                chosen = false;
                for(int i = 0; i < count; i++)
                {
                    group[i].setChosen(false);
                }
            }
            else
            {
                chosen = true;
                for (int i = 0; i < count; i++)
                {
                    group[i].setChosen(true);
                }
            }
        }

        public override bool getFigure_downm()
        {
            return group[0].getFigure_downm();
        }

        public override void setFigure_downm(bool figure_downm_)
        {
            figure_downm = figure_downm_;
            for(int i = 0; i < count; i++)
            {
                group[i].setFigure_downm(figure_downm_);
            }
        }

        public override void setColor(Color color_)
        {
            color = color_;
            for (int i = 0; i < count; i++)
            {
                group[i].setColor(color_);
            }
        }

        public override Color getColor()
        {
            return group[0].getColor();
        }

        public override void setUp_Down(int up_down_)
        {
            up_down = up_down_;
            for (int i = 0; i < count; i++)
            {
                group[i].setUp_Down(up_down_);
            }
        }

        public override int getUp_Down()
        {
            return group[0].getUp_Down();
        }

        public void add_toGroup(Figure obj) // добавление в группу
        {
            if (count == max_count)
            {
                Figure[] masskeep = group;
                max_count = max_count * 2; // увеличиваем размерность массива
                group = new Figure[max_count]; //массив с новой размерностью
                for (int i = 0; i < count; i++)
                {
                    group[i] = masskeep[i]; // копируем фигуры и группы фигур в новый массив(новой размерности)
                }
                count++;
                group[count - 1] = obj; // добавляем фигуру или группу фигур в конец массива
            }
            else
            {
                count++;
                group[count - 1] = obj;
            }
        }

        public override int getX()
        { return 0; }

        public override int getY()
        { return 0; }

        public Figure get_gr_figure(int i)
        {
            return group[i];
        }

        public override GraphicsPath GetPathF()
        {
            return group[0].GetPathF();
        }

        public override bool countDist(int clickX_, int clickY_)
        {
            bool retDist = false;
            for (int i = 0; i < count; i++)
            {
                if (group[i].countDist(clickX_, clickY_) == true)
                {
                    retDist = true;
                    break;
                }
            }
            return retDist;
        }

        public override void Draw(PaintEventArgs e) // отрисовка
        {
            for (int i = 0; i < count; i++)
            {
                group[i].Draw(e);
            }
        }

        public override int getMove()
        {
            return group[0].getMove();
        }

        public override void setMove(int move_)
        {
            move = move_;
            for (int i = 0; i < count; i++)
            {
                group[i].setMove(move_);
            }
        }

        public override string getMovingf()
        {
            return group[0].getMovingf();
        }

        public override void setMovingf(string movingf_)
        {
            movingf = movingf_;
            for (int i = 0; i < count; i++)
            {
                group[i].setMovingf(movingf_);
            }
        }

        public override bool getChosen()
        {
            return group[0].getChosen();
        }

        public override void setChosen(bool chosen_)
        {
            chosen = chosen_;
            for (int i = 0; i < count; i++)
            {
                group[i].setChosen(chosen_);
            }
        }


        public override void changeSize(string moving, int max_w_, int max_h_)
        {
            if (canmove(moving, max_w_, max_h_) == true)
            {
                for (int i = 0; i < count; i++)
                {
                    group[i].changeSize(moving, max_w_, max_h_);
                }
            }
        }

        public override void changeLocate(string moving, int max_w_, int max_h_)
        {
            if (canmove(moving, max_w_, max_h_) == true)
            {
                for (int i = 0; i < count; i++)
                {
                    group[i].changeLocate(moving, max_w_, max_h_);
                }
            }
        }

        public override bool check_border(int max_w, int max_h, int X, int Y)
        {
            bool retCheck = false;
            for (int i = 0; i < count; i++)
            {
                if (group[i].check_border(max_w, max_h, X, Y) == true)
                {
                    retCheck = true;
                }
                break;
            }
            return retCheck;
        }

        public override bool canmove(string moving, int max_w, int max_h)
        {
            bool ret_move = false;
            for (int i = 0; i < count; i++)
            {
                if (group[i].canmove(moving, max_w, max_h) == false)
                {
                    ret_move = false;
                    break;
                }
                else
                {
                    ret_move = true;
                }
            }
            return ret_move;
        }

        public override void save(StreamWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine("-------group start-------");
            writer.Write(count);
            writer.WriteLine();
            for (int i = 0; i < count; i++)
            {
                group[i].save(writer);
            }
            writer.WriteLine("-------group ending-------");
            writer.WriteLine();
        }

        public override void load(StreamReader reader, FigureFactory factory, XmlReader rdr)
        {
            string count_;
            count_ = reader.ReadLine();
            for (int i = 0; i < Convert.ToInt32(count_) * 6; i++)
            {
                string read;
                read = reader.ReadLine();
                bool flag1 = false;
                Figure figure = factory.createFigure(read, 0, 0);
                if (figure == null)
                {
                    flag1 = true;
                }
                if (flag1 == false)
                {
                    {
                        figure.load(reader, factory, rdr);
                        add_toGroup(figure);
                    }
                }
            }
        }
    }
}
