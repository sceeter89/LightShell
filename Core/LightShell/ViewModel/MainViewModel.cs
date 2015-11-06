using System.Reflection;
using LightShell.Messaging.Api;
using LightShell.InternalMessages.UI;
using GalaSoft.MvvmLight.Threading;
using System.Windows.Input;

namespace LightShell.ViewModel
{
   internal class MainViewModel : GalaSoft.MvvmLight.ViewModelBase,
      ICoreViewModel,
      IHandleMessage<UpdateUiBootstrapMessage>,
      IHandleMessage<ApplicationLoadedMessage>
   {
      private readonly IMessageBus _messageBus;

      public MainViewModel(IMessageBus messageBus)
      {
         _messageBus = messageBus;
         _messageBus.Register(this);


         IsBusy = true;
         BusinessMessage = "Loading application...";
      }

      public string AppTitle
      {
         get
         {
            return string.Format("LightShell - {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString(3));
         }
      }
      
      public void Handle(UpdateUiBootstrapMessage message)
      {
         DispatcherHelper.CheckBeginInvokeOnUI(() => BusinessMessage = message.Message);
      }

      public void Handle(ApplicationLoadedMessage message)
      {
         DispatcherHelper.CheckBeginInvokeOnUI(() =>
         {
            IsBusy = false;
            BusinessMessage = "";
         });
      }

      public void OnControlInitialized()
      {
         _messageBus.Send(new ViewModelInitializedMessage(this.GetType()));
      }

      public bool IsBusy
      {
         get
         {
            return _isBusy;
         }
         set
         {
            _isBusy = value;
            RaisePropertyChanged();
         }
      }

      public string BusinessMessage
      {
         get
         {
            return _businessMessage;
         }
         set
         {
            _businessMessage = value;
            RaisePropertyChanged();
         }
      }
      private bool _isBusy;
      private string _businessMessage;

      public InputBindingCollection InputBindings { get; internal set; }
   }
}