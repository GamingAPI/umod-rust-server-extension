namespace Oxide.Ext.GamingApi
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Oxide.Core;
    using Oxide.Core.Extensions;
    using Oxide.Ext.GamingApi;

    public class GamingEventApiExtension : Extension
    {
        internal static readonly Version AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

        public GamingEventApiExtension(ExtensionManager manager) : base(manager)
        {
            Interface.Oxide.LogInfo("[GamingEventApi Ext] Started");
        }

        ////public override bool SupportsReloading => true;

        public override string Name => "GamingEventApi";

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
            GamingEventApiNats.GetInstance()?.Close();

            Interface.Oxide.LogInfo("[GamingEventApi Ext] Disconnected nats client");
        }
    }
}
