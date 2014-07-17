#region usings

using System.Threading.Tasks;
using PuppyFramework;

#endregion

namespace LightPaper.Infrastructure.Contracts
{
    public interface IUserConfirmer
    {
        Task<UserPromptResult> ConfirmSaveAsync(IDocument document);
    }
}