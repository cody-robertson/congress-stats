using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace CongressStats
{
    class Bill_Profile : ProfilePage
    {
        public object Profile { get; private set; }

        public override Window GetPage()
        {
            Window page = new Window();
            page.Height = 450;
            page.Width = 625;
            Grid grid = new Grid();
            ListBox listBox = GetListBox();
            listBox.Visibility = Visibility.Visible;
            grid.Children.Add(GetTitle());
            grid.Children.Add(listBox);
            grid.Children.Add(GetListBox());
            page.Content = grid;
            return page;
        }

        public override Label GetTitle()
        {
            Label label = new Bill_Profile_Title();
            return label;
        }

        public override ListBox GetListBox()
        {
            ListBox listBox = new BillActionDropDown();
            return listBox;
        }
    }
}
