#region Using

using System.Collections.Generic;
using System.Linq;
using LightPaper.Infrastructure.Contracts;

#endregion

namespace LightPaper.Infrastructure.Helpers
{
    public static class DocumentExtensions
    {
        public static IEnumerable<string> FilterValidPaths(this IEnumerable<IDocument> documents)
        {
            return documents.Select(d => d.SourcePath).Where(p => !string.IsNullOrWhiteSpace(p));
        }
    }
}