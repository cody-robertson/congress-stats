using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CongressStats
{
    public interface IProfilePage
    { 
        void FormatTitle();
        void FormatListBox();
        void FormatDescription();       
    }
}
