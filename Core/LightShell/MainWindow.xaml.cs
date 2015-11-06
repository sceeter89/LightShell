using System.Windows;
using Telerik.Windows.Controls;
using LightShell.ViewModel;
using GalaSoft.MvvmLight.Threading;

namespace LightShell
{
   public partial class MainWindow
   {
      static MainWindow()
      {
         DispatcherHelper.Initialize();
      }

      public MainWindow()
      {
         StyleManager.ApplicationTheme = new Windows8Theme();
         InitializeComponent();
         Loaded += OnMainWindowLoaded;

         (DataContext as MainViewModel).InputBindings = this.InputBindings;
      }

      private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
      {
         (DataContext as ICoreViewModel).OnControlInitialized();
      }
   }
}
