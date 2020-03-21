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

namespace ООП_6_ЛАБОРАТОРНАЯ
{
    class Tree : Iobservable, Iobserver
    {
        private List<Iobserver> _observers; // список наблюдателей
        private TreeNode nodes; // узел 

        public Tree()
        {
            _observers = new List<Iobserver>(); 
            nodes = new TreeNode();
            nodes.Text = "Storage";
        }

        public TreeNode GetNodes()
        {
            return nodes;
        }

        public void processNode(TreeNode tn, Figure o, int i)
        {
            TreeNode rootNode = new TreeNode(); //новый дочерний узел
            rootNode.Text = o.ToString().Remove(0, o.ToString().IndexOf(".") + 1); // текст узла соответствует названию класса фигуры
            tn.Nodes.Add(rootNode); // новый узел помещается на дерево
            tn.Nodes[tn.Nodes.Count - 1].Tag = i;

            if (rootNode.Parent.Text != "Storage") // ноды группы создаются без выделения
            {
                rootNode.Checked = false;
            }
            else if (o.getChosen() == true) // группа или просто узел помечается выделением, если выделена фигура(или группа)
            {
                rootNode.Checked = true;
            }

            if (o is Group)
            {
                for (int j = 0; j < (o as Group).get_gr_count(); j++)
                {
                    processNode(rootNode, (o as Group).get_gr_figure(j), j);
                }
            }
        }

        public void onSubjectChanged(Iobservable who)
        {
            nodes = new TreeNode();
            nodes.Text = "Storage";
            for (int j = 0; j < ((Storage)who).getCount(); j++)
            {
                processNode(nodes, ((Storage)who).GetFigure(j), j);
            }
        }

        public void addObservers(Iobserver o)
        {
            _observers.Add(o);
        }

        public void notifyEveryine()
        {
            for (int i = 0; i < _observers.Count(); i++)
            {
                _observers[i].onSubjectChanged(this);
            }
        }
    }
}
