# Deprecated

Project is here only as a reference, and is abandoned.

# LightShell

LightShell is a simple shell that let's you create GUI application by focusing only on your business, not on technical details of plugin system or dependency resolution.

## Getting started
### Create entrypoint assembly
To create empty application powered by LightShell simply create empty WPF application called *SampleApp* targeting .NET 4.5.2, then install `LightShell` package from NuGet:
```powershell
Install-Package LightShell
```
Once you run your project you will see empty application window.

### Create plugin
To create your first LightShell Plugin create empty _WPF User Control Library_ project called *MyFirstPlugin* and install into it LightShell Plugin API package:
```powershell
Install-Package LightShell.PluginApi
```

:information_source: Make sure you add reference to *MyFirstPlugin* in *SampleApp* project to be sure that always most recent version of plugin is copied to LightShell plugin system search dir. Otherwise you will have to manually copy plugin DLL to *SampleApp* output directory.

:warning: If you add some custom assemblies to your plugin project, they won't automatically be copied to *SampleApp* output, so please reference them as well in *SampleApp* project.

All we have to do is to create new class called `MyPluginDefinition` and do two things:
- Make it implement interface `ILightShellPlugin` available in namespace `LightShell.Api.Plugins`
- Export it using MEF attribute: `[Export(typeof(ILightShellPlugin))]` (to do that you will need to reference .NET assembly: `System.ComponentModel.Composition`, so we start with definition as follows:

```csharp
   [Export(typeof(ILightShellPlugin))]
   public class MyPlugin : ILightShellPlugin
   {
      public string PluginName
      {
         get
         {
            return "MyPlugin";
         }
      }

      public IEnumerable<MenuEntryDescriptor> GetMenuEntries()
      {
         yield break;
      }

      public IEnumerable<IMicroservice> GetMicroservices()
      {
         yield break;
      }
   }
```
