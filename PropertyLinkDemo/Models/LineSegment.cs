namespace PropertyLinkDemo.Models
{
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
}
