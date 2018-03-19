using System;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ProjectAram.Helpers
{
    public static class DialogController
    {
        private static MetroWindow GetMetroWindow()
        {
            if (!(Application.Current.MainWindow is MetroWindow window))
                throw new InvalidOperationException("Main window must be a MetroWindow");
            return window;
        }

        public static Task<MessageDialogResult> ShowMessageAsync(string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative)
        {
            var window = GetMetroWindow();
            return window.ShowMessageAsync(title, message, style);
        }

        public static Task<LoginDialogData> ShowLoginPasswordDialog(string title, string message, string buttonText)
        {
            var window = GetMetroWindow();
            return window.ShowLoginAsync(title, message, new LoginDialogSettings
            {
                ColorScheme = window.MetroDialogOptions.ColorScheme,
                EnablePasswordPreview = true,
                AffirmativeButtonText = buttonText
            });
        }

    }
}