// Copyright 2015 Sergey Masyura. All rights reserved.

using System.Windows;
using System.Windows.Threading;

namespace ColorMixer
{
    /// <summary>
    /// Application.
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString());

            e.Handled = true;
        }
    }
}
