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
        string firstName;
        string lastName;
        string party;
        string state;
        string memberType;
        int district;
        int memberID;

        public MemberProfile()
        {
            InitializeComponent();
        }

        public MemberProfile(int index)
        {
            InitializeComponent();


        }

        void IProfilePage.FormatListBox()
        {
            BillsSponsoredDropDown decorator = new BillsSponsoredDropDown(MembersList);
            decorator.Decorate(memberID);
        }

        void IProfilePage.FormatTitle()
        {
            MemberProfileTitle decorator = new MemberProfileTitle(MemberTitle);

            string title = firstName + " " + lastName + " (" + state + "-" + party + ")";
            decorator.Decorate(title);
        }

        void IProfilePage.FormatDescription()
        {
            MemberProfileDescription decorator = new MemberProfileDescription(MemberDescription);

            string description = "";
            if (memberType == "representative")
            {
                description = firstName + " " + lastName + " represents " + state + " district number " + district + ".";
            }
            else
            {
                description = firstName + " " + lastName + " is a senator representing the state of " + state + ".";
            }
            
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
