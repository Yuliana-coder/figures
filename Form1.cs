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
    public partial class Form1 : Form
    { 
        Dictionary<string, Command> commands = new Dictionary<String, Command>();  //коллекция команд, (код клавиши используется как ключ в событии keydown)
        Stack<Command> history = new Stack<Command>();//стек, для истории выполненных команд
        Stack<Command> undo = new Stack<Command>();//стек, для истории отмененных команд

        public Form1()
        {
            InitializeComponent();
            int max_h = (int)panel1.ClientSize.Height; // высота окна
            int max_w = (int)panel1.ClientSize.Width + 50;

            commands.Add("Subtract", new ChangeSizeCommand("substract", max_w, max_h,1));
            commands.Add("Add", new ChangeSizeCommand("add", max_w, max_h,2));
            commands.Add("Up", new ChangeLocateCommand("up", max_w, max_h, 1));
            commands.Add("Left", new ChangeLocateCommand("left", max_w, max_h, 2));
            commands.Add("Down", new ChangeLocateCommand("down", max_w, max_h, 3));
            commands.Add("Right", new ChangeLocateCommand("right", max_w, max_h, 4));
            commands.Add("Create", new CreateFigureCommand());
            commands.Add("Load", new LoadCommand());
            commands.Add("Grouping", new GroupingCommand());
            commands.Add("Ungrouping", new UngroupingCommand());
            commands.Add("Delete", new DeleteCommand());
            commands.Add("Chosen", new ChosenCommand());
            commands.Add("ChangeColor", new ChangeColorCommand());
            commands.Add("Sticky", new StickyObjCommand());
            commands.Add("MouseMove", new MouseMoveCommand());
        }

        Storage storage = new Storage(100);

        private void section1_Click(object sender, EventArgs e)
        {
            storage.setKind(1);
            section1.BackColor = Color.Red;
            circle2.BackColor = Color.White;
            triangle3.BackColor = Color.White;
            rectangle4.BackColor = Color.White;
            toolStripButton1.BackColor = Color.White;
        } // kind = 1

        private void circle2_Click(object sender, EventArgs e)
        {
            storage.setKind(2);
            section1.BackColor = Color.White;
            circle2.BackColor = Color.Red;
            triangle3.BackColor = Color.White;
            rectangle4.BackColor = Color.White;
            toolStripButton1.BackColor = Color.White;
        }  // kind = 2

        private void triangle3_Click(object sender, EventArgs e)
        {
            storage.setKind(3);
            section1.BackColor = Color.White;
            circle2.BackColor = Color.White;
            triangle3.BackColor = Color.Red;
            rectangle4.BackColor = Color.White;
            toolStripButton1.BackColor = Color.White;
        }  // kind = 3

        private void rectangle4_Click(object sender, EventArgs e)
        {
            storage.setKind(4);
            section1.BackColor = Color.White;
            circle2.BackColor = Color.White;
            triangle3.BackColor = Color.White;
            rectangle4.BackColor = Color.Red;
            toolStripButton1.BackColor = Color.White;
        }  // kind = 4

        private void toolStripButton1_Click(object sender, EventArgs e) // kind = 0
        {
            storage.setKind(0);
            section1.BackColor = Color.White;
            circle2.BackColor = Color.White;
            triangle3.BackColor = Color.White;
            rectangle4.BackColor = Color.White;
            toolStripButton1.BackColor = Color.Red;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            bool flag = false;
            for (int i = 0; i < storage.getCount(); i++)
            {
                if (storage.GetFigure(i).countDist(e.X, e.Y) == true)
                {
                    ChosenCommand ch_com = (ChosenCommand)commands["Chosen"].clon();
                    ch_com.execute(storage, i);
                    history.Push(ch_com);
                    flag = true;
                    break;
                }
            }

            if (flag == false)
            {
                for (int i = 0; i < storage.getCount(); i++)
                {
                    if (storage.GetFigure(i).getChosen() == true)
                    {
                        ChosenCommand ch_com = (ChosenCommand)commands["Chosen"].clon();
                        ch_com.execute(storage, i);
                        history.Push(ch_com);
                        flag = true;
                    }
                }

                if (storage.getKind() == 1)
                {
                    CreateFigureCommand create = (CreateFigureCommand)commands["Create"].clon();
                    create.execute("line", storage, e.X, e.Y);
                    history.Push(create);
                }

                if (storage.getKind() == 2)
                {
                    CreateFigureCommand create = (CreateFigureCommand)commands["Create"].clon();
                    create.execute("circle", storage, e.X, e.Y);
                    history.Push(create);
                }

                if (storage.getKind() == 3)
                {
                    CreateFigureCommand create = (CreateFigureCommand)commands["Create"].clon();
                    create.execute("Triangle", storage, e.X, e.Y);
                    history.Push(create);
                }

                if (storage.getKind() == 4)
                {
                    CreateFigureCommand create = (CreateFigureCommand)commands["Create"].clon();
                    create.execute("rectangle", storage, e.X, e.Y);
                    history.Push(create);
                }
            }

            undo_unexecute.Enabled = true;
            Refresh();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Update_Tree();
            for (int i = 0; i < storage.getCount(); i++)
            {
                storage.GetFigure(i).Draw(e);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {          
            int max_h = (int)panel1.ClientSize.Height; // высота окна
            int max_w = (int)panel1.ClientSize.Width;

            try
            {
                storage.moving_obj(commands[$"{e.KeyCode}"], max_w, max_h, history);
                this.Refresh();
            }
            catch
            {

            }

            Refresh();
        }

        private void toolStripButton5_Click(object sender, EventArgs e) // удаление
        {
            DeleteCommand d_com = (DeleteCommand)commands["Delete"].clon();
            d_com.execute(storage);
            history.Push(d_com);
            Refresh();
        }

        private void grouping_Click(object sender, EventArgs e)
        {
            GroupingCommand gr_com = (GroupingCommand)commands["Grouping"].clon();
            gr_com.execute(storage);
            history.Push(gr_com);
            Refresh();
        }

        private void ungrouping_Click_1(object sender, EventArgs e)
        {
            UngroupingCommand un_gr = (UngroupingCommand)commands["Ungrouping"].clon();
            un_gr.execute(storage);
            history.Push(un_gr);
            Refresh();
        }

        private void color_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) 
            {
                for (int i = 0; i < storage.getCount(); i++)
                {
                    if (storage.GetFigure(i).getChosen() == true)
                    {
                        ChangeColorCommand ch_color = (ChangeColorCommand)commands["ChangeColor"].clon();
                        ch_color.execute(storage, colorDialog1.Color);
                        history.Push(ch_color);
                        ChosenCommand ch_com = (ChosenCommand)commands["Chosen"].clon();
                        ch_com.execute(storage, i);
                        history.Push(ch_com);
                    }
                }
            }
            Refresh();
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл            
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine("<?xml version =\"1.0\"?>"); 
            writer.WriteLine("<svg width=\"1001\" height=\"565\""); 
            writer.WriteLine("viewBox=\"0 0 1001 565\"");
            writer.WriteLine("xmlns=\"http://www.w3.org/2000/svg\">");
            //сохраняем каждый элемент хранилища
            for (int i = 0; i < storage.getCount(); i++)
            {
                storage.GetFigure(i).save(writer);
            }
            //конец файла
            writer.WriteLine("</svg>");
            writer.Close();
            MessageBox.Show("Файл сохранен");
        }

        private void LOAD_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)  
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            MessageBox.Show("Файл открыт");
            /* LoadCommand load_com = (LoadCommand)commands["Load"].clon();
             load_com.execute(filename, storage);
             history.Push(load_com);
             undo_unexecute.Enabled = true;*/


            MyFigureFactory factory = new MyFigureFactory();

            XmlReader rdr = XmlReader.Create(new System.IO.StringReader(File.ReadAllText(openFileDialog1.FileName)));

            storage.LOAD(factory, filename, rdr);

            Refresh();
        }

        Tree tree = new Tree();

        private void Form1_Load(object sender, EventArgs e)
        {
            storage.addObservers(tree);
            tree.addObservers(storage);
        }

        public void Update_Tree() // обновляет дерево при любом изменении
        {
            treeFigure.Nodes.Clear(); // удаляет все узлы
            treeFigure.Nodes.Add(tree.GetNodes()); // добавляет узел
            treeFigure.ExpandAll(); // раскрывает все узлы
        }

        private void chosenAll_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < storage.getCount(); i++)
            {
                storage.GetFigure(i).setChosen(true);
            }
            storage.notifyEveryine();
            Refresh();
        }

        private void treeFigure_AfterCheck(object sender, TreeViewEventArgs e)
        {
            check_allNodes(e.Node);
            tree.notifyEveryine();
            Refresh();
        }

        private void check_allNodes(TreeNode node)
        {
            for(int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].Checked = node.Checked;
                check_allNodes(node.Nodes[i]);
            }
        }

        private void sticky_Click(object sender, EventArgs e)
        {
            for(int i = storage.getCount() - 1; i >= 0; i --)
            {
                if(storage.GetFigure(i).getChosen() == true)
                {
                    StickyObjCommand sticky_com = (StickyObjCommand)commands["Sticky"].clon();
                    sticky_com.execute(storage, i);
                    history.Push(sticky_com);
                }
            }
            Refresh();
        }

        private void undo_unexecute_Click(object sender, EventArgs e)
        {
            if (history.Count != 0)
            {
                history.Peek().unexecute();
                undo.Push(history.Pop());
                if (history.Count == 0)
                {
                    undo_unexecute.Enabled = false;
                }
                redo_execute.Enabled = true;
                Refresh();
            }
        }

        private void redo_execute_Click(object sender, EventArgs e)
        {
            if (undo.Count != 0)
            {
                undo.Peek().execute();
                history.Push(undo.Pop());
                if (undo.Count == 0)
                {
                    redo_execute.Enabled = false;
                }
                undo_unexecute.Enabled = true;
                this.Refresh();
            }
        }

        Point last_proc_point = new Point(-1,-1);

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (last_proc_point.Y == -1 && last_proc_point.Y == -1)
            {
                return;
            }
            else
            {
                int dx = e.X - last_proc_point.X;
                int dy = e.Y - last_proc_point.Y;
                for (int i = 0; i < storage.getCount(); i++)
                {
                    if (storage.GetFigure(i).getChosen() == true)
                    {
                        MouseMoveCommand mouse = (MouseMoveCommand)commands["MouseMove"].clon();
                        mouse.execute(e, storage.GetFigure(i), dx, dy);
                        break;
                    }
                }
                last_proc_point = new Point(e.X, e.Y);
            }
            Refresh();
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (storage.getKind() == 0)
            {
                last_proc_point = new Point(e.X, e.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            last_proc_point = new Point(-1, -1);
        }

    }

}