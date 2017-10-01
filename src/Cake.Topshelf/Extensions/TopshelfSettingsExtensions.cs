#region Using Statements
using System;

using Cake.Core.IO;
#endregion



namespace Cake.Topshelf
{
    /// <summary>
    /// Contains extension methods for <see cref="TopshelfSettings" />.
    /// </summary>
    public static class TopshelfSettingsExtensions
    {
        #region Methods
        /// <summary>
        /// Sets the arguments to use during installation
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="arguments">The arguments to append.</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings WithArguments(this TopshelfSettings settings, Action<ProcessArgumentBuilder> arguments)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            if (settings.Arguments == null)
            {
                settings.Arguments = new ProcessArgumentBuilder();
            }

            arguments(settings.Arguments);
            return settings;
        }



        /// <summary>
        /// Specifies the time in milliseconds to wait for the Topshelf executable
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="timeout">The time in milliseconds.</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings SetServiceName(this TopshelfSettings settings, int timeout)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Timeout = timeout;
            return settings;
        }



        /// <summary>
        /// Specifies the service name returned by the getkeyname operation.
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="name">The name of the service</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings SetServiceName(this TopshelfSettings settings, string name)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.ServiceName = name;
            return settings;
        }

        /// <summary>
        /// Specifies a friendly name that can be used by user interface programs to identify the service.
        /// </summary>
        /// <param name="settings">The process settings.</param>
        /// <param name="name">The friendly name of the service</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings SetDisplayName(this TopshelfSettings settings, string name)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.DisplayName = name;
            return settings;
        }

        /// <summary>
        /// Specifies a description for the specified service. If no string is specified, the description of the service is not modified. There is no limit to the number of characters in the service description.
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="description">The description of the service</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings SetDescription(this TopshelfSettings settings, string description)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Description = description;
            return settings;
        }



        /// <summary>
        /// Sets the credentials to use when connecting
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="username">The username to connect with.</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings UseUsername(this TopshelfSettings settings, string username)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Username = username;
            return settings;
        }

        /// <summary>
        /// Sets the credentials to use when connecting
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="password">The password to connect with.</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings UsePassword(this TopshelfSettings settings, string password)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Password = password;
            return settings;
        }



        /// <summary>
        /// Sets the instance name if registering the service multiple times
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="name">The name of the instance</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings SetInstance(this TopshelfSettings settings, string name)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Instance = name;
            return settings;
        }

        /// <summary>
        /// Sets if the service should automatically start when windows loads
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="autostart">if the service should automatically start when windows loads</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings SetAutostart(this TopshelfSettings settings, bool autostart = true)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Autostart = autostart;
            return settings;
        }

        /// <summary>
        /// Sets if the service should be set to disabled
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="disabled">if the service should be set to disabled</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings SetDisabled(this TopshelfSettings settings, bool disabled = true)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Disabled = disabled;
            return settings;
        }

        /// <summary>
        /// Sets if the service should start automatically (delayed)
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="delayed">if the service should start delayed</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings SetDelayed(this TopshelfSettings settings, bool delayed = true)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Delayed = delayed;
            return settings;
        }



        /// <summary>
        /// Sets if the service with run with the local system account
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="localSystem">Run with the local system account</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings UseLocalSystem(this TopshelfSettings settings, bool localSystem = true)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.LocalSystem = localSystem;
            return settings;
        }

        /// <summary>
        /// Sets if the service with run with the local service account
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="localService">Run with the local service account</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings UseLocalService(this TopshelfSettings settings, bool localService = true)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.LocalService = localService;
            return settings;
        }

        /// <summary>
        /// Sets if the service with run with the network service account
        /// </summary>
        /// <param name="settings">The installation settings.</param>
        /// <param name="networkService">Run with the network service account</param>
        /// <returns>The same <see cref="TopshelfSettings"/> instance so that multiple calls can be chained.</returns>
        public static TopshelfSettings UseNetworkService(this TopshelfSettings settings, bool networkService = true)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.NetworkService = networkService;
            return settings;
        }
        #endregion
    }
}
