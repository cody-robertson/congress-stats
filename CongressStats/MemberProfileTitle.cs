using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CongressStats
{
    class MemberProfileTitle
    {
        private Label title;

        public MemberProfileTitle(Label label)
        {
            title = label;
        }

        public Label Decorate(string text)
        {
            title.Content = text;
            return title;
        }
    }
}
