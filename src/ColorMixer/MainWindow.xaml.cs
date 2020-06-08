// Copyright 2015 Sergey Masyura. All rights reserved.

using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace ColorMixer
{
    /// <summary>
    /// Main window of the application.
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand ExitCommand = new RoutedCommand();
        public static RoutedCommand AboutCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Title = string.Format("{0} {1}.{2}", Title, version.Major, version.Minor);
        }

        private void ExecutedExit(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown(110);
        }

        private void CanExecuteExit(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void ExecutedAbout(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Color Mixer.\nThe simple tool to mix colors.\n\nCopyright 2015 Sergey Masyura. All rights reserved.",
                            "About Color Mixer", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CanExecuteAbout(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }
    }
}
