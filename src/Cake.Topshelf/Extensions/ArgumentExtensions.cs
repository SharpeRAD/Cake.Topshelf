#region Using Statements
using Cake.Core.IO;
using Cake.Core.IO.Arguments;
#endregion



namespace Cake.Topshelf
{
    internal static class ArgumentExtensions
    {
        #region Methods
        public static ProcessArgumentBuilder GetArguments(this TopshelfSettings settings)
        {
            var builder = UseExistingArgumentsIfSupplied(settings);

            builder.AppendInstall();

            if (settings != null)
            {
                builder.AppendUserName(settings)
                       .AppendPassword(settings)
                       .AppendInstance(settings)
                       .AppendStartupMode(settings)
                       .AppendDisabled(settings)
                       .AppendDelayed(settings)
                       .AppendLocalSystem(settings)
                       .AppendLocalService(settings)
                       .AppendNetworkService(settings)
                       .AppendServiceName(settings)
                       .AppendDescription(settings)
                       .AppendDisplayname(settings);
            }

            return builder;
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

        private static ProcessArgumentBuilder AppendInstall(this ProcessArgumentBuilder builder)
        {
            return builder.AppendText("install");
        }



        private static ProcessArgumentBuilder AppendDisplayname(this ProcessArgumentBuilder builder, TopshelfSettings settings)
        {
            if (!string.IsNullOrWhiteSpace(settings.DisplayName))
            {
                builder.Append(new TextArgument("-displayname"));
                builder.Append(new QuotedArgument(new TextArgument(settings.DisplayName)));
            }

            return builder;
        }

        private static ProcessArgumentBuilder AppendDescription(this ProcessArgumentBuilder builder, TopshelfSettings settings)
        {
            if (!string.IsNullOrWhiteSpace(settings.Description))
            {
                builder.Append(new TextArgument("-description"));
                builder.Append(new QuotedArgument(new TextArgument(settings.Description)));
            }

            return builder;
        }

        private static ProcessArgumentBuilder AppendServiceName(this ProcessArgumentBuilder builder, TopshelfSettings settings)
        {
            if (!string.IsNullOrWhiteSpace(settings.ServiceName))
            {
                builder.Append(new TextArgument("-servicename"));
                builder.Append(new QuotedArgument(new TextArgument(settings.ServiceName)));
            }

            return builder;
        }

        private static ProcessArgumentBuilder AppendNetworkService(this ProcessArgumentBuilder builder, TopshelfSettings settings)
        {
            if (settings.NetworkService)
            {
                builder.Append(new TextArgument("--networkservice"));
            }

            return builder;
        }

        private static ProcessArgumentBuilder AppendLocalService(this ProcessArgumentBuilder builder, TopshelfSettings settings)
        {
            if (settings.LocalService)
            {
                builder.Append(new TextArgument("--localservice"));
            }

            return builder;
        }

        private static ProcessArgumentBuilder AppendLocalSystem(this ProcessArgumentBuilder builder, TopshelfSettings settings)
        {
            if (settings.LocalSystem)
            {
                builder.Append(new TextArgument("--localsystem"));
            }

            return builder;
        }

        private static ProcessArgumentBuilder AppendDelayed(this ProcessArgumentBuilder builder, TopshelfSettings settings)
        {
            if (settings.Delayed)
            {
                builder.Append(new TextArgument("--delayed"));
            }

            return builder;
        }

        private static ProcessArgumentBuilder AppendDisabled(this ProcessArgumentBuilder builder, TopshelfSettings settings)
        {
            if (settings.Disabled)
            {
                builder.Append(new TextArgument("--disabled"));
            }

            return builder;
        }

        private static ProcessArgumentBuilder AppendStartupMode(this ProcessArgumentBuilder builder, TopshelfSettings settings)
        {
            builder.Append(settings.Autostart
                ? new TextArgument("--autostart")
                : new TextArgument("--manual"));

            return builder;
        }

        private static ProcessArgumentBuilder AppendPassword(this ProcessArgumentBuilder builder, TopshelfSettings settings)
        {
            if (!string.IsNullOrWhiteSpace(settings.Password))
            {
                builder.Append(new TextArgument("-password"));
                builder.Append(new QuotedArgument(new TextArgument(settings.Password)));
            }

            return builder;
        }

        private static ProcessArgumentBuilder AppendUserName(this ProcessArgumentBuilder builder, TopshelfSettings settings)
        {
            if (!string.IsNullOrWhiteSpace(settings.Username))
            {
                builder.Append(new TextArgument("-username"));
                builder.Append(new QuotedArgument(new TextArgument(settings.Username)));
            }

            return builder;
        }



        private static ProcessArgumentBuilder AppendInstance(this ProcessArgumentBuilder builder, TopshelfSettings settings)
        {
            if (!string.IsNullOrWhiteSpace(settings.Instance))
            {
                builder.Append(new TextArgument("-instance"));
                builder.Append(new QuotedArgument(new TextArgument(settings.Instance)));
            }

            return builder;
        }

        public static ProcessArgumentBuilder AppendInstance(this ProcessArgumentBuilder builder, string instance)
        {
            if (!string.IsNullOrWhiteSpace(instance))
            {
                builder.Append(new TextArgument("-instance"));
                builder.Append(new QuotedArgument(new TextArgument(instance)));
            }

            return builder;
        }

        public static ProcessArgumentBuilder AppendText(this ProcessArgumentBuilder builder, string text)
        {
            builder.Append(new TextArgument(text));

            return builder;
        }



        public static ProcessArgumentBuilder AppendSudo(this ProcessArgumentBuilder builder, bool sudo)
        {
            if (sudo)
            {
                builder.Append(new TextArgument("--sudo"));
            }

            return builder;
        }
        #endregion
    }
}
