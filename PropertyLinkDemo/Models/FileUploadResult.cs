using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyLinkDemo.Models
{
    public class FileUploadResult
    {
        public FileUploadResult()
        {
            FileSegments = new List<FileSegment>();
        }

        public FileUploadResult(IList<FileSegment> segments)
        {
            FileSegments = segments;
        }

        public IList<FileSegment> FileSegments { get; set; }

        public IList<KeyValuePair<string, int>> ProgramCounts => 
            FileSegments.SelectMany(s => s
                .LineSegments
                .Select(ls => ls.Program)
                .Append(s.HeaderSegment.Program))
            .GroupBy(p => p)
            .Select(p => new KeyValuePair<string, int>(p.Key, p.Count())).ToList();

    }
}
