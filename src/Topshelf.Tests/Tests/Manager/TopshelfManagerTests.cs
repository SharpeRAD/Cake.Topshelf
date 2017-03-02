using Cake.Core.IO;
using NSubstitute;
using Xunit;

namespace Cake.Topshelf.Tests.Manager
{
    public class TopshelfManagerTests
    {
        private readonly DebugLog _debugLog;
        private readonly IProcessRunner _processRunner;
        private readonly IProcess _process;

        const int ExpectedDefaultTimeoutMs = 60000;

        public TopshelfManagerTests()
        {
            _debugLog = new DebugLog();
            _processRunner = Substitute.For<IProcessRunner>();
            _process = Substitute.For<IProcess>();

            _processRunner.Start(Arg.Any<FilePath>(), Arg.Any<ProcessSettings>())
                .Returns(_process);
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