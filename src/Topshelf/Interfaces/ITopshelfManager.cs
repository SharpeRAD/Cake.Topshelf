#region Using Statements
    using System;
#endregion



namespace Cake.Topshelf
{
    /// <summary>
    /// Provides a high level utility for managing Topshelf services
    /// </summary>
    public interface ITopshelfManager
    {
        #region Functions (4)
            /// <summary>
            /// Installs a Topshelf windows service
            /// </summary>
            /// <param name="filePath">The file path of the Topshelf executable to install.</param>
            /// <param name="settings">The <see cref="TopshelfSettings"/> used to install the service.</param>
            void InstallService(string filePath, TopshelfSettings settings = null);

            /// <summary>
            /// Uninstalls a Topshelf windows service
            /// </summary>
            /// <param name="filePath">The file path of the Topshelf executable to uninstall.</param>
            /// <param name="instance">The instance name of the service to uninstall.</param>
            /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
            void UninstallService(string filePath, string instance = null, int timeout = 60000);



            /// <summary>
            /// Starts a Topshelf windows service
            /// </summary>
            /// <param name="filePath">The file path of the Topshelf executable to start.</param>
            /// <param name="instance">The instance name of the service to start.</param>
            /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
            void StartService(string filePath, string instance = null, int timeout = 60000);

            /// <summary>
            /// Stops a Topshelf windows service
            /// </summary>
            /// <param name="filePath">The file path of the Topshelf executable to stop.</param>
            /// <param name="instance">The instance name of the service to stop.</param>
            /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
            void StopService(string filePath, string instance = null, int timeout = 60000);
        #endregion
    }
}
