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
    class Storage : Iobserver, Iobservable
    {
        private Figure[] figures; // массив фигур
        private int N; // размерность массива
        private int elemN; // кол-во фигур в массиве
        private int kind = 0;
        private int AllChosen;
        private List<Iobserver> _observers;

        public Storage()
        {
            figures = null;
            N = 0;
            elemN = 0;
            AllChosen = 0;
        }

        public Storage(int N_)
        {
            _observers = new List<Iobserver>();
            figures = new Figure[N_];
            N = N_;
            elemN = 0;
            AllChosen = 0;
        }

        public void setKind(int kind_)
        {
            kind = kind_;
        }

        public int getKind()
        {
            return kind;
        }

        public int getCount()
        {
            return elemN;
        }

        public Figure GetFigure(int i_)
        {
            return figures[i_];
        }

        public void setFigure(Figure obj) // помещаем фигуру в хранилище
        {
            if (elemN == N)
            {
                Figure[] masskeep = figures;
                N = N * 2; // увеличиваем размерность массива
                figures = new Figure[N]; //массив с новой размерностью
                for (int i = 0; i < elemN; i++)
                {
                    figures[i] = masskeep[i]; // копируем фигуры в новый массив(новой размерности)
                }
                elemN++;
                figures[elemN - 1] = obj; // добавляем фигуру в конец массива
            }
            else
            {
                elemN++;
                figures[elemN - 1] = obj;
            }
            notifyEveryine();
        }

        public void deleteFigure(int i_) //удаление фигуры по индексу
        {
            for (int i = i_; i < elemN - 1; i++)
            {
                figures[i] = figures[i + 1];
            }
            figures[elemN - 1] = null;
            elemN--;
            notifyEveryine();
        }

        public void LOAD(MyFigureFactory factory, string filename, XmlReader rdr)
        {
            StreamReader reader = new StreamReader(filename);
            /*int count = System.IO.File.ReadAllLines(filename).Length;
            for (int i = 0; i < count; i++)
            {
                string read;
                read = reader.ReadLine();
                bool flag1 = false;
                Figure figure = factory.createFigure(read, 0, 0);
                if (figure != null)
                {

                    figure.load(reader, factory);
                    setFigure(figure);
                }
                
            }*/

            //int count = System.IO.File.ReadAllLines(filename)- 5;
            //for (int i = 0; i < count; i++)
            //{

            //Строка для чтения
            string read = "";


            read = reader.ReadLine();

            //Пока файл читается
            while (rdr.Read())
            {
                //Если встретился тег, тогда создаем соответвующую фигуру и загружаем ее в хранилище 
                if (rdr.NodeType == XmlNodeType.Element && rdr.LocalName != "svg")
                {
                    Figure figure = factory.createFigure(rdr.LocalName, 0, 0);
                    figure.load(reader, factory, rdr);
                    //Помещаем фигуру в хранилище
                    setFigure(figure);
                }

            }

            notifyEveryine();
        }

        public void noChosen()
        {
            for(int i = 0; i < elemN; i++)
            {
                figures[i].setChosen(false);
            }
            notifyEveryine();
        }

        public int getAllChosen()
        {
            AllChosen = 0;
            for (int i = 0; i < elemN; i++)
            {
                if (figures[i].getChosen() == true)
                    AllChosen++;
            }
            return AllChosen;
        }

        public void onSubjectChanged(Iobservable who)  // выделение фигур изменяются, если выделяются выделение у соответсвующего узла
        {
            Update_storage(((Tree)who).GetNodes().Nodes);
        }

        public void addObservers(Iobserver o) // хранилище добавляет подписчика
        {
            _observers.Add(o);
        }

        public void notifyEveryine() // хранилище оповещает всех своих подписчиков об изменениях
        {
            for (int i = 0; i < _observers.Count(); i++)
            {
                 _observers[i].onSubjectChanged(this);
            }
        }

        public void Update_storage(TreeNodeCollection nodeCollection) // при изменении выделения в дереве, меняется выделение у фигур
        {
            foreach (TreeNode treenode in nodeCollection) // перебрать все узлы коллекции
            {

                if (treenode.Checked == true)
                {
                    figures[(int)treenode.Tag].setChosen(true);
                }
                else
                {
                    figures[(int)treenode.Tag].setChosen(false);
                }
            }
        }

        public void moving_obj(Command command, int max_w, int max_h, Stack<Command> history)
        {
            for(int i = 0; i < elemN; i++)
            {
                if (figures[i].getChosen() == true)
                {
                    if (figures[i] is StickyObj) // для выделенного липкого объекта проводится проверка
                    {
                    
                        for (int j = 0; j < elemN; j++)
                        {
                            if (i != j)
                            {
                                (figures[i] as StickyObj).sticky_bord(figures[j]);//проверяем границы 
                            }
                        }
                    }
                    Command com = command.clon();
                    command.execute(figures[i], max_w, max_h);
                    history.Push(command);
                }
            }
        }
    }
}
