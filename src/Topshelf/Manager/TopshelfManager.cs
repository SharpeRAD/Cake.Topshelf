#region Using Statements
    using System;

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
        #region Fields (3)
            private readonly ICakeEnvironment _Environment;
            private readonly IProcessRunner _Runner;
            private readonly ICakeLog _Log;
        #endregion





        #region Constructor (1)
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





        #region Functions (6)
            private void ExecuteProcess(FilePath filePath, ProcessArgumentBuilder arguments, int timeout = 60000)
            {
                try
                {
                    filePath = filePath.MakeAbsolute(_Environment.WorkingDirectory);

                    _Runner.Start(filePath, new ProcessSettings()
                            {
                                Arguments = arguments
                            })
                            .WaitForExit(timeout);
                }
                catch (Exception ex)
                {
                    if (!(ex is TimeoutException)) throw;

                    _Log.Warning("Process timed out!");
                }
            }

            private ProcessArgumentBuilder GetInstallArguments(TopshelfSettings settings)
            {
                ProcessArgumentBuilder builder = new ProcessArgumentBuilder();

                if ((settings != null) && (settings.Arguments != null))
                {
                    builder = settings.Arguments;
                }

                builder.Append(new TextArgument("install"));



                if (settings != null)
                {
                    if (!string.IsNullOrWhiteSpace(settings.Username))
                    {
                        builder.Append(new TextArgument("-username"));
                        builder.Append(new QuotedArgument(new TextArgument(settings.Username)));
                    }

                    if (!string.IsNullOrWhiteSpace(settings.Password))
                    {
                        builder.Append(new TextArgument("-password"));
                        builder.Append(new QuotedArgument(new TextArgument(settings.Password)));
                    }

                    if (!string.IsNullOrWhiteSpace(settings.Instance))
                    {
                        builder.Append(new TextArgument("-instance"));
                        builder.Append(new QuotedArgument(new TextArgument(settings.Instance)));
                    }

                    builder.Append(settings.Autostart
                            ? new TextArgument("--autostart")
                            : new TextArgument("--manual"));

                    if (settings.Disabled)
                        builder.Append(new TextArgument("--disabled"));

                    if (settings.Delayed)
                        builder.Append(new TextArgument("--delayed"));

                    if (settings.LocalSystem)
                        builder.Append(new TextArgument("--localsystem"));

                    if (settings.LocalService)
                        builder.Append(new TextArgument("--localservice"));

                    if (settings.NetworkService)
                        builder.Append(new TextArgument("--networkservice"));

                    if (!string.IsNullOrWhiteSpace(settings.ServiceName))
                    {
                        builder.Append(new TextArgument("--servicename"));
                        builder.Append(new QuotedArgument(new TextArgument(settings.Description)));
                    }

                    if (!string.IsNullOrWhiteSpace(settings.Description))
                    {
                        builder.Append(new TextArgument("--description"));
                        builder.Append(new QuotedArgument(new TextArgument(settings.Description)));
                    }

                    if (!string.IsNullOrWhiteSpace(settings.DisplayName))
                    {
                        builder.Append(new TextArgument("--displayname"));
                        builder.Append(new QuotedArgument(new TextArgument(settings.DisplayName)));
                    }
                }

                return builder;
            }



            /// <summary>
            /// Installs a Topshelf windows service
            /// </summary>
            /// <param name="filePath">The file path of the Topshelf executable to install.</param>
            /// <param name="settings">The <see cref="TopshelfSettings"/> used to install the service.</param>
            public void InstallService(FilePath filePath, TopshelfSettings settings = null)
            {
                if (filePath == null)
                {
                    throw new ArgumentNullException("filePath");
                }

                this.ExecuteProcess(filePath, this.GetInstallArguments(settings), settings.Timeout);

                _Log.Verbose("Topshelf service installed.");
            }

            /// <summary>
            /// Uninstalls a Topshelf windows service
            /// </summary>
            /// <param name="filePath">The file path of the Topshelf executable to uninstall.</param>
            /// <param name="instance">The instance name of the service to uninstall.</param>
            /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
            public void UninstallService(FilePath filePath, string instance = null, int timeout = 60000)
            {
                if (filePath == null)
                {
                    throw new ArgumentNullException("filePath");
                }

                this.ExecuteProcess(filePath, new ProcessArgumentBuilder().Append("uninstall " + (instance ?? "")), timeout);

                _Log.Verbose("Topshelf service uninstalled.");
            }



            /// <summary>
            /// Starts a Topshelf windows service
            /// </summary>
            /// <param name="filePath">The file path of the Topshelf executable to start.</param>
            /// <param name="instance">The instance name of the service to start.</param>
            /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
            public void StartService(FilePath filePath, string instance = null, int timeout = 60000)
            {
                if (filePath == null)
                {
                    throw new ArgumentNullException("filePath");
                }

                this.ExecuteProcess(filePath, new ProcessArgumentBuilder().Append("start " + (instance ?? "")), timeout);

                _Log.Verbose("Topshelf service started.");
            }

            /// <summary>
            /// Stops a Topshelf windows service
            /// </summary>
            /// <param name="filePath">The file path of the Topshelf executable to stop.</param>
            /// <param name="instance">The instance name of the service to stop.</param>
            /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
            public void StopService(FilePath filePath, string instance = null, int timeout = 60000)
            {
                if (filePath == null)
                {
                    throw new ArgumentNullException("filePath");
                }

                this.ExecuteProcess(filePath, new ProcessArgumentBuilder().Append("stop " + (instance ?? "")), timeout);

                _Log.Verbose("Topshelf service stopped.");
            }
        #endregion
    }
}
