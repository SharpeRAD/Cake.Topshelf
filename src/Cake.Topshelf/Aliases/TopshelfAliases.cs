#region Using Statements
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Annotations;
#endregion



namespace Cake.Topshelf
{
    /// <summary>
    /// Topshelf aliases
    /// </summary>
    [CakeAliasCategory("Topshelf")]
    public static class TopshelfAliases
    {
        #region Methods
        private static ITopshelfManager CreateManager(this ICakeContext context)
        {
            return new TopshelfManager(context.Environment, context.ProcessRunner, context.Log);
        }



        /// <summary>
        /// Installs a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to install.</param>
        /// <returns>Return exit code of action</returns>
        [CakeMethodAlias]
        public static int InstallTopshelf(this ICakeContext context, FilePath filePath)
        {
            return context.CreateManager().InstallService(filePath, null);
        }

        /// <summary>
        /// Installs a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to install.</param>
        /// <param name="settings">The <see cref="TopshelfSettings"/> used to install the service.</param>
        /// <returns>Return exit code of action</returns>
        [CakeMethodAlias]
        public static int InstallTopshelf(this ICakeContext context, FilePath filePath, TopshelfSettings settings)
        {
            return context.CreateManager().InstallService(filePath, settings);
        }

        /// <summary>
        /// Uninstalls a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to uninstall.</param>
        /// <returns>Return exit code of action</returns>
        [CakeMethodAlias]
        public static int UninstallTopshelf(this ICakeContext context, FilePath filePath)
        {
            return context.CreateManager().UninstallService(filePath);
        }

        /// <summary>
        /// Uninstalls a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to uninstall.</param>
        /// <param name="instance">The instance name of the service to uninstall.</param>
        /// <returns>Return exit code of action</returns>
        [CakeMethodAlias]
        public static int UninstallTopshelf(this ICakeContext context, FilePath filePath, string instance)
        {
            return context.CreateManager().UninstallService(filePath, instance);
        }

        /// <summary>
        /// Uninstalls a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to uninstall.</param>
        /// <param name="instance">The instance name of the service to uninstall.</param>
        /// <param name="sudo">Prompts for UAC if running on Vista/W7/2008</param>
        /// <returns>Return exit code of action</returns>
        [CakeMethodAlias]
        public static int UninstallTopshelf(this ICakeContext context, FilePath filePath, string instance, bool sudo)
        {
            return context.CreateManager().UninstallService(filePath, instance, sudo);
        }

        /// <summary>
        /// Uninstalls a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to uninstall.</param>
        /// <param name="instance">The instance name of the service to uninstall.</param>
        /// <param name="sudo">Prompts for UAC if running on Vista/W7/2008</param>
        /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
        /// <returns>Return exit code of action</returns>
        [CakeMethodAlias]
        public static int UninstallTopshelf(this ICakeContext context, FilePath filePath, string instance, bool sudo, int timeout)
        {
            return context.CreateManager().UninstallService(filePath, instance, sudo, timeout);
        }



        /// <summary>
        /// Starts a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to start.</param>
        /// <returns>Return exit code of action</returns>
        [CakeMethodAlias]
        public static int StartTopshelf(this ICakeContext context, FilePath filePath)
        {
            return context.CreateManager().StartService(filePath);
        }

        /// <summary>
        /// Starts a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to start.</param>
        /// <param name="instance">The instance name of the service to start.</param>
        /// <returns>Return exit code of action</returns>
        [CakeMethodAlias]
        public static int StartTopshelf(this ICakeContext context, FilePath filePath, string instance)
        {
            return context.CreateManager().StartService(filePath, instance);
        }

        /// <summary>
        /// Starts a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to start.</param>
        /// <param name="instance">The instance name of the service to start.</param>
        /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
        /// <returns>Return exit code of action</returns>
        [CakeMethodAlias]
        public static int StartTopshelf(this ICakeContext context, FilePath filePath, string instance, int timeout)
        {
            return context.CreateManager().StartService(filePath, instance, timeout);
        }



        /// <summary>
        /// Stops a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to stop.</param>
        /// <returns>Return exit code of action</returns>
        [CakeMethodAlias]
        public static int StopTopshelf(this ICakeContext context, FilePath filePath)
        {
            return context.CreateManager().StopService(filePath);
        }

        /// <summary>
        /// Stops a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to stop.</param>
        /// <param name="instance">The instance name of the service to stop.</param>
        /// <returns>Return exit code of action</returns>
        [CakeMethodAlias]
        public static int StopTopshelf(this ICakeContext context, FilePath filePath, string instance)
        {
            return context.CreateManager().StopService(filePath, instance);
        }

        /// <summary>
        /// Stops a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to stop.</param>
        /// <param name="instance">The instance name of the service to stop.</param>
        /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
        /// <returns>Return exit code of action</returns>
        [CakeMethodAlias]
        public static int StopTopshelf(this ICakeContext context, FilePath filePath, string instance, int timeout)
        {
            return context.CreateManager().StopService(filePath, instance, timeout);
        }
        #endregion
    }
}
