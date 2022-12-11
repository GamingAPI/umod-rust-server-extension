// Reference: NewtonsoftAlias.Json

using System.Collections.Generic;
using System;
using NewtonsoftAlias.Json;
using NewtonsoftAlias.Json.Linq;

namespace Oxide.Ext.GamingApi
{
    public class AccountConverter : JsonConverter<Account>
    {
        public override void WriteJson(JsonWriter writer, Account value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());

            JObject jo = new JObject();
            if (value.PackageId != null)
            {
                jo.Add("id", JToken.FromObject(value.PackageId, serializer));
            }
            jo.WriteTo(writer);
        }

        public override Account ReadJson(JsonReader reader, Type objectType, Account existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            Account acc = new Account();
            acc.PackageId = "test";
            return acc;
        }
    }

    public class Account
    {
        public string PackageId { get; set; }
    }
}