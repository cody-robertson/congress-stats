/**
 * File: BillParser.cs
 * Description: Class definition to automate parsing bills from xml files
 * Author: Cody Robertson
 * Date: 3/29/18
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CongressStats.Deserialization.Bill
{
    class BillParser
    {
        [XmlArrayItem(typeof(Bill))]
        Bill[] bills;
    }
}
