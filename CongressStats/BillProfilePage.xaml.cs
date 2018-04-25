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
    /// Interaction logic for BillProfilePage.xaml
    /// </summary>
    public partial class BillProfilePage : Page, IProfilePage
    {
        public BillProfilePage()
        {
            InitializeComponent();
        }

        void IProfilePage.FormatListBox()
        {
            new BillActionDropDown(BillActions);
        }

        void IProfilePage.FormatTitle()
        {
            new Bill_Profile_Title(BillTitle);
        }

        void IProfilePage.FormatDescription()
        {
            new BillProfileDescription();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Popular_Bills());
        }

        private void BillActions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitializeComponent();
        }
    }
}

