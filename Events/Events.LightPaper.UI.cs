#region Using

using LightPaper.Infrastructure.Contracts;
using Microsoft.Practices.Prism.PubSubEvents;

#endregion

namespace LightPaper.Infrastructure.Events
{
    public class PreviewDecoratorChangedEvent : PubSubEvent<IPreviewDecorator>
    {
    }
}