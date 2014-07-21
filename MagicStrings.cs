namespace LightPaper.Infrastructure
{
    public class MagicStrings
    {
        #region LoggerTags

        public static class LoggerTags
        {
            public static readonly string LP_VIEW_MODEL = "LightPaper ViewModel";
            public static readonly string LP_UI = "LightPaper UI";
            public static readonly string LP_BOOTSTRAPPER = "LightPaper Bootstrapper";
        }

        #endregion

        #region MarkdownTags

        public static class MarkdownTags
        {
            public static readonly string BOLD = "**{selection}**";
            public static readonly string ITALIC = "*{selection}*";
            public static readonly string INLINE_CODE = "`{selection}`";
            public static readonly char HEADER = '#';
            public static readonly string BLOCKQUOTE = "> ";
            public static readonly string LINK = "[{selection}](http://)";
            public static readonly string PASTE_URL_AS_LINK = "[{{selection}}]({0})";
            public static readonly string PASTE_TEXT_AS_LINK = "[{{selection}}{0}](http://)";
            public static readonly string PASTE_URL_AS_IMAGE = "![{{selection}}]({0})";
            public static readonly string PASTE_TEXT_AS_IMAGE = "![{{selection}}{0}](http://)";
            public static readonly string IMAGE = "![{selection}](http://)";
        }

        #endregion

        #region RegionNames

        public static class RegionNames
        {
            public static readonly string MAIN_CONTENT_REGION = "LPMainContentRegion";
            public static readonly string LEFT_SIDEBAR_REGION = "LPLeftSidebarRegion";
            public static readonly string LEFT_SIDEBAR_CONTENT_REGION = "LPLeftSidebarContentRegion";
            public static readonly string RIGHT_SIDEBAR_REGION = "LPRightSidebarRegion";
            public static readonly string MAIN_DOCUMENT_CONTENT_REGION = "LPMainDocumentContentRegion";
            public static readonly string MAIN_PREVIEW_CONTENT_REGION = "LPMainPreviewContentRegion";
            public static readonly string SECONDARY_MENU_CONTENT_REGION = "LPSecondaryMenuContentRegion";
            public static readonly string QUICK_OPTIONS_CONTENT_REGION = "LPQuickOptionsContentRegion";
        }

        #endregion

        #region SettingsKey

        public static class SettingsKey
        {
            public static readonly string PREVIEW_DECORATOR_GUID = "_previewTheme";
        }

        #endregion

        #region PathNames

        public static class PathNames
        {
            public static readonly string APP_FOLDER_NAME = "LightPaper";
            public static readonly string PLUGINS_FOLDER_NAME = "Plugins";
            public static readonly string MODULES_FOLDER_NAME = "Modules";
        }

        #endregion

        #region ExportContractNames

        public static class ExportContractNames
        {
            public const string DEFAULT_SESSION_MANAGER = "DefaultSessionManager";
            public const string MARKDOWN_DOCUMENT_FACTORY = "MarkdownDocumentFactory";
        }

        #endregion
    }
}