using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
namespace CongressStats
{
    class BillActionDropDown : ListBox 
    {
        public BillActionDropDown()
        {
            //TextBox text = new TextBox();
            /*Frame frame = new Frame();
            frame.Height = 450;
            frame.Width = 625;
            */
            ListBox listbox = new ListBox();
            listbox.HorizontalAlignment = HorizontalAlignment.Left;
            listbox.Width = 250;
            listbox.Height = 300;
            //listbox.RenderTransformOrigin = new Point(0.495,0.521);
            listbox.VerticalAlignment = VerticalAlignment.Top;
            listbox.Width = 170;
            listbox.Margin = new Thickness(10, 10, 10, 10);
            
        }
    }
}
