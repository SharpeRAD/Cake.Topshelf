#region Using Statements
using System.IO;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Diagnostics;
using Cake.Testing;
#endregion



namespace Cake.Topshelf.Tests
{
    internal static class CakeHelper
    {
        #region Methods
        public static ICakeEnvironment CreateEnvironment()
        {
            var environment = FakeEnvironment.CreateWindowsEnvironment();
            environment.WorkingDirectory = Directory.GetCurrentDirectory();
            environment.WorkingDirectory = environment.WorkingDirectory.Combine("../../../");

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