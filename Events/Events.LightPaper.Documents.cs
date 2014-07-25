#region Using

using System.ComponentModel;
using LightPaper.Infrastructure.Contracts;
using Microsoft.Practices.Prism.PubSubEvents;

#endregion

namespace LightPaper.Infrastructure.Events
{
    public class SelectedDocumentChangedEvent : PubSubEvent<SelectedDocumentChangedEvent.Payload>
    {
        #region Nested type: Payload

        public class Payload
        {
            public Payload(IDocument oldSelection, IDocument newSelection)
            {
                OldSelection = oldSelection;
                NewSelection = newSelection;
            }

            public IDocument OldSelection { get; private set; }
            public IDocument NewSelection { get; private set; }
        }

        #endregion
    }

    public class SelectedDocumentWillChangeEvent : PubSubEvent<SelectedDocumentWillChangeEvent.Payload>
    {
        #region Nested type: Payload

        public class Payload
        {
            public Payload(IDocument currentDocument, CurrentChangingEventArgs eventArgs)
            {
                CurrentDocument = currentDocument;
                ChangingEventArgs = eventArgs;
            }

            public IDocument CurrentDocument { get; private set; }
            public CurrentChangingEventArgs ChangingEventArgs { get; private set; }
        }

        #endregion
    }

    public class DocumentWillCloseEvent : PubSubEvent<IDocument>
    {
    }

    public class DocumentClosedEvent : PubSubEvent<IDocument>
    {
    }

    public class DocumentAddedToWorkingCollectionEvent : PubSubEvent<IDocument>
    {
    }
}