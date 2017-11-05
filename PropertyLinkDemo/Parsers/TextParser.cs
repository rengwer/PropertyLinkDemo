using PropertyLinkDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyLinkDemo.Parsers
{
    public class TextParser
    {
        private string Text { get; set; }
        private TextParserOptions Options { get; set; }

        public TextParser(string text, TextParserOptions options)
        {
            Text = text;
            Options = options;
        }

        public FileUploadResult Parse()
        {
            var lines = Text.Split(Environment.NewLine);

            if (lines.Length == 0) return new FileUploadResult();
            if (Options.IgnoreHeaderLine) lines = lines.TakeLast(lines.Length - 1).ToArray();

            var fileSegments = new List<FileSegment>();
            FileSegment currentSegment = null;

            foreach (var line in lines)
            {
                if (Options.IgnoreBlankLines && String.IsNullOrWhiteSpace(line))
                    continue;

                var trimmedLine = line.Trim(' ', '\t');

                if (trimmedLine.StartsWith('['))
                {
                    if (currentSegment != null) fileSegments.Add(currentSegment);

                    currentSegment = new FileSegment { HeaderSegment = new HeaderSegment(trimmedLine) };
                }
                else
                {
                     currentSegment.LineSegments.Add(new LineSegment (trimmedLine));
                }
            }

            if (currentSegment != null) fileSegments.Add(currentSegment);

            return new FileUploadResult { FileSegments = fileSegments };
        }

    }
}
