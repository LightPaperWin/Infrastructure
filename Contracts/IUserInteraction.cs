#region usings

using System.Threading.Tasks;
using PuppyFramework;

#endregion

namespace LightPaper.Infrastructure.Contracts
{
    public interface IUserInteraction
    {
        Task<UserPromptResult> ConfirmSaveAsync(IDocument document);
        Task<string> PromptInputAsync(string title, string message = null);
    }
}