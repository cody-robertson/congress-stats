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
using System.Xml.Serialization;

namespace CongressStats.Deserialization.Bill
{
    [XmlRoot(ElementName = "bill", Namespace = "")]
    class Bill
    {
        // define fields from xml

        [XmlElementAttribute("congress")]
        public uint congressNumber;

        [XmlElementAttribute("billtype")]
        public string billType;

        [XmlElementAttribute("originchamber")]
        public string originChamber;

        [XmlElementAttribute("billnumber")]
        public uint billNumber;

        //notes

        //cbocostestimates

        [XmlElementAttribute("version")]
        public string version;

        //recorded votes

        // billsummaries array of items

        // subjects -> billsubjects -> legislativesubjects (array of items) and policityarea -> string name

        [XmlElementAttribute("introducedDate")]
        public string introducedDate;

        
        // actions array of items
        [XmlElementAttribute("actions")]
        public BillAction billAction;

        // titles (array of items)
        //[XmlElementAttribute("titles")]
        //BillTitles billTitles;

        // cosponsors (array of items)

        // laws

        // calendarnumbers

        // committeereports

        // latestaction -> links, text, actiondate

        [XmlElementAttribute("title")]
        public string billTitle;

        [XmlElementAttribute("createdate")]
        public string createDate;

        // sponsors (array of items)

        [XmlElementAttribute("updatedate")]
        public string updateDate;

        // relatedbills (array of items)

        // committees -> billcommittees (array of items)

        // policyarea -> string name

        //amendments
    }
}
