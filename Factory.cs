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
    public abstract class FigureFactory
    {
        public abstract Figure createFigure(string code, int x, int y);
    }

    public class MyFigureFactory : FigureFactory
    {
        public override Figure createFigure(string code, int x, int y)
        {
            Figure figure = null;
            switch (code)
            {
                case "line":
                    figure = new Section(x, y);
                    break;
                case "circle":
                    figure = new Circle(x, y);
                    break;
                case "Triangle":
                    figure = new Triangle(x, y);
                    break;
                case "rectangle":
                    figure = new Rectangle(x, y);
                    break;
                case "-------group start-------":
                    figure = new Group(10);
                    break;
            }
            return figure;
        }
    }
}
