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
    /// Interaction logic for CongressListing.xaml
    /// </summary>
    public partial class CongressListing : Page
    {


        public CongressListing()
        {
            InitializeComponent();

            CongressDataTableAdapters.CongressMembersTableAdapter adapter = new CongressDataTableAdapters.CongressMembersTableAdapter();
            CongressList.DataContext = adapter.GetData();
        }

        public CongressListing(string type)
        {
            InitializeComponent();


            CongressDataTableAdapters.CongressMembersTableAdapter adapter = new CongressDataTableAdapters.CongressMembersTableAdapter();

            switch (type)
            {
                case "representative":
                    CongressList.DataContext = adapter.GetRepresentativeData();
                    break;
                case "senator":
                    CongressList.DataContext = adapter.GetSenatorData();
                    break;
                default:
                    CongressList.DataContext = adapter.GetData();
                    break;
            }
        }

        private void CongressList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            this.NavigationService.Navigate(new MemberProfile());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new Congress_Navigation());
        }
    }
}
