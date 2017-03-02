using System.Configuration;
using Cake.Core.IO;
using FluentAssertions;
using NSubstitute;
using Xunit;
using Xunit.Sdk;

namespace Cake.Topshelf.Tests.Manager
{
    public class TopshelfManagerTests
    {
        private readonly DebugLog _debugLog;
        private readonly IProcessRunner _processRunner;
        private readonly IProcess _process;
        private ProcessSettings _processSettingsPassed;

        const int ExpectedDefaultTimeoutMs = 60000;

        public TopshelfManagerTests()
        {
            _debugLog = new DebugLog();
            _processRunner = Substitute.For<IProcessRunner>();
            _process = Substitute.For<IProcess>();

            _processRunner.Start(Arg.Any<FilePath>(), Arg.Any<ProcessSettings>())
               .Returns(_process).AndDoes(callinfo =>
               {
                   _processSettingsPassed = callinfo.Arg<ProcessSettings>();
               });
        }

        private TopshelfManager CreateSut()
        {
            return new TopshelfManager(
                CakeHelper.CreateEnvironment(),
                _processRunner,
                _debugLog);
        }

        [Fact]
        public void InstallService_WhenNoSettingsSupplied_ShouldUseDefaultTimeout()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"));

            _process.Received()
                .WaitForExit(ExpectedDefaultTimeoutMs);
        }

        [Fact]
        public void InstallService_WhenTimeoutSuppliedInSettings_ShouldUseSuppliedTimeout()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings() { Timeout = 100 });

            _process.Received()
                .WaitForExit(100);
        }

        [Fact]
        public void InstallService_ShouldAddInstallToTopshelfArgs()
        {
            var sut = CreateSut();
      
            sut.InstallService(new FilePath("SomePath"));

            _processSettingsPassed.Arguments.Render().Should().Be("install");
        }

        [Fact]
        public void InstallService_WhenSetting_AutoStart_ShouldAddToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                Autostart = true
            });

            _processSettingsPassed.Arguments.Render().Should().Be("install --autostart");
        }

        [Fact]
        public void InstallService_WhenNOtSetting_AutoStart_ShouldAddManualToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                Autostart = false
            });

            _processSettingsPassed.Arguments.Render().Should().Be("install --manual");
        }

        [Fact]
        public void InstallService_WhenSetting_Delayed_ShouldAddToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                Delayed = true
            });

            _processSettingsPassed.Arguments.Render().Should().StartWith("install ");
            _processSettingsPassed.Arguments.Render().Should().Contain(" --delayed");
        }

        [Fact]
        public void InstallService_WhenSetting_UserName_ShouldAddToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                Username = "Nathan"
            });

            _processSettingsPassed.Arguments.Render().Should().StartWith("install ");
            _processSettingsPassed.Arguments.Render().Should().Contain(" -username \"Nathan\" ");
        }

        [Fact]
        public void InstallService_WhenSetting_Password_ShouldAddToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                Password = "foo"
            });

            _processSettingsPassed.Arguments.Render().Should().StartWith("install ");
            _processSettingsPassed.Arguments.Render().Should().Contain(" -password \"foo\" ");
        }

        [Fact]
        public void InstallService_WhenSetting_Instance_ShouldAddToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                Instance = "bar"
            });

            _processSettingsPassed.Arguments.Render().Should().StartWith("install ");
            _processSettingsPassed.Arguments.Render().Should().Contain(" -instance \"bar\" ");
        }

        [Fact]
        public void InstallService_WhenSetting_Disabled_ShouldAddToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                Disabled = true
            });

            _processSettingsPassed.Arguments.Render().Should().StartWith("install ");
            _processSettingsPassed.Arguments.Render().Should().Contain(" --disabled");
        }

        [Fact]
        public void InstallService_WhenSetting_LocalSystem_ShouldAddToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                LocalSystem = true
            });

            _processSettingsPassed.Arguments.Render().Should().StartWith("install ");
            _processSettingsPassed.Arguments.Render().Should().Contain(" --localsystem");
        }

        [Fact]
        public void InstallService_WhenSetting_LocalService_ShouldAddToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                LocalService = true
            });

            _processSettingsPassed.Arguments.Render().Should().StartWith("install ");
            _processSettingsPassed.Arguments.Render().Should().Contain(" --localservice");
        }

        [Fact]
        public void InstallService_WhenSetting_NetworkService_ShouldAddToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                NetworkService = true
            });

            _processSettingsPassed.Arguments.Render().Should().StartWith("install ");
            _processSettingsPassed.Arguments.Render().Should().Contain(" --networkservice");
        }

        [Fact(Skip = "ExistingBug!")]
        public void InstallService_WhenSetting_ServiceName_ShouldAddToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                ServiceName = "Terminator"
            });

            _processSettingsPassed.Arguments.Render().Should().StartWith("install ");
            _processSettingsPassed.Arguments.Render().Should().Contain(" --servicename \"Terminator\"");
        }

        [Fact]
        public void InstallService_WhenSetting_Description_ShouldAddToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                Description = "SomeDescription"
            });

            _processSettingsPassed.Arguments.Render().Should().StartWith("install ");
            _processSettingsPassed.Arguments.Render().Should().Contain(" --description \"SomeDescription\"");
        }

        [Fact]
        public void InstallService_WhenSetting_DisplayName_ShouldAddToTopshelfArgs()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"), new TopshelfSettings()
            {
                DisplayName = "SomeDisplayName"
            });

            _processSettingsPassed.Arguments.Render().Should().StartWith("install ");
            _processSettingsPassed.Arguments.Render().Should().Contain(" --displayname \"SomeDisplayName\"");
        }
        [Fact]
        public void UninstallService_WhenNoSettingsSupplied_ShouldUseDefaultTimeout()
        {
            var sut = CreateSut();

            sut.UninstallService(new FilePath("SomePath"));

            _process.Received()
                .WaitForExit(ExpectedDefaultTimeoutMs);
        }

        [Fact]
        public void UninstallService_WhenTimeoutSuppliedInSettings_ShouldUseSuppliedTimeout()
        {
            var sut = CreateSut();

            sut.UninstallService(new FilePath("SomePath"), timeout: 100);

            _process.Received()
                .WaitForExit(100);
        }

        [Fact]
        public void StartService_WhenNoSettingsSupplied_ShouldUseDefaultTimeout()
        {
            var sut = CreateSut();

            sut.StartService(new FilePath("SomePath"));

            _process.Received()
                .WaitForExit(ExpectedDefaultTimeoutMs);
        }

        [Fact]
        public void StartService_WhenTimeoutSuppliedInSettings_ShouldUseSuppliedTimeout()
        {
            var sut = CreateSut();

            sut.StartService(new FilePath("SomePath"), timeout: 100);

            _process.Received()
                .WaitForExit(100);
        }

        [Fact]
        public void StopService_WhenNoSettingsSupplied_ShouldUseDefaultTimeout()
        {
            var sut = CreateSut();

            sut.StopService(new FilePath("SomePath"));

            _process.Received()
                .WaitForExit(ExpectedDefaultTimeoutMs);
        }

        [Fact]
        public void StopService_WhenTimeoutSuppliedInSettings_ShouldUseSuppliedTimeout()
        {
            var sut = CreateSut();

            sut.StopService(new FilePath("SomePath"), timeout: 100);

            _process.Received()
                .WaitForExit(100);
        }
    }
}