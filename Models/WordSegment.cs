#region Using

using ICSharpCode.AvalonEdit.Document;

#endregion

namespace LightPaper.Infrastructure.Models
{
    public class WordSegment : ISegment
    {
        #region Constructors 

        public WordSegment(int offset, int length)
        {
            Offset = offset;
            Length = length;
            EndOffset = offset + length;
        }

        #endregion

        #region Properties 

        public string Text { get; set; }
        public int Offset { get; private set; }
        public int Length { get; private set; }
        public int EndOffset { get; private set; }

        #endregion
    }
}