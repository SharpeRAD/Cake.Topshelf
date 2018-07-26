using System;

namespace Cake.Topshelf.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class TopshelfException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public int ExitCode { get; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TopshelfException" /> class.
        /// </summary>
        /// <param name="exitCode">The exit code of topshelf command</param>
        public TopshelfException(int exitCode)
        {
            ExitCode = exitCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopshelfException" /> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exitCode"></param>
        public TopshelfException(string message, int exitCode)
            : base(message)
        {
            ExitCode = exitCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopshelfException" /> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        /// <param name="exitCode"></param>
        public TopshelfException(string message, Exception inner, int exitCode)
            : base(message, inner)
        {
            ExitCode = exitCode;
        }
    }
}