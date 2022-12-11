// Reference: NewtonsoftAlias.Json
// Reference: NATS.Client
// Reference: RustGameAPI

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NewtonsoftAlias.Json;
using Oxide.Core;
using Oxide.Core.Extensions;

namespace Oxide.Ext.GamingApi
{

    public class GamingApiExtension : Extension
    {
        internal static readonly Version AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

        public GamingApiExtension(ExtensionManager manager) : base(manager)
        {
            Interface.Oxide.LogInfo("[GamingApi Ext] Started");
            Interface.Oxide.LogInfo("[GamingApi Ext] Libraries " + manager.GetLibraries().ToString());
            Account account = new Account
            {
                PackageId = "test"
            };

            string json2 = JsonConvert.SerializeObject(account, Formatting.Indented, new AccountConverter());
            // {
            //   "Email": "james@example.com",
            //   "Active": true,
            //   "CreatedDate": "2013-01-20T00:00:00Z",
            //   "Roles": [
            //     "User",
            //     "Admin"
            //   ]
            // }

            Interface.Oxide.LogInfo("[GamingApi Ext] Serialized message " + json2);
            Player p = new Player() { Name = "Test", Id = "TEST", Address = "123", AdditionalProperties = new Dictionary<string, object>()};
            p.AdditionalProperties.Add("TEST", 123);

            var json = JsonConvert.SerializeObject(p);
            Interface.Oxide.LogInfo("[GamingApi Ext] Serialized message " + json);

            Asyncapi.Nats.Client.Models.Player p2 = new Asyncapi.Nats.Client.Models.Player() { Name = "Test", Id = "TEST", Address = "123", AdditionalProperties = new Dictionary<string, object>() };
            p2.AdditionalProperties.Add("TEST", 123);
            var json3 = JsonConvert.SerializeObject(p2);
            Interface.Oxide.LogInfo("[GamingApi Ext] Serialized message " + json3);
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
