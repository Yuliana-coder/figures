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
    class Command
    {
        virtual public void execute(Figure p, int MAX_w, int MAX_h)
        { }
        virtual public void execute()
        { }
        virtual public void unexecute()
        { }
        virtual public Command clon()
        {
            return new Command();
        }
    }

    class ChangeLocateCommand : Command
    {
        private Figure f;
        private string moving;
        private int max_w;
        private int max_h;
        private int move;

        public ChangeLocateCommand(string moving_, int max_w_, int max_h_, int move_)
        {
            moving = moving_;
            max_w = max_w_;
            max_h = max_h_;
            move = move_;
            f = null;
        }

        override public void execute(Figure f_, int max_w_, int max_h_) // выполнить передвижение
        {
            f = f_;
            max_w = max_w_;
            max_h = max_h_;
            if (f.canmove(moving, max_w, max_h) == true)
            {
                f.setMove(move);
                f.changeLocate(moving, max_w, max_h);
            }
        }

        override public void execute() // отменить передвижение
        {
            if (f != null)
            {
                if (f.canmove(moving, max_w, max_h) == true)
                {
                    if (move == 1)
                    {
                        f.setMove(3);
                        f.changeLocate("down", max_w, max_h); ;
                    }
                    if (move == 3)
                    {
                        f.setMove(1);
                        f.changeLocate("up", max_w, max_h); ;
                    }
                    if (move == 2)
                    {
                        f.setMove(4);
                        f.changeLocate("right", max_w, max_h); ;
                    }
                    if (move == 4)
                    {
                        f.setMove(2);
                        f.changeLocate("left", max_w, max_h); ;
                    }
                }
            }
        }

        override public void unexecute() // отменить передвижение
        {
            if (f != null)
            {
                if (move == 1)
                {
                    f.setMove(3);
                    f.changeLocate("down", max_w, max_h);
                }
                if (move == 3)
                {
                    f.setMove(1);
                    f.changeLocate("up", max_w, max_h);
                }
                if (move == 2)
                {
                    f.setMove(4);
                    f.changeLocate("right", max_w, max_h);
                }
                if (move == 4)
                {
                    f.setMove(2);
                    f.changeLocate("left", max_w, max_h);
                }
            }
        }

        override public Command clon()
        {
            return new ChangeLocateCommand(moving, max_w, max_h, move);
        }
    }

    class ChangeSizeCommand : Command
    {
        private Figure f;
        private int max_w;
        private int max_h;
        private string moving;
        private int up_down;

        public ChangeSizeCommand(string moving_, int max_w_, int max_h_, int up_down_)
        {
            moving = moving_;
            max_w = max_w_;
            max_h = max_h_;
            up_down = up_down_;
            f = null;
        }

        override public void execute(Figure f_, int max_w_, int max_h_)
        {
            f = f_;
            max_w = max_w_;
            max_h = max_h_;
            if (f.canmove(moving, max_w, max_h) == true)
            {
                f.setUp_Down(up_down);
                f.changeSize(moving, max_w, max_h);
            }
        }

        override public void execute()
        {
            if (f != null)
            {
                if (f.canmove(moving, max_w, max_h) == true)
                {
                    if (up_down == 1)
                    {
                        f.setUp_Down(2);
                        f.changeSize("add", max_w, max_h);
                    }
                    if (up_down == 2)
                    {
                        f.setUp_Down(1);
                        f.changeSize("substract", max_w, max_h);
                    }
                }
            }
        }

        override public void unexecute()
        {
            if (f != null)
            {
                if (f.canmove(moving, max_w, max_h) == true)
                {
                    if (up_down == 1)
                    {
                        f.setUp_Down(2);
                        f.changeSize("add", max_w, max_h);
                    }
                    if (up_down == 2)
                    {
                        f.setUp_Down(1);
                        f.changeSize("substract", max_w, max_h);
                    }
                }
            }
        }

        override public Command clon()
        {
            return new ChangeSizeCommand(moving, max_w, max_h, up_down);
        }
    }

    class CreateFigureCommand : Command
    {
        MyFigureFactory factory;
        string code;
        Figure f;
        Storage storage;
        int x = 0;
        int y = 0;

        public CreateFigureCommand()
        {
            factory = new MyFigureFactory();
            f = null;
        }

        public void execute(string code_, Storage storage_, int x_, int y_)
        {
            code = code_;
            storage = storage_;
            x = x_;
            y = y_;
            f = factory.createFigure(code, x, y);
            storage.setFigure(f);
        }

        override public void execute()
        {
            f = factory.createFigure(code, x, y);
            storage.setFigure(f);
        }

        override public void unexecute()
        {
            storage.deleteFigure(storage.getCount() - 1);
        }

        override public Command clon()
        {
            return new CreateFigureCommand();
        }
    }

    class LoadCommand : Command
    {
        private Storage storage;
        private Storage copy;
        private string filename;
        MyFigureFactory factory;
        XmlReader rdr;

        public LoadCommand()
        {
            storage = new Storage();
            factory = new MyFigureFactory();
            filename = null;
        }


        public void execute(string filename_, Storage storage_)
        {
            storage = storage_;
            copy = storage_;
            filename = filename_;
            storage.LOAD(factory, filename, rdr);
        }

        public override void execute()
        {
            storage.LOAD(factory, filename, rdr);
        }

        override public void unexecute()
        { 
            storage = copy;
        }

        override public Command clon()
        {
            return new LoadCommand();
        }
    }

    class GroupingCommand : Command
    {
        private Storage storage;
        Group g;

        public GroupingCommand()
        { }

        public void execute(Storage storage_)
        {
            storage = storage_;
            Group group_ = new Group(20);
            for (int i = storage.getCount() - 1; i >= 0; i--)
            {
                if (storage.GetFigure(i).getChosen() == true)
                {
                    group_.add_toGroup(storage.GetFigure(i));
                    storage.deleteFigure(i);
                }
            }
            if (group_.get_gr_count() != 0)
            {
                storage.setFigure(group_);
                group_.setChosen(true);
            }
        }

        public override void execute()
        {
            Group group_ = new Group(20);
            for (int i = storage.getCount() - 1; i >= 0; i--)
            {
                if (storage.GetFigure(i).getChosen() == true)
                {
                    group_.add_toGroup(storage.GetFigure(i));
                    storage.deleteFigure(i);
                }
            }
            if (group_.get_gr_count() != 0)
            {
                storage.setFigure(group_);
                group_.setChosen(true);
            }
        }

        public override void unexecute()
        {
            g = (Group)storage.GetFigure(storage.getCount()-1);
            int old_count = storage.getCount();
            for (int i = old_count - 1; i >= 0; i--)
            {
                if ((storage.GetFigure(i) is Group) && (storage.GetFigure(i).getChosen() == true))
                {
                    for (int j = 0; j < ((Group)storage.GetFigure(i)).get_gr_count(); j++)
                    {
                        storage.setFigure(((Group)storage.GetFigure(i)).get_gr_figure(j));
                    }
                    storage.deleteFigure(i);
                }
            }
        }

        public override Command clon()
        {
            return new GroupingCommand();
        }
    }

    class UngroupingCommand : Command
    {
        private Storage storage;
        Group g;

        public UngroupingCommand()
        { }

        public void execute(Storage storage_)
        {
            storage = storage_;
            int old_count = storage.getCount();
            for (int i = old_count - 1; i >= 0; i--)
            {
                if ((storage.GetFigure(i) is Group) && (storage.GetFigure(i).getChosen() == true))
                {
                    for (int j = 0; j < ((Group)storage.GetFigure(i)).get_gr_count(); j++)
                    {
                        storage.setFigure(((Group)storage.GetFigure(i)).get_gr_figure(j));
                    }
                    storage.deleteFigure(i);
                }
            }
        }

        public override void execute()
        {
            int old_count = storage.getCount();
            for (int i = old_count - 1; i >= 0; i--)
            {
                if ((storage.GetFigure(i) is Group) && (storage.GetFigure(i).getChosen() == true))
                {
                    for (int j = 0; j < ((Group)storage.GetFigure(i)).get_gr_count(); j++)
                    {
                        storage.setFigure(((Group)storage.GetFigure(i)).get_gr_figure(j));
                    }
                    storage.deleteFigure(i);
                }
            }
        }

        public override void unexecute()
        {
            Group group_ = new Group(20);
            for (int i = storage.getCount() - 1; i >= 0; i--)
            {
                if (storage.GetFigure(i).getChosen() == true)
                {
                    group_.add_toGroup(storage.GetFigure(i));
                    storage.deleteFigure(i);
                }
            }
            if (group_.get_gr_count() != 0)
            {
                storage.setFigure(group_);
                group_.setChosen(true);
            }
        }

        public override Command clon()
        {
            return new UngroupingCommand();
        }
    }

    class DeleteCommand : Command
    {
        Storage storage;
        private Figure[] figures;
        private int count;

        public DeleteCommand()
        {
            count = 0;
        }

        public void execute(Storage storage_)
        {
            storage = storage_;
            count = storage.getAllChosen();
            figures = new Figure[count];
            int k = 0;
            for (int i = storage.getCount() - 1; i >= 0; i--)
            {
                if (storage.GetFigure(i).getChosen() == true)
                {
                    figures[k] = storage.GetFigure(i);
                    storage.deleteFigure(i);
                    k++;
                }
            }
        }

        override public void execute()
        {
            for (int i = storage.getCount() - 1; i >= 0; i--)
            {
                if (storage.GetFigure(i).getChosen() == true)
                    storage.deleteFigure(i);
            }
        }

        public override void unexecute()
        {
            for (int i = 0; i < count; i++)
                storage.setFigure(figures[i]);
        }

        public override Command clon()
        {
            return new DeleteCommand();
        }
    }

    class ChangeColorCommand : Command
    {
        Color color;
        Color[] p;
        int count;
        Storage storage;

        public ChangeColorCommand()
        { }

        public void execute(Storage storage_, Color color_)
        {
            storage = storage_;
            color = color_;
            count = storage.getAllChosen();
            int k = 0;
            p = new Color[count];
            for (int i = 0; i < storage.getCount(); i++)
            {
                if (storage.GetFigure(i).getChosen() == true)
                {
                    p[k] = storage.GetFigure(i).getColor();
                    storage.GetFigure(i).setColor(color);
                    k++;
                }
            }

        }

        public override void execute()
        {
            for (int i = 0; i < storage.getCount(); i++)
            {
                if (storage.GetFigure(i).getChosen() == true)
                {
                    storage.GetFigure(i).setColor(color);
                }
            }
        }

        public override void unexecute()
        {
            int k = 0;
            for (int i = 0; i < storage.getCount(); i++)
            {
                if (storage.GetFigure(i).getChosen() == true)
                {
                    storage.GetFigure(i).setColor(p[k]);
                    k++;
                }
            }
        }

        public override Command clon()
        {
            return new ChangeColorCommand();
        }
    }

    class ChosenCommand : Command
    {
        Storage storage;
        int index;

        public ChosenCommand()
        {
            index = 0;
        }

        public void execute(Storage storage_, int index_)
        {
            storage = storage_;
            index = index_;
            storage.GetFigure(index).be_shosen();
            storage.notifyEveryine();

        }

        override public void execute()
        {
            storage.GetFigure(index).be_shosen();
        }

        public override void unexecute()
        {
            storage.GetFigure(index).be_shosen();
        }

        public override Command clon()
        {
            return new ChosenCommand();
        }

    }

    class StickyObjCommand : Command
    {
        Storage storage;
        StickyObj sticky_obj;
        int index;

        public StickyObjCommand()
        {
            index = 0;
        }

        public void execute(Storage storage_, int index_)
        {
            storage = storage_;
            index = index_;
            sticky_obj = new StickyObj(storage.GetFigure(index)); // по переданному индексу делаем объект липким
            storage.deleteFigure(index);
            storage.setFigure(sticky_obj);
            Console.WriteLine(index);
        }

        override public void execute()
        {
            sticky_obj = new StickyObj(storage.GetFigure(index));
            storage.deleteFigure(index);
            storage.setFigure(sticky_obj);
            index = storage.getCount() - 1;
        }

        public override void unexecute()
        {
            storage.deleteFigure(index);
            storage.setFigure(sticky_obj.getFigure());
            index = storage.getCount()-1;
        }

        public override Command clon()
        {
            return new StickyObjCommand();
        }

    }

    class MouseMoveCommand : Command // передвижение объектов мышью
    {
        Figure f;
        private int dx;
        private int dy;

        public MouseMoveCommand()
        {
            f = null;
            dx = 0;
            dy = 0;
        }

        public void execute(MouseEventArgs e, Figure f_, int dx_, int dy_)
        {
            dx = dx_;
            dy = dy_;
            f = f_;
            f.move_withMouse(dx, dy);
        }

        override public Command clon()
        {
            return new MouseMoveCommand();
        }
    }
}
