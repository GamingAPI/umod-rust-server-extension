// Reference: NewtonsoftAlias.Json

using System.Collections.Generic;
using NewtonsoftAlias.Json;
using NewtonsoftAlias.Json.Linq;
using System.Linq;
using System.Reflection;

namespace Oxide.Ext.GamingApi
{

  [JsonConverter(typeof(PlayerConverter))]
  public class Player
  {
    private string id;
    private string name;
    private string address;
    private Dictionary<string, dynamic> additionalProperties;

    public string Id 
    {
      get { return id; }
      set { id = value; }
    }

    public string Name 
    {
      get { return name; }
      set { name = value; }
    }

    public string Address 
    {
      get { return address; }
      set { address = value; }
    }

    public Dictionary<string, object> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  public class PlayerConverter : JsonConverter<Player>
  {
    public override Player ReadJson(JsonReader reader, System.Type objectType, Player existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    Player value = new Player();
    return value;
  }
    public override void WriteJson(JsonWriter writer, Player value, JsonSerializer serializer)
        {
            JObject jo = new JObject();
            if (value.Id != null)
            {
            jo.Add("id", JToken.FromObject(value.Id, serializer));
            }
            if (value.Name != null)
            {
            jo.Add("name", JToken.FromObject(value.Name, serializer));
            }
            if (value.Address != null)
            {
            jo.Add("address", JToken.FromObject(value.Address, serializer));
            }
            if (value.AdditionalProperties != null)
            {
                 for (int index = 0; index < value.AdditionalProperties.Count; index++)
                {
                    KeyValuePair<string, object> unwrapProperty = value.AdditionalProperties.ElementAt(index);
                    if (unwrapProperty.Key != null && unwrapProperty.Value != null)
                    {
                        if (!jo.ContainsKey(unwrapProperty.Key))
                        {
                            jo.Add(unwrapProperty.Key, JToken.FromObject(unwrapProperty.Value, serializer));
                        }
                    }
                }
            }

            jo.WriteTo(writer);
        }

        public override bool CanRead => true;
    public override bool CanWrite => true;
  }
}