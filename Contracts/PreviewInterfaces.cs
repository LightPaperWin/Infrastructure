#region Using

using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace LightPaper.Infrastructure.Contracts
{
    public interface IPreviewDecorator
    {
        string Guid { get; }
        string Name { get; }
        string GroupName { get; }
        string Decorate(string body);
    }

    public interface IPreviewDecoratorProvider
    {
        IEnumerable<IPreviewDecorator> PreviewDecorators { get; }
    }

    public interface IPreview
    {
        Task ExecuteJavascriptAsync(string script);
        void UpdateHtml(string html);
        void LoadHtml(string htmlString);
    }
}