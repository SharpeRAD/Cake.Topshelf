using Cake.Core.IO;
using NSubstitute;
using Xunit;

namespace Cake.Topshelf.Tests.Manager
{
    public class TopshelfManagerTests
    {
        private readonly DebugLog _debugLog;
        private readonly IProcessRunner _processRunner;
        private IProcess _process;

        const int ExpectedDefaultTimeoutMs = 60000;

        public TopshelfManagerTests()
        {
            _debugLog = new DebugLog();
            _processRunner = Substitute.For<IProcessRunner>();
            _process = Substitute.For<IProcess>();

            _processRunner.Start(Arg.Any<FilePath>(), Arg.Any<ProcessSettings>())
                .Returns(_process);
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

        private TopshelfManager CreateSut()
        {
            return new TopshelfManager(
                CakeHelper.CreateEnvironment(), 
                _processRunner,
                _debugLog);
        }
    }
}