using System.Text.RegularExpressions;

namespace PropertyLinkDemo.Models
{
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
