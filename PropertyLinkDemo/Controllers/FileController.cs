using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyLinkDemo.Models;
using System.IO;
using PropertyLinkDemo.Parsers;

namespace PropertyLinkDemo.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        [HttpPost()]
        public FileUploadResult Post()
        {
            var text = "";
            using (var sr = new StreamReader(HttpContext.Request.Body))
                text = sr.ReadToEnd();

            var parser = new TextParser(
                text, 
                new TextParserOptions {
                    IgnoreBlankLines = true,
                    IgnoreHeaderLine = true });

            return parser.Parse();
        }
    }

    
}