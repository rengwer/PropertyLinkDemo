using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyLinkDemo.Models;
using System.IO;

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

            return new FileUploadResult();


            //        List<IFormFile> files = new List<IFormFile>();
            //    var fileText = "";
            //    foreach (var formFile in files)
            //    {
            //        if (formFile.Length > 0)
            //        {
            //            using (var streamReader = new StreamReader(formFile.OpenReadStream()))
            //            {
            //                fileText = streamReader.ReadToEnd();
            //            }
            //        }
            //    }

            //    return new FileUploadResult();
            //}
        }
    }

    
}