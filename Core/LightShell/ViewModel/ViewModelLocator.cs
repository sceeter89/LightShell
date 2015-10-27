using Autofac;
using System.Reflection;
using LightShell.Messaging;
using LightShell.Api;
using LightShell.Messaging.Api;
using GalaSoft.MvvmLight;

namespace LightShell.ViewModel
{
   internal class ViewModelLocator
   {
      public ViewModelLocator()
      {
         if (ViewModelBase.IsInDesignModeStatic)
            return;

         BuildIocContainer();
      }

      public MainViewModel Main
      {
         get
         {
            return IocContainer.Resolve<MainViewModel>();
         }
      }

      public LogViewModel Logging
      {
         get
         {
            return IocContainer.Resolve<LogViewModel>();
         }
      }

      public MenuBarViewModel MenuBar
      {
         get
         {
            return IocContainer.Resolve<MenuBarViewModel>();
         }
      }

      public static void Cleanup()
      {
         // TODO Clear the ViewModels
      }

      internal IContainer IocContainer { get; private set; }

      private void BuildIocContainer()
      {
         var builder = new ContainerBuilder();

         var clientAssembly = Assembly.Load("LightShell");

         var messageBus = new MessageBus();

         builder.Register(x => messageBus)
            .As<IMessageBus>()
            .SingleInstance();

         //Register ViewModels
         builder.RegisterAssemblyTypes(clientAssembly)
            .Where(t => t.Name.EndsWith("ViewModel"))
            .AsSelf()
            .SingleInstance();

         //Register and run background services
         builder.RegisterAssemblyTypes(clientAssembly)
            .InNamespace("LightShell.Service")
            .AsImplementedInterfaces()
            .AsSelf()
            .SingleInstance()
            .AutoActivate();

         IocContainer = builder.Build();
      }
   }
}