#region Using

using System.Collections.Generic;

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
}