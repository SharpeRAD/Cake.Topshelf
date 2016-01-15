#region Using Statements
    using Cake.Core;
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
        private static ITopshelfManager CreateManager(this ICakeContext context)
        {
            return new TopshelfManager(context.Environment, context.ProcessRunner, context.Log);
        }



        /// <summary>
        /// Installs a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to install.</param>
        [CakeMethodAlias]
        public static void InstallTopshelf(this ICakeContext context, string filePath)
        {
            context.CreateManager().InstallService(filePath, null);
        }

        /// <summary>
        /// Installs a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to install.</param>
        /// <param name="settings">The <see cref="TopshelfSettings"/> used to install the service.</param>
        [CakeMethodAlias]
        public static void InstallTopshelf(this ICakeContext context, string filePath, TopshelfSettings settings)
        {
            context.CreateManager().InstallService(filePath, settings);
        }



        /// <summary>
        /// Uninstalls a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to uninstall.</param>
        [CakeMethodAlias]
        public static void UninstallTopshelf(this ICakeContext context, string filePath)
        {
            context.CreateManager().UninstallService(filePath);
        }

        /// <summary>
        /// Uninstalls a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to uninstall.</param>
        /// <param name="instance">The instance name of the service to uninstall.</param>
        [CakeMethodAlias]
        public static void UninstallTopshelf(this ICakeContext context, string filePath, string instance)
        {
            context.CreateManager().UninstallService(filePath, instance);
        }

        /// <summary>
        /// Uninstalls a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to uninstall.</param>
        /// <param name="instance">The instance name of the service to uninstall.</param>
        /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
        [CakeMethodAlias]
        public static void UninstallTopshelf(this ICakeContext context, string filePath, string instance, int timeout)
        {
            context.CreateManager().UninstallService(filePath, instance, timeout);
        }



        /// <summary>
        /// Starts a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to start.</param>
        [CakeMethodAlias]
        public static void StartTopshelf(this ICakeContext context, string filePath)
        {
            context.CreateManager().StartService(filePath);
        }

        /// <summary>
        /// Starts a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to start.</param>
        /// <param name="instance">The instance name of the service to start.</param>
        [CakeMethodAlias]
        public static void StartTopshelf(this ICakeContext context, string filePath, string instance)
        {
            context.CreateManager().StartService(filePath, instance);
        }

        /// <summary>
        /// Starts a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to start.</param>
        /// <param name="instance">The instance name of the service to start.</param>
        /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
        [CakeMethodAlias]
        public static void StartTopshelf(this ICakeContext context, string filePath, string instance, int timeout)
        {
            context.CreateManager().StartService(filePath, instance, timeout);
        }



        /// <summary>
        /// Stops a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to stop.</param>
        [CakeMethodAlias]
        public static void StopTopshelf(this ICakeContext context, string filePath)
        {
            context.CreateManager().StopService(filePath);
        }

        /// <summary>
        /// Stops a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to stop.</param>
        /// <param name="instance">The instance name of the service to stop.</param>
        [CakeMethodAlias]
        public static void StopTopshelf(this ICakeContext context, string filePath, string instance)
        {
            context.CreateManager().StopService(filePath, instance);
        }

        /// <summary>
        /// Stops a Topshelf windows service
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="filePath">The file path of the Topshelf executable to stop.</param>
        /// <param name="instance">The instance name of the service to stop.</param>
        /// <param name="timeout">The time in milliseconds to wait for the Topshelf executable.</param>
        [CakeMethodAlias]
        public static void StopTopshelf(this ICakeContext context, string filePath, string instance, int timeout)
        {
            context.CreateManager().StopService(filePath, instance, timeout);
        }
    }
}
