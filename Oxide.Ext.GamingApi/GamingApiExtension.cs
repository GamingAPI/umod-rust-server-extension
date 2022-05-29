namespace Oxide.Ext.GamingApi
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Oxide.Core;
    using Oxide.Core.Extensions;
    using Oxide.Ext.GamingApi;

    public class GamingApiExtension : Extension
    {
        internal static readonly Version AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

        public GamingApiExtension(ExtensionManager manager) : base(manager)
        {
            Interface.Oxide.LogInfo("[GamingApi Ext] Started");
        }

        ////public override bool SupportsReloading => true;

        public override string Name => "GamingApi";

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
            GamingApiNats.GetInstance()?.Close();

            Interface.Oxide.LogInfo("[GamingApi Ext] Disconnected nats client");
        }
    }
}
