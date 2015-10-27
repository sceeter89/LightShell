param($installPath, $toolsPath, $package, $project)
$item = $project.ProjectItems | where-object {$_.Name -eq "App.xaml"}
$item.Properties.Item("ItemType").Value = "ApplicationDefinition"
