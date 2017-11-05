namespace PropertyLinkDemo.Models
{
    public class HeaderSegment : BaseSegment
    {
        public HeaderSegment(string text) : base(text) { }

        //example: [Data Instance] AT2285_Inspection.Inspect.Stitched Image - Data Instance  
        protected override void Parse(string text)
        {
            ParseProgramInformation(text);
        }
    }
}
