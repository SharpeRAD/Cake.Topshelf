#region Using Statements
using Cake.Core.IO;
#endregion



namespace Cake.Topshelf
{
    /// <summary>
    /// Provides a high level utility for managing Topshelf services
    /// </summary>
    public interface ITopshelfManager
    {
        #region Methods
        /// <summary>
        /// Installs a Topshelf windows service
        /// </summary>
        /// <param name="filePath">The file path of the Topshelf executable to install.</param>
        /// <param name="settings">The <see cref="TopshelfSettings"/> used to install the service.</param>
        /// <returns>Return exit code of action</returns>
        int InstallService(FilePath filePath, TopshelfSettings settings = null);

        /// <summary>
        /// Uninstalls a Topshelf windows service
        /// </summary>
        /// <param name="filePath">The file path of the Topshelf executable to uninstall.</param>
        /// <param name="instance">The instance name of the service to uninstall.</param>
        /// <param name="sudo">Prompts for UAC if running on Vista/W7/2008</param>
        /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
        /// <returns>Return exit code of action</returns>
        int UninstallService(FilePath filePath, string instance = null, bool sudo = false, int timeout = 60000);

        /// <summary>
        /// Starts a Topshelf windows service
        /// </summary>
        /// <param name="filePath">The file path of the Topshelf executable to start.</param>
        /// <param name="instance">The instance name of the service to start.</param>
        /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
        /// /// <returns>Return exit code of action</returns>
        int StartService(FilePath filePath, string instance = null, int timeout = 60000);

        /// <summary>
        /// Stops a Topshelf windows service
        /// </summary>
        /// <param name="filePath">The file path of the Topshelf executable to stop.</param>
        /// <param name="instance">The instance name of the service to stop.</param>
        /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
        /// <returns>Return exit code of action</returns>
        int StopService(FilePath filePath, string instance = null, int timeout = 60000);
        #endregion
    }
}
