using ICSharpCode.AvalonEdit.Document;

namespace LightPaper.Infrastructure.Models
{
    public class WordSegment : ISegment
    {
        public WordSegment(int offset, int length)
        {
            Offset = offset;
            Length = length;
            EndOffset = offset + length;
        }

        public string Text { get; set; }

        public int Offset { get; private set; }
        public int Length { get; private set; }
        public int EndOffset { get; private set; }
    }
}