#region Using

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using PuppyFramework;
using MenuItem = PuppyFramework.MenuService.MenuItem;

#endregion

namespace LightPaper.Infrastructure.Contracts
{
    public interface ISidebarControl
    {
    }

    public interface IQuickOptionControl
    {
    }

    public interface IPreviewQuickOptionControl : IQuickOptionControl
    {
    }

    public interface IWorkingContentEditorsProvider
    {
        event EventHandler<SelectionChangedEventArgs> CollectionChangedEvent;
        T CurrentContentEditor<T>() where T : class;
        Task<IEnumerable<T>> AllContentEditors<T>() where T : class;
    }

    public interface IUserInteraction
    {
        Task<UserPromptResult> ConfirmSaveAsync(IDocument document);
        Task<string> PromptInputAsync(string title, string message = null);
        Task<UserPromptResult> PromptForConfirmation(string title, string message, bool canCancel = true);
    }

    public interface IDocumentExportProvider
    {
        IEnumerable<MenuItem> MenuItems { get; }
    }
}