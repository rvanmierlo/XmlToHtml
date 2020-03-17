using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlToHtml.Models
{
    public class ListItemViewModel
    {
        private XElement _element;

        public ListItemViewModel(XElement element)
        {
            _element = element;
        }
        public string Paragraph { get; set; }

        public IEnumerable<ListViewModel> Lists { get; set; }        

        public void ParseChildren()
        {
            Lists = _element.Elements().Where(item => item.Name == RapDocument.Namespace + "itemizedlist" || item.Name == RapDocument.Namespace + "orderedlist").Select(item => new ListViewModel(item)).ToList<ListViewModel>();
        }
    }

}
