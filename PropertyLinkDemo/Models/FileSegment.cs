using System.Collections.Generic;

namespace PropertyLinkDemo.Models
{
    public class FileSegment
    {
        public FileSegment()
        {
            LineSegments = new List<LineSegment>();
        }

        public HeaderSegment HeaderSegment { get; set; }
        public IList<LineSegment> LineSegments { get; set; }
    }
}
