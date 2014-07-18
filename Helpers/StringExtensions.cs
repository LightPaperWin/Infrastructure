#region usings

using LightPaper.ResourceSatellite.Properties;
using PuppyFramework.Helpers;

#endregion

namespace LightPaper.Infrastructure.Helpers
{
    public static class StringExtensions
    {
        public static string Localize(this string resourceKey)
        {
            resourceKey.EnsureParameterNotNull("resourceKey");
            return StringResources.ResourceManager.GetString(resourceKey) ?? resourceKey;
        }
    }
}