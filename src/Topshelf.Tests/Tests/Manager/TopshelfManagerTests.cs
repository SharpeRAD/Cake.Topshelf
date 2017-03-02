using Cake.Core.IO;
using NSubstitute;
using Xunit;

namespace Cake.Topshelf.Tests.Manager
{
    public class TopshelfManagerTests
    {
        private readonly DebugLog _debugLog;
        private readonly IProcessRunner _processRunner;

        public TopshelfManagerTests()
        {
            _debugLog = new DebugLog();
            _processRunner = Substitute.For<IProcessRunner>();
        }

        [Fact]
        public void InstallService_WhenNoSettingsSupplied_ShouldUseDefaultTimeout()
        {
            var sut = CreateSut();

            sut.InstallService(new FilePath("SomePath"));

            _processRunner.Received().Start(Arg.Any<FilePath>(), Arg.Any<ProcessSettings>()).WaitForExit(60000);
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