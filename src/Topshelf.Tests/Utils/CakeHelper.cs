#region Using Statements
    using System.IO;

    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Diagnostics;

    using NSubstitute;
#endregion



namespace Cake.Topshelf.Tests
{
    internal static class CakeHelper
    {
        #region Functions (2)
            public static ICakeEnvironment CreateEnvironment()
            {
                var environment = Substitute.For<ICakeEnvironment>();
                environment.WorkingDirectory = Directory.GetCurrentDirectory();

                return environment;
            }



            public static ITopshelfManager CreateTransferManager()
            {
                ICakeEnvironment enviroment = CakeHelper.CreateEnvironment();
                ICakeLog log = new DebugLog();

                return new TopshelfManager(enviroment, new ProcessRunner(enviroment, log), log);
            }
        #endregion
    }
}
