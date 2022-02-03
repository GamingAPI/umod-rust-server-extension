namespace Oxide.Ext.Blackhawk
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Oxide.Core;
    using Oxide.Core.Extensions;

    public class BlackhawkExtension : Extension
    {
        internal static readonly Version AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

        public BlackhawkExtension(ExtensionManager manager) : base(manager)
        {
            Interface.Oxide.LogInfo("[Blackhawk Ext] Started");
        }

        ////public override bool SupportsReloading => true;

        public override string Name => "Blackhawk";

        public override string Author => "Lagoni";

        public override VersionNumber Version => new VersionNumber(AssemblyVersion.Major, AssemblyVersion.Minor, AssemblyVersion.Build);

        public override void OnModLoad()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, exception) =>
            {
                Interface.Oxide.LogException("An unhandled exception was thrown!", exception.ExceptionObject as Exception);
            };
        }

        public override void OnShutdown()
        {
            BlackhawkNats.GetInstance()?.Close();

            Interface.Oxide.LogInfo("[Blackhawk Ext] Disconnected nats client");
        }
    }
}
