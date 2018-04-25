using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressStats
{
    public interface IMemberProfilePage
    {
        void FormatTitle();
        void FormatDescription();
        void FormatBillsSponsored();
    }
}
