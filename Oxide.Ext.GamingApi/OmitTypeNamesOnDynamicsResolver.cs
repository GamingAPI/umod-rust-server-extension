using System;
using System.Reflection;
using NewtonsoftAlias.Json;
using NewtonsoftAlias.Json.Serialization;

namespace Oxide.Ext.GamingApi
{
    public class OmitTypeNamesOnDynamicsResolver : DefaultContractResolver
    {

        public static readonly OmitTypeNamesOnDynamicsResolver Instance = new OmitTypeNamesOnDynamicsResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            if (member.GetCustomAttribute<System.Runtime.CompilerServices.DynamicAttribute>() != null)
            {
                prop.TypeNameHandling = TypeNameHandling.None;
            }
            return prop;
        }
    }
}
