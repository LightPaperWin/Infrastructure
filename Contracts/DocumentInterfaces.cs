#region Using

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

#endregion

namespace LightPaper.Infrastructure.Contracts
{
    public interface IDocumentUpdateListener
    {
        bool Listen(IDocument document, string sourceText = null);
    }

    public interface IDocument : INotifyPropertyChanged
    {
        #region Properties

        string Title { get; }
        bool IsDirty { get; }
        bool IsTransient { get; set; }
        string SourcePath { get; }

        void Save(string filename);

        #endregion
    }

    public interface IDocumentCloseConfirmer
    {
        Task<bool?> DocumentShouldCloseAsync(IDocument document);
        Task<bool?> DocumentsShouldCloseAsync(IEnumerable<IDocument> documents);
    }

    public interface IDocumentsManager
    {
        ObservableCollection<IDocument> WorkingDocuments { get; }
        IDocument CurrentDocument { get; }
        bool Add(IDocument document, bool doSelect = false);
        Task CloseCurrentAsync();
        Task CloseAsync(IDocument document);
        void SaveAllWorkingDocuments();
        void PruneTransientDocuments();
    }
}