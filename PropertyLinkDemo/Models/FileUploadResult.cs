using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyLinkDemo.Models
{
    public class FileUploadResult
    {
        public IList<FileSegment> FileSegments { get; set; }
    }

    public class FileSegment
    {
        public HeaderSegment HeaderSegment { get; set; }
        public IList<LineSegment> LineSegments { get; set; }
    }

    public class HeaderSegment
    {
        public string Text { get; set; }
    }

    public class LineSegment
    {
        public string Text { get; set; }
    }
}
