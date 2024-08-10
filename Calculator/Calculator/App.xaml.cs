using System.Windows;

namespace calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // UnHandledExceptionを補足してMessageBox表示→アプリ終了

        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            base.OnStartup(e);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            try
            {
                Exception ex = (Exception)args.ExceptionObject;

                MessageBox.Show($"予期しないエラーが発生しました。\n{ex?.Message}");
            }
            finally
            {
                Application.Current.Shutdown();
            }
        }
    }

    
}
