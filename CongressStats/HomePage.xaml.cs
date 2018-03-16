using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CongressStats
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Mem_Of_Congress_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Congress_Navigation());
        }

        private void Popular_Bills_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Popular_Bills()); 
        }
    }
}
