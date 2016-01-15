# Cake.Topshelf
Cake Build addon for managing Topshelf windows services

[![Build status](https://ci.appveyor.com/api/projects/status/smmki80m1s7yi7xe?svg=true)](https://ci.appveyor.com/project/SharpeRAD/cake-topshelf)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)



## Table of contents

1. [Implemented functionality](https://github.com/SharpeRAD/Cake.Topshelf#implemented-functionality)
2. [Referencing](https://github.com/SharpeRAD/Cake.Topshelf#referencing)
3. [Usage](https://github.com/SharpeRAD/Cake.Topshelf#usage)
4. [Example](https://github.com/SharpeRAD/Cake.Topshelf#example)
5. [License](https://github.com/SharpeRAD/Cake.Topshelf#license)
6. [Share the love](https://github.com/SharpeRAD/Cake.Topshelf#share-the-love)



## Implemented functionality

* Install
* Uninstall
* Start
* Stop



## Referencing

[![NuGet Version](http://img.shields.io/nuget/v/Cake.Topshelf.svg?style=flat)](https://www.nuget.org/packages/Cake.Topshelf/) [![NuGet Downloads](http://img.shields.io/nuget/dt/Cake.Topshelf.svg?style=flat)](https://www.nuget.org/packages/Cake.Topshelf/)

Cake.Topshelf is available as a nuget package from the package manager console:

```csharp
Install-Package Cake.Topshelf
```

or directly in your build script via a cake addin:

```csharp
#addin "Cake.Topshelf"
```



## Usage

```csharp
#addin "Cake.Topshelf"

Task("Install")
    .Description("Installs a Topshelf service")
    .Does(() =>
{
    TopshelfInstall("C:/Services/example.exe", new TopshelfSettings()
    {
        Username = "Admin",
        Password = "Password1",

        Instance = "Example",
        Autostart = true,
        Delayed = true
    });
});

Task("Uninstall")
    .Description("Uninstalls a Topshelf service")
    .Does(() =>
{
    TopshelfUninstall("C:/Services/example.exe");
});



Task("Start")
    .Description("Starts a Topshelf service")
    .Does(() =>
{
    TopshelfStart("C:/Services/example.exe", "Instance Name");
});

Task("Stop")
    .Description("Stops a Topshelf service")
    .Does(() =>
{
    TopshelfStop("C:/Services/example.exe", "Instance Name");
});

RunTarget("Install");
```



## Example

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.Topshelf/blob/master/test/build.cake)



## License

Copyright © 2015 - 2016 Sergio Silveira, Phillip Sharpe

Cake.Topshelf is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/SharpeRAD/Cake.Topshelf/blob/master/LICENSE).



## Share the love

If this project helps you in anyway then please :star: the repository as its good to know your hardwork is appreciated.