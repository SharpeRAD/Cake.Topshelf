using Cake.Core.IO;
using Cake.Core.IO.Arguments;

namespace Cake.Topshelf
{
    internal static class InstallArgumentsFactory
    {
        public static ProcessArgumentBuilder Create(TopshelfSettings settings)
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
                    builder.Append(new QuotedArgument(new TextArgument(settings.ServiceName)));
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

    }
}