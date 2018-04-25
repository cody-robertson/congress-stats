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
    /// Interaction logic for MemberProfile.xaml
    /// </summary>
    public partial class MemberProfile : Page, IProfilePage
    {
        public MemberProfile()
        {
            InitializeComponent();
        }
        void IProfilePage.FormatListBox()
        {
            new BillsSponsoredDropDown(MembersList);
        }

        void IProfilePage.FormatTitle()
        {
            new MemberProfileTitle();
        }

        void IProfilePage.FormatDescription()
        {
            new MemberProfileDescription();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Popular_Bills());
        }

        public void GetBillsSponsored()
        {
            new BillsSponsoredDropDown(MembersList);
        }
    }
}
