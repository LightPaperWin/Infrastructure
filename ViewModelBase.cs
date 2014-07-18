#region Usings

using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Mvvm;
using PuppyFramework.Interfaces;

#endregion

namespace LightPaper.Infrastructure
{
    public abstract class ViewModelBase : BindableBase
    {
        #region Fields

        protected readonly ILogger _logger;

        #endregion

        #region Constructors

        protected ViewModelBase(ILogger logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        protected virtual void Log(string message, Category category = Category.Info, params object[] propertyValues)
        {
            _logger.Log(message, category, MagicStrings.LoggerTags.LP_VIEW_MODEL, propertyValues);
        }

        protected virtual void LogDispose()
        {
            Log("Disposed {Type:l}", Category.Info, GetType().FullName);
        }

        protected virtual void LogInit()
        {
            Log("Initialized {Type:l}", Category.Info, GetType().FullName);
        }

        #endregion
    }
}
