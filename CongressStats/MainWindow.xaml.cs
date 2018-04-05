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
using System.Xml;
using System.Xml.Linq;

namespace CongressStats
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            /*
            XmlReader r = XmlReader.Create("../../BILLSTATUS/115/s/BILLSTATUS-115s1.xml");
            while (r.NodeType != XmlNodeType.Element)
                r.Read();
            XElement e = XElement.Load(r);
            Console.WriteLine(e);
            */

            ParseBillData();

            InitializeComponent();
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new HomePage());
        }

        private void ParseBillData()
        {
            XDocument doc = XDocument.Load("../../BILLSTATUS/115/s/BILLSTATUS-115s999.xml");
            
            var bill = doc.Descendants("bill");
            foreach (var item in bill.DescendantNodes())
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
