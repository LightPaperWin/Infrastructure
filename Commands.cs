#region Using

using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;
using LightPaper.ResourceSatellite.Properties;

#endregion

namespace LightPaper.Infrastructure
{
    public class HeaderCommand : RoutedUICommand
    {
        public HeaderCommand(string text, string name, Type ownerType, InputGestureCollection gestures, Key key) : base(text, name, ownerType, gestures)
        {
            Key = key;
        }

        public Key Key { get; private set; }
    }

    public class Commands : PuppyFramework.UI.Commands
    {
        #region Methods

        public static void FixCommands()
        {
            ApplicationCommands.Close.InputGestures.Add(new KeyGesture(Key.W, ModifierKeys.Control, "Ctrl+W"));
            EditingCommands.ToggleBold.InputGestures.Add(new KeyGesture(Key.B, ModifierKeys.Control, "Ctrl+B"));
            EditingCommands.ToggleItalic.InputGestures.Add(new KeyGesture(Key.L, ModifierKeys.Control, "Ctrl+I"));
            EditingCommands.ToggleBold.Text = StringResources._bold;
            EditingCommands.ToggleItalic.Text = StringResources._italic;
        }

        #endregion

        #region Edit Commands

        public class Edit
        {
            static Edit()
            {
                PasteAsLinkCommand = new RoutedUICommand(StringResources._pasteAsLink, "PasteAsLink", typeof (Commands));
                PasteAsImageCommand = new RoutedUICommand(StringResources._pasteAsImage, "PasteAsImage", typeof (Commands));
            }

            public static RoutedUICommand PasteAsLinkCommand { get; private set; }
            public static RoutedUICommand PasteAsImageCommand { get; private set; }
        }

        #endregion

        #region Format Commands

        public class Format
        {
            #region Properties

            public static RoutedUICommand InlineCodeCommand { get; private set; }
            public static RoutedUICommand BlockquoteCommand { get; private set; }
            public static RoutedUICommand LinkCommand { get; private set; }
            public static RoutedUICommand ImageCommand { get; private set; }

            public static IList<HeaderCommand> HeaderCommands { get; private set; }

            #endregion

            #region Constructors

            static Format()
            {
                FixCommands();
                var inlineCodeGestures = new InputGestureCollection
                {
                    new KeyGesture(Key.K, ModifierKeys.Control, "Ctrl+K")
                };
                InlineCodeCommand = new RoutedUICommand(StringResources._inlineCode, "InlineCode", typeof (Commands), inlineCodeGestures);

                var blockquoteGestures = new InputGestureCollection
                {
                    new KeyGesture(Key.K, ModifierKeys.Control | ModifierKeys.Alt, "Ctrl+Alt+K")
                };
                BlockquoteCommand = new RoutedUICommand(StringResources._blockquote, "Blockquote", typeof (Commands), blockquoteGestures);

                var linkGestures = new InputGestureCollection
                {
                    new KeyGesture(Key.L, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+L")
                };
                LinkCommand = new RoutedUICommand(StringResources._link, "Link", typeof (Commands), linkGestures);

                var imageGestures = new InputGestureCollection
                {
                    new KeyGesture(Key.I, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+I")
                };
                ImageCommand = new RoutedUICommand(StringResources._image, "Image", typeof (Commands), imageGestures);
                AddHeaderCommands();
            }

            private static void AddHeaderCommands()
            {
                var keys = new[] {Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6};
                HeaderCommands = new HeaderCommand[keys.Length];
                for (var i = 1; i <= keys.Length; i++)
                {
                    var key = keys[i - 1];
                    var gestures = new InputGestureCollection
                    {
                        new KeyGesture(key, ModifierKeys.Control, "Ctrl+" + i)
                    };
                    HeaderCommands[i - 1] = new HeaderCommand("H" + i, "H" + i, typeof (Commands), gestures, key);
                }
            }

            #endregion
        }

        #endregion

        #region IO Commands

        public class IO
        {
            #region Properties

            public static RoutedUICommand SaveAllCommand { get; private set; }
            public static RoutedUICommand ExportAsHtmlCommand { get; private set; }

            #endregion

            #region Constructors

            static IO()
            {
                var saveAllGestures = new InputGestureCollection
                {
                    new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+S")
                };
                SaveAllCommand = new RoutedUICommand(StringResources._saveAll, "SaveAll", typeof (Commands), saveAllGestures);
                ExportAsHtmlCommand = new RoutedUICommand(StringResources._exportAsHtml, "ExportAsHtml", typeof (Commands));
            }

            #endregion
        }

        #endregion

        #region Windows Commands

        public class Windows
        {
            #region Properties

            public static RoutedUICommand TogglePreviewCommand { get; private set; }
            public static RoutedUICommand ToggleSidebarCommand { get; private set; }
            public static RoutedUICommand ToggleQuickOptionsCommand { get; private set; }

            #endregion

            #region Constructos

            static Windows()
            {
                var togglePreviewGestures = new InputGestureCollection
                {
                    new KeyGesture(Key.OemCloseBrackets, ModifierKeys.Control | ModifierKeys.Alt, "Ctrl+Alt+]")
                };
                TogglePreviewCommand = new RoutedUICommand(StringResources._togglePreview, "TogglePreview", typeof (Commands), togglePreviewGestures);

                var toggleSidebarGestures = new InputGestureCollection
                {
                    new KeyGesture(Key.OemOpenBrackets, ModifierKeys.Control | ModifierKeys.Alt, "Ctrl+Alt+[")
                };
                ToggleSidebarCommand = new RoutedUICommand(StringResources._toggleSidebar, "ToggleSidebar", typeof (Commands), toggleSidebarGestures);

                var toggleQuickOptionsGestures = new InputGestureCollection
                {
                    new KeyGesture(Key.OemComma, ModifierKeys.Control, "Ctrl+,")
                };
                ToggleQuickOptionsCommand = new RoutedUICommand(StringResources._toggleQuickOptions, "ToggleQuickOptions", typeof (Commands), toggleQuickOptionsGestures);
            }

            #endregion
        }

        #endregion
    }
}