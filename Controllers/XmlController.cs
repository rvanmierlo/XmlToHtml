using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XmlToHtml.Models;

namespace XmlToHtml.Controllers
{
    public class XmlController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public XmlController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Test()
        {
            RapDocument model = new RapDocument("Resources/TestDocumentListInList.xml");
            return View(model);
        }
    }
}