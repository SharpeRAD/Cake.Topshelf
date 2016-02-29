# Cake.Topshelf
Cake Build addin for managing Topshelf windows services

[![Build status](https://ci.appveyor.com/api/projects/status/smmki80m1s7yi7xe?svg=true)](https://ci.appveyor.com/project/SharpeRAD/cake-topshelf)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake)



## Table of contents

1. [Implemented functionality](https://github.com/SharpeRAD/Cake.Topshelf#implemented-functionality)
2. [Referencing](https://github.com/SharpeRAD/Cake.Topshelf#referencing)
3. [Usage](https://github.com/SharpeRAD/Cake.Topshelf#usage)
4. [Example](https://github.com/SharpeRAD/Cake.Topshelf#example)
5. [Plays well with](https://github.com/SharpeRAD/Cake.Topshelf#plays-well-with)
6. [License](https://github.com/SharpeRAD/Cake.Topshelf#license)
7. [Share the love](https://github.com/SharpeRAD/Cake.Topshelf#share-the-love)



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

or directly in your build script via a cake addin directive:

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
    InstallTopshelf("C:/Services/example.exe", new TopshelfSettings()
    {
        Username = "Admin",
        Password = "Password1",

        Instance = "Example",
        Autostart = true,
        Delayed = true
    });
});

Task("Install-Fluent")
    .Description("Installs a Topshelf service using the fluent interface")
    .Does(() =>
{
    InstallTopshelf("C:/Services/example.exe", new TopshelfSettings()
        .UseUsername("Admin")
        .UsePassword("Password1")
        .SetInstance("Example")
        .SetAutostart()
        .SetDelayed()
    );
});

Task("Uninstall")
    .Description("Uninstalls a Topshelf service")
    .Does(() =>
{
    UninstallTopshelf("C:/Services/example.exe");
});



Task("Start")
    .Description("Starts a Topshelf service")
    .Does(() =>
{
    StartTopshelf("C:/Services/example.exe", "Instance Name");
});

Task("Stop")
    .Description("Stops a Topshelf service")
    .Does(() =>
{
    StopTopshelf("C:/Services/example.exe", "Instance Name");
});

RunTarget("Install");
```



## Example

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.Topshelf/blob/master/test/build.cake).



## Plays well with

If your looking to manage standard windows services or just looking for more related aliases its worth checking out [Cake.Services](https://github.com/SharpeRAD/Cake.Services).

If your looking for a way to trigger cake tasks based on windows events or at scheduled intervals then check out [CakeBoss](https://github.com/SharpeRAD/CakeBoss).



## License

Copyright (c) 2015 - 2016 Sergio Silveira, Phillip Sharpe

Cake.Topshelf is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/SharpeRAD/Cake.Topshelf/blob/master/LICENSE).



## Share the love

If this project helps you in anyway then please :star: the repository.
