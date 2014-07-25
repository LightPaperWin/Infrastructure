#region Using

using System;
using System.Windows.Documents;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using LightPaper.Infrastructure.Models;
using PuppyFramework.Helpers;
using SmartFormat;

#endregion

namespace LightPaper.Infrastructure.Helpers
{
    public static class TextEditorHelpers
    {
        public static void Select(this TextEditor editor, WordSegment segment)
        {
            editor.Select(segment.Offset, segment.Length);
        }

        public static WordSegment Insert(this TextEditor editor, string text)
        {
            editor.Document.BeginUpdate();
            var selection = editor.SelectedText;
            var selectedWordSegment = new WordSegment(editor.SelectionStart, editor.SelectionLength) {Text = selection};
            var newText = Smart.Format(text, new {selection = selection ?? string.Empty});
            editor.Document.Replace(editor.SelectionStart, editor.SelectionLength, newText);
            editor.Document.EndUpdate();
            return selectedWordSegment;
        }

        public static void TransformSelectionOrWord(this TextEditor editor, Func<string, string> transformer)
        {
            var wordSegment = WordSegmentAtCaret(editor);
            if (wordSegment == null) return;
            editor.Document.BeginUpdate();
            editor.Select(wordSegment);
            editor.SelectedText = transformer(wordSegment.Text);
            editor.Document.EndUpdate();
        }

        public static WordSegment WordSegmentAtCaret(this TextEditor editor)
        {
            if (editor.Document.TextLength == 0) return null;
            var nextCaretPosition = TextUtilities.GetNextCaretPosition(editor.Document, editor.CaretOffset, LogicalDirection.Forward, CaretPositioningMode.WordBorder);
            var prevCaretPosition = TextUtilities.GetNextCaretPosition(editor.Document, editor.CaretOffset, LogicalDirection.Backward, CaretPositioningMode.WordBorder);
            var segment = new WordSegment(prevCaretPosition, nextCaretPosition - prevCaretPosition);
            segment.Text = editor.Document.GetText(segment.Offset, segment.Length);
            return segment;
        }

        public static IDocumentLine TopVisibileLine(this TextEditor editor)
        {
            editor.EnsureParameterNotNull("editor");
            if (editor.Document == null)
            {
                return EmptyDocumentLine.Empty();
            }
            var textView = editor.TextArea.TextView;
            return textView.GetDocumentLineByVisualTop(textView.ScrollOffset.Y);
        }

        public static WordSegment PrependLineWith(this TextEditor editor, string prefix)
        {
            editor.Document.BeginUpdate();
            var selection = editor.SelectedText;
            var selectedWordSegment = new WordSegment(editor.SelectionStart, editor.SelectionLength) {Text = selection};
            var offset = editor.Document.GetOffset(editor.TextArea.Caret.Line, 1); // 1 = first column of this line
            editor.Document.Insert(offset, prefix);
            editor.Document.EndUpdate();
            return selectedWordSegment;
        }
    }
}