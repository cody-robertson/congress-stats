using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CongressStats
{
    abstract class ProfilePage
    {

        public abstract Window GetPage();

        public abstract Label GetTitle();
        public abstract ListBox GetListBox();
    }
}
