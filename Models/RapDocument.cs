using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace XmlToHtml.Models
{
    public class RapDocument
    {
        public static readonly XNamespace Namespace = "http://ijk.nl/ns/rapbook";
        private XDocument _document;
        private ArticleViewModel _article;

        public RapDocument(string documentPath)
        {
            _document = XDocument.Load(documentPath);
            _article = new ArticleViewModel(this);
        }

        public XDocument Document
        {
            get
            {
                return _document;
            }
        }

        public ArticleViewModel Article
        {
            get
            {
                return _article;
            }
        }
       
    }
}