using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CongressStats
{
    class MemberProfileDescription
    {
        private Label description;

        public MemberProfileDescription(Label label)
        {
            description = label;
        }

        public Label Decorate(string text)
        {
            description.Content = text;
            return description;
        }
    }
}
