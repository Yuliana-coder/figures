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
    public interface Iobserver
    {
        void onSubjectChanged(Iobservable who);
    }

    public interface Iobservable
    {
        void addObservers(Iobserver o);
        void notifyEveryine();
    }

}
