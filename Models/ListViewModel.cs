using System;
using System.Xml.Linq;

namespace XmlToHtml.Models
{
    public class ListViewModel
    {
        private XElement _element;
        public ListViewModel(XElement element)
        {
            _element = element;
        }
        public string Content { get; set; }
    }

}
