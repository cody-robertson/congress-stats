/**
 * File: Bill.cs
 * Description: Class definition for deserializing bill object from congress xml files
 * Author: Cody Robertson
 * Date: 3/29/18
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressStats.Deserialization.Bill
{
    [XmlRoot(ElementName = "bill", Namespace = "")]
    class Bill
    {
        // define fields from xml

        [XmlElementAttribute("introducedDate")]
        public string introducedDate;

        [XmlElementAttribute("congress")]
        public uint congressNumber;

        [XmlElementAttribute("actions")]
        public BillAction billAction;


    }
}
