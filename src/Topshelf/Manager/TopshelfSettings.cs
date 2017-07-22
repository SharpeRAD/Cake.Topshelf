#region Using Statements
using Cake.Core.IO;
#endregion



namespace Cake.Topshelf
{
    /// <summary>
    /// Topshelf installer settings
    /// </summary>
    public class TopshelfSettings
    {
        #region Constructor (1)
        /// <summary>
        /// Initializes a new instance of the <see cref="TopshelfSettings" /> class.
        /// </summary>
        public TopshelfSettings()
        {

        }
        #endregion





        #region Properties (14)
        /// <summary>
        /// Sets the arguments to use during installation
        /// </summary>
        public ProcessArgumentBuilder Arguments { get; set; }



        /// <summary>
        /// Gets or sets the time in milliseconds to wait for the Topshelf executable to install
        /// </summary>
        public int Timeout { get; set; }



        /// <summary>
        /// Gets or sets the username to run the service.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password for the specified username.
        /// </summary>
        public string Password { get; set; }



        /// <summary>
        /// Gets or sets the instance name if registering the service multiple times
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// Gets or sets if the service should automatically start when windows loads
        /// </summary>
        public bool Autostart { get; set; }

        /// <summary>
        /// Gets or sets if the service should be set to disabled
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets if the service should start automatically (delayed)
        /// </summary>
        public bool Delayed { get; set; }



        /// <summary>
        /// Gets or sets the service with run with the local system account
        /// </summary>
        public bool LocalSystem { get; set; }

        /// <summary>
        /// Gets or sets the service with run with the local service account
        /// </summary>
        public bool LocalService { get; set; }

        /// <summary>
        /// Gets or sets the service with run with the network service account
        /// </summary>
        public bool NetworkService { get; set; }



        /// <summary>
        /// Gets or sets the name that the service should use when installing
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the display name the the service should use when installing
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the service description the service should use when installing
        /// </summary>
        public string Description { get; set; }
        #endregion
    }
}
