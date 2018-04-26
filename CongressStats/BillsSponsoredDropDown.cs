using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CongressStats
{
    class BillsSponsoredDropDown
    {
        ListBox billsSponsored;

        public BillsSponsoredDropDown(ListBox listBox)
        {
            billsSponsored = listBox;
        }

        public ListBox Decorate(int index)
        {
            // add data
            return billsSponsored;
        }
    }
}
