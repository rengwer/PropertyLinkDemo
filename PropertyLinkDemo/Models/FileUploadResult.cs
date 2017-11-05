using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

    public class FileSegment
    {
        public FileSegment()
        {
            LineSegments = new List<LineSegment>();
        }

        public HeaderSegment HeaderSegment { get; set; }
        public IList<LineSegment> LineSegments { get; set; }
    }

    public class HeaderSegment : BaseSegment
    {
        public HeaderSegment(string text) : base(text) { }

        //example: [Data Instance] AT2285_Inspection.Inspect.Stitched Image - Data Instance  
        protected override void Parse(string text)
        {
            ParseProgramInformation(text);
        }
    }

    public class LineSegment : BaseSegment
    {
        public LineSegment(string text) : base(text) { }

        public string SourceProperty { get; set; }
        public string DestinationProperty { get; set; }
        public string PropertyDirection { get; set; }

        //example:  value <--- [Data Instance] AT2285_Logic.Start Inspection.Stitched Image - Data Instance:value 
        protected override void Parse(string text)
        {
            PropertyDirection = text.Contains("<---") ? "<---" : "--->";

            var properties = text.Split(PropertyDirection);
            SourceProperty = properties[0].Trim();

            properties = properties[1].Split(":");
            DestinationProperty = properties[1].Trim();
            ParseProgramInformation(properties[0]);

        }
    }

    public abstract class BaseSegment
    {
        public string Text { get; set; }
        public string DataType { get; set; }
        public string Program { get; set; }
        public string Task { get; set; }
        public string Tool { get; set; }

        protected const string _dataTypeRegexPattern = @"\[[^)]*\]";
        protected Regex _dataTypeRegex => new Regex(_dataTypeRegexPattern);

        protected BaseSegment(string text)
        {
            Text = text;
            Parse(text);
        }

        protected abstract void Parse(string text);

        protected string GetDataType(string text)
        {
            return _dataTypeRegex.Match(text).Value.Replace("[", "").Replace("]", "");
        }

        protected string RemoveDataTypeFromString(string text)
        {
            return _dataTypeRegex.Replace(text, "").Trim();
        }

        protected void ParseProgramInformation(string text)
        {
            var parts = RemoveDataTypeFromString(text).Trim().Split('.');
            Program = parts.Length >= 1 ? parts[0] : "";
            Task = parts.Length > 1 ? parts[1] : "";
            Tool = parts.Length > 2 ? parts[2] : "";
            DataType = GetDataType(text);
        }
    }
}
