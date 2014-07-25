#region Using

using ICSharpCode.AvalonEdit.Document;

#endregion

namespace LightPaper.Infrastructure.Models
{
    public class EmptyDocumentLine : IDocumentLine
    {
        #region Fields

        private static EmptyDocumentLine _emptyDocumentLine;

        #endregion

        #region Properties

        public int Offset { get; private set; }
        public int Length { get; private set; }
        public int EndOffset { get; private set; }
        public int TotalLength { get; private set; }
        public int DelimiterLength { get; private set; }
        public int LineNumber { get; private set; }
        public IDocumentLine PreviousLine { get; private set; }
        public IDocumentLine NextLine { get; private set; }
        public bool IsDeleted { get; private set; }

        #endregion

        #region Methods 

        public static EmptyDocumentLine Empty()
        {
            return _emptyDocumentLine ?? (_emptyDocumentLine = new EmptyDocumentLine());
        }

        #endregion
    }
}