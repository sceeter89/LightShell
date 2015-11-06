using LightShell.ViewModel;
using System.Linq;

namespace LightShell.Controls
{
   public partial class DockingArea
   {
      public DockingArea()
      {
         InitializeComponent();
      }

      private void PaneClosePreview(object sender, Telerik.Windows.Controls.Docking.StateChangeEventArgs e)
      {
         if (e == null || e.Panes == null || e.Panes.Any() == false || e.Panes.Count() > 0)
            return;

         (DataContext as DockingAreaViewModel).PaneCloseAttempt(e.Panes.First());
      }
   }
}
