using LightShell.Messaging.Api;
using System.Windows.Input;

namespace LightShell.Api.Messages.Actions
{
   public class RegisterGlobalShortcutMessage : IMessage
   {
      public RegisterGlobalShortcutMessage(Key key, ModifierKeys modifiers, ICommand command)
      {
         Key = key;
         Modifiers=  modifiers;
         Command = command;
      }

      public ICommand Command { get; private set; }
      public ModifierKeys Modifiers { get; private set; }
      public Key Key { get; private set; }
   }
}
