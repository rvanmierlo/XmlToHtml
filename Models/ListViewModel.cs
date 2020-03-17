using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlToHtml.Models
{
    public class ListViewModel
    {
        private XElement _element;

        private IEnumerable<ListItemViewModel> _listItems;

        public ListViewModel(XElement element)
        {
            _element = element;
        }

        public IEnumerable<ListItemViewModel> ListItems
        {
            get { return _listItems; }
        }

        public void ParseChildren()
        {
            // var listItems = new List<ListItemViewModel>();
            // foreach (var item in _element.Elements(RapDocument.Namespace + "listitem"))
            // {
            //     ParseElement(item.Element(RapDocument.Namespace + "para"), listItems);
            // }
            // _listItems = listItems;
            _listItems = _element.Elements(RapDocument.Namespace + "listitem").Select(item => item.Element(RapDocument.Namespace + "para")).Select(item => new ListItemViewModel(item)
            {
                Paragraph = item.HasElements ? null : item.Value
            }).ToList<ListItemViewModel>();
        }

        public void ParseElement(XElement element, List<ListItemViewModel> listItems)
        {
            if (element.HasElements)
            {
                foreach (var childElement in element.Elements())
                {
                    ParseElement(childElement, listItems);
                }
            }
            else
            {
                ListItemViewModel listItemViewModel = new ListItemViewModel(element);
                listItemViewModel.Paragraph = element.Value;
                listItems.Add(listItemViewModel);
            }
        }

    }

}
