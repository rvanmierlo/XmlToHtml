using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;


namespace XmlToHtml.Models
{
    public class SectionViewModel
    {
        private XElement _element;

        private IEnumerable<ListViewModel> _lists;

        public SectionViewModel(XElement element)
        {
            _element = element;
        }
        public string SubTitle { get; set; }

        public IEnumerable<ListViewModel> Lists
        {
            get { return _lists; }
        }

        public void ParseChildren()
        {
            _lists = _element.Descendants(RapDocument.Namespace + "listitem").Select(item => new ListViewModel(item)
            {
                Content = item.Element(RapDocument.Namespace + "para").Value
            }).ToList<ListViewModel>();
        }

    }
}
