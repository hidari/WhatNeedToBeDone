using System;
using System.Windows;
using System.Diagnostics;
using System.IO;
using Hidari0415.WhatNeedToBeDone.Models;
using Hidari0415.WhatNeedToBeDone.ViewModels;
using Hidari0415.WhatNeedToBeDone.Views;

namespace Hidari0415.WhatNeedToBeDone
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        public static ProductInfo ProductInfo { get; private set; }
        public static MainWindowViewModel ViewModelRoot { get; private set; }

        static App()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>  ReportException(sender, args.ExceptionObject as Exception);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.DispatcherUnhandledException += (sender, args) => ReportException(sender, args.Exception);

            ProductInfo = new ProductInfo();

            ViewModelRoot = new MainWindowViewModel();
            this.MainWindow = new MainWindow { DataContext = ViewModelRoot };
            this.MainWindow.Show();
        }

        private static void ReportException(object sender, Exception exception)
        {
            const string messageFormat = @"
===========================================
ERROR, date {0}, sender = {1},
{2}
";
            const string path = "error.log";

            try
            {
                var message = string.Format(messageFormat, DateTimeOffset.Now, sender, exception);
                Debug.WriteLine(message);
                File.AppendAllText(path, message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
