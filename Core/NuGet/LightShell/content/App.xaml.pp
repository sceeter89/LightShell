﻿<Application x:Class="$rootnamespace$.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:$rootnamespace$"
             xmlns:system="clr-namespace:System;assembly=mscorlib"
             StartupUri="/LightShell;component/MainWindow.xaml">
   <Application.Resources>
      <ResourceDictionary>
         <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="/LightShell;component/Resources.xaml"/>
         </ResourceDictionary.MergedDictionaries>
         <BitmapImage x:Key="ApplicationLogo" UriSource="/Assets/Icons/ApplicationIcon.png"/>
         <system:String x:Key="ApplicationTitle">Sample Application</system:String>
      </ResourceDictionary>
   </Application.Resources>
</Application>
