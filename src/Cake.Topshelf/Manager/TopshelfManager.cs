#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.IO.Arguments;
using Cake.Core.Diagnostics;
#endregion



namespace Cake.Topshelf
{
    /// <summary>
    /// Provides a high level utility for managing Topshelf services
    /// </summary>
    public class TopshelfManager : ITopshelfManager
    {
        #region Fields
        const int DefaultTimeoutMs = 60000;

        private readonly ICakeEnvironment _Environment;
        private readonly IProcessRunner _Runner;
        private readonly ICakeLog _Log;
        #endregion





        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TopshelfManager" /> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="runner">The process runner.</param>
        /// <param name="log">The log.</param>
        public TopshelfManager(ICakeEnvironment environment, IProcessRunner runner, ICakeLog log)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            if (runner == null)
            {
                throw new ArgumentNullException("runner");
            }
            if (log == null)
            {
                throw new ArgumentNullException("log");
            }

            _Environment = environment;
            _Runner = runner;
            _Log = log;
        }
        #endregion





        #region Methods
        private int ExecuteProcess(FilePath filePath, ProcessArgumentBuilder arguments, int timeout = DefaultTimeoutMs)
        {
            try
            {
                // Start Runner
                filePath = filePath.MakeAbsolute(_Environment.WorkingDirectory);

                IProcess process = _Runner.Start(filePath, new ProcessSettings()
                        {
                            Arguments = arguments,
                            RedirectStandardError = true
                        });

                process.WaitForExit(timeout);

                // Check for Errors
                IEnumerable<string> errors = process.GetStandardError();

                if (errors.Any())
                {
                    throw new Exception(string.Join(",", errors));
                }

                return process.GetExitCode();
            }
            catch (Exception ex)
            {
                if (!(ex is TimeoutException))
                {
                    throw;
                }

                _Log.Warning("Process timed out!");

                return -1;
            }
        }

        /// <summary>
        /// Installs a Topshelf windows service
        /// </summary>
        /// <param name="filePath">The file path of the Topshelf executable to install.</param>
        /// <param name="settings">The <see cref="TopshelfSettings"/> used to install the service.</param>
        public int InstallService(FilePath filePath, TopshelfSettings settings = null)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }

            int timeout = TopshelfManager.DefaultTimeoutMs;
            if (settings != null)
            {
                timeout = settings.Timeout;
            }

            var exitCode = this.ExecuteProcess(filePath, settings.GetArguments(), timeout);

            _Log.Verbose("Topshelf service installed.");

            return exitCode;
        }

        /// <summary>
        /// Uninstalls a Topshelf windows service
        /// </summary>
        /// <param name="filePath">The file path of the Topshelf executable to uninstall.</param>
        /// <param name="instance">The instance name of the service to uninstall.</param>
        /// <param name="sudo">Prompts for UAC if running on Vista/W7/2008</param>
        /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
        public int UninstallService(FilePath filePath, string instance = null, bool sudo = false, int timeout = DefaultTimeoutMs)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }

            var exitCode =  this.ExecuteProcess(filePath, new ProcessArgumentBuilder().AppendText("uninstall").AppendInstance(instance).AppendSudo(sudo), timeout);

            _Log.Verbose("Topshelf service uninstalled.");

            return exitCode;
        }



        /// <summary>
        /// Starts a Topshelf windows service
        /// </summary>
        /// <param name="filePath">The file path of the Topshelf executable to start.</param>
        /// <param name="instance">The instance name of the service to start.</param>
        /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
        public int StartService(FilePath filePath, string instance = null, int timeout = DefaultTimeoutMs)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }

            var exitCode = this.ExecuteProcess(filePath, new ProcessArgumentBuilder().AppendText("start").AppendInstance(instance), timeout);

            _Log.Verbose("Topshelf service started.");

            return exitCode;
        }

        /// <summary>
        /// Stops a Topshelf windows service
        /// </summary>
        /// <param name="filePath">The file path of the Topshelf executable to stop.</param>
        /// <param name="instance">The instance name of the service to stop.</param>
        /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
        public int StopService(FilePath filePath, string instance = null, int timeout = DefaultTimeoutMs)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }

            var exitCode = this.ExecuteProcess(filePath, new ProcessArgumentBuilder().AppendText("stop").AppendInstance(instance), timeout);

            _Log.Verbose("Topshelf service stopped.");

            return exitCode;
        }
        #endregion
    }
}
