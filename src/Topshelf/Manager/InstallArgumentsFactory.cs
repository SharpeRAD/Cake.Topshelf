using Cake.Core.IO;
using Cake.Core.IO.Arguments;

namespace Cake.Topshelf
{
    internal static class InstallArgumentsFactory
    {
        public static ProcessArgumentBuilder Create(TopshelfSettings settings)
        {
            var builder = UseExistingArgumentsIfSupplied(settings);

            AppendInstall(builder);

            if (settings != null)
            {
                AppendUserName(settings, builder);
                AppendPassword(settings, builder);
                AppendInstance(settings, builder);
                AppendStartupMode(settings, builder);
                AppendDisabled(settings, builder);
                AppendDelayed(settings, builder);
                AppendLocalSystem(settings, builder);
                AppendLocalService(settings, builder);
                AppendNetworkService(settings, builder);
                AppendServiceName(settings, builder);
                AppendDescription(settings, builder);
                AppendDisplayname(settings, builder);
            }

            return builder;
        }

        private static void AppendDisplayname(TopshelfSettings settings, ProcessArgumentBuilder builder)
        {
            if (!string.IsNullOrWhiteSpace(settings.DisplayName))
            {
                builder.Append(new TextArgument("--displayname"));
                builder.Append(new QuotedArgument(new TextArgument(settings.DisplayName)));
            }
        }

        private static void AppendDescription(TopshelfSettings settings, ProcessArgumentBuilder builder)
        {
            if (!string.IsNullOrWhiteSpace(settings.Description))
            {
                builder.Append(new TextArgument("--description"));
                builder.Append(new QuotedArgument(new TextArgument(settings.Description)));
            }
        }

        private static void AppendServiceName(TopshelfSettings settings, ProcessArgumentBuilder builder)
        {
            if (!string.IsNullOrWhiteSpace(settings.ServiceName))
            {
                builder.Append(new TextArgument("--servicename"));
                builder.Append(new QuotedArgument(new TextArgument(settings.ServiceName)));
            }
        }

        private static void AppendNetworkService(TopshelfSettings settings, ProcessArgumentBuilder builder)
        {
            if (settings.NetworkService)
                builder.Append(new TextArgument("--networkservice"));
        }

        private static void AppendLocalService(TopshelfSettings settings, ProcessArgumentBuilder builder)
        {
            if (settings.LocalService)
                builder.Append(new TextArgument("--localservice"));
        }

        private static void AppendLocalSystem(TopshelfSettings settings, ProcessArgumentBuilder builder)
        {
            if (settings.LocalSystem)
                builder.Append(new TextArgument("--localsystem"));
        }

        private static void AppendDelayed(TopshelfSettings settings, ProcessArgumentBuilder builder)
        {
            if (settings.Delayed)
                builder.Append(new TextArgument("--delayed"));
        }

        private static void AppendDisabled(TopshelfSettings settings, ProcessArgumentBuilder builder)
        {
            if (settings.Disabled)
                builder.Append(new TextArgument("--disabled"));
        }

        private static void AppendStartupMode(TopshelfSettings settings, ProcessArgumentBuilder builder)
        {
            builder.Append(settings.Autostart
                ? new TextArgument("--autostart")
                : new TextArgument("--manual"));
        }

        private static void AppendInstance(TopshelfSettings settings, ProcessArgumentBuilder builder)
        {
            if (!string.IsNullOrWhiteSpace(settings.Instance))
            {
                builder.Append(new TextArgument("-instance"));
                builder.Append(new QuotedArgument(new TextArgument(settings.Instance)));
            }
        }

        private static void AppendPassword(TopshelfSettings settings, ProcessArgumentBuilder builder)
        {
            if (!string.IsNullOrWhiteSpace(settings.Password))
            {
                builder.Append(new TextArgument("-password"));
                builder.Append(new QuotedArgument(new TextArgument(settings.Password)));
            }
        }

        private static void AppendInstall(ProcessArgumentBuilder builder)
        {
            builder.Append(new TextArgument("install"));
        }

        private static ProcessArgumentBuilder UseExistingArgumentsIfSupplied(TopshelfSettings settings)
        {
            ProcessArgumentBuilder builder = new ProcessArgumentBuilder();

            if ((settings != null) && (settings.Arguments != null))
            {
                builder = settings.Arguments;
            }
            return builder;
        }

        private static void AppendUserName(TopshelfSettings settings, ProcessArgumentBuilder builder)
        {
            if (!string.IsNullOrWhiteSpace(settings.Username))
            {
                builder.Append(new TextArgument("-username"));
                builder.Append(new QuotedArgument(new TextArgument(settings.Username)));
            }
        }
    }
}