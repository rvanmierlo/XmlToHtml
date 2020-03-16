using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace XmlToHtml.Models
{
    public class ArticleViewModel
    {
        private RapDocument _document;
        private IEnumerable<SectionViewModel> _sections;
        public ArticleViewModel(RapDocument document)
        {
            _document = document;
        }
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public void Parse()
        {
            Title = _document.Document.Root.Element(RapDocument.Namespace + "title").Value;
            SubTitle = _document.Document.Root.Element(RapDocument.Namespace + "subtitle").Value;
        }

        public void ParseChildren()
        {
            _sections = _document.Document.Root.Elements(RapDocument.Namespace + "section").Select(item => new SectionViewModel(item)
            {
                SubTitle = item.Element(RapDocument.Namespace + "subtitle").Value
            }).ToList<SectionViewModel>();
        }

        public IEnumerable<SectionViewModel> Sections
        {
            get
            {
                return _sections;
            }
        }
    }
}
