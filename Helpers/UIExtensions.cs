#region Using

using System.Windows;
using System.Windows.Media;

#endregion

namespace LightPaper.Infrastructure.Helpers
{
    public static class UIExtensions
    {
        public static T FindVisualChild<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var validChild = child as T;
                if (validChild != null)
                {
                    return validChild;
                }

                var childItem = FindVisualChild<T>(child);
                if (childItem != null) return childItem;
            }
            return null;
        }
    }
}