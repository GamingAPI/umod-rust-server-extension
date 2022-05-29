/* 
 * GamingEventApi API
 *
 * GamingEventApi API for the rust server
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: jonas-lt@live.dk
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// If player not sat it means the item has not been found yet.
    /// </summary>
    [DataContract]
    public partial class HuntForWeapon :  IEquatable<HuntForWeapon>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HuntForWeapon" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected HuntForWeapon() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="HuntForWeapon" /> class.
        /// </summary>
        /// <param name="playerSteamId">The player&#39;s steamID64, must be 17 chars long..</param>
        /// <param name="playerName">The player name who was the first. .</param>
        /// <param name="pickupTime">The time the item was pickedup..</param>
        /// <param name="connectionTime">The time the player connected to the server..</param>
        /// <param name="itemNotificationId">itemNotificationId (required).</param>
        /// <param name="itemName">Name of the item (required).</param>
        /// <param name="itemType">Type of the item (required).</param>
        public HuntForWeapon(string playerSteamId = default(string), string playerName = default(string), DateTime pickupTime = default(DateTime), DateTime connectionTime = default(DateTime), int itemNotificationId = default(int), string itemName = default(string), string itemType = default(string))
        {
            // to ensure "itemNotificationId" is required (not null)
            if (itemNotificationId == null)
            {
                throw new InvalidDataException("itemNotificationId is a required property for HuntForWeapon and cannot be null");
            }
            else
            {
                this.ItemNotificationId = itemNotificationId;
            }
            
            // to ensure "itemName" is required (not null)
            if (itemName == null)
            {
                throw new InvalidDataException("itemName is a required property for HuntForWeapon and cannot be null");
            }
            else
            {
                this.ItemName = itemName;
            }
            
            // to ensure "itemType" is required (not null)
            if (itemType == null)
            {
                throw new InvalidDataException("itemType is a required property for HuntForWeapon and cannot be null");
            }
            else
            {
                this.ItemType = itemType;
            }
            
            this.PlayerSteamId = playerSteamId;
            this.PlayerName = playerName;
            this.PickupTime = pickupTime;
            this.ConnectionTime = connectionTime;
        }
        
        /// <summary>
        /// The player&#39;s steamID64, must be 17 chars long.
        /// </summary>
        /// <value>The player&#39;s steamID64, must be 17 chars long.</value>
        [DataMember(Name="player_steam_id", EmitDefaultValue=false)]
        public string PlayerSteamId { get; set; }

        /// <summary>
        /// The player name who was the first. 
        /// </summary>
        /// <value>The player name who was the first. </value>
        [DataMember(Name="player_name", EmitDefaultValue=false)]
        public string PlayerName { get; set; }

        /// <summary>
        /// The time the item was pickedup.
        /// </summary>
        /// <value>The time the item was pickedup.</value>
        [DataMember(Name="pickup_time", EmitDefaultValue=false)]
        public DateTime PickupTime { get; set; }

        /// <summary>
        /// The time the player connected to the server.
        /// </summary>
        /// <value>The time the player connected to the server.</value>
        [DataMember(Name="connection_time", EmitDefaultValue=false)]
        public DateTime ConnectionTime { get; set; }

        /// <summary>
        /// Gets or Sets ItemNotificationId
        /// </summary>
        [DataMember(Name="item_notification_id", EmitDefaultValue=true)]
        public int ItemNotificationId { get; set; }

        /// <summary>
        /// Name of the item
        /// </summary>
        /// <value>Name of the item</value>
        [DataMember(Name="item_name", EmitDefaultValue=true)]
        public string ItemName { get; set; }

        /// <summary>
        /// Type of the item
        /// </summary>
        /// <value>Type of the item</value>
        [DataMember(Name="item_type", EmitDefaultValue=true)]
        public string ItemType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HuntForWeapon {\n");
            sb.Append("  PlayerSteamId: ").Append(PlayerSteamId).Append("\n");
            sb.Append("  PlayerName: ").Append(PlayerName).Append("\n");
            sb.Append("  PickupTime: ").Append(PickupTime).Append("\n");
            sb.Append("  ConnectionTime: ").Append(ConnectionTime).Append("\n");
            sb.Append("  ItemNotificationId: ").Append(ItemNotificationId).Append("\n");
            sb.Append("  ItemName: ").Append(ItemName).Append("\n");
            sb.Append("  ItemType: ").Append(ItemType).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as HuntForWeapon);
        }

        /// <summary>
        /// Returns true if HuntForWeapon instances are equal
        /// </summary>
        /// <param name="input">Instance of HuntForWeapon to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HuntForWeapon input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.PlayerSteamId == input.PlayerSteamId ||
                    (this.PlayerSteamId != null &&
                    this.PlayerSteamId.Equals(input.PlayerSteamId))
                ) && 
                (
                    this.PlayerName == input.PlayerName ||
                    (this.PlayerName != null &&
                    this.PlayerName.Equals(input.PlayerName))
                ) && 
                (
                    this.PickupTime == input.PickupTime ||
                    (this.PickupTime != null &&
                    this.PickupTime.Equals(input.PickupTime))
                ) && 
                (
                    this.ConnectionTime == input.ConnectionTime ||
                    (this.ConnectionTime != null &&
                    this.ConnectionTime.Equals(input.ConnectionTime))
                ) && 
                (
                    this.ItemNotificationId == input.ItemNotificationId ||
                    (this.ItemNotificationId != null &&
                    this.ItemNotificationId.Equals(input.ItemNotificationId))
                ) && 
                (
                    this.ItemName == input.ItemName ||
                    (this.ItemName != null &&
                    this.ItemName.Equals(input.ItemName))
                ) && 
                (
                    this.ItemType == input.ItemType ||
                    (this.ItemType != null &&
                    this.ItemType.Equals(input.ItemType))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.PlayerSteamId != null)
                    hashCode = hashCode * 59 + this.PlayerSteamId.GetHashCode();
                if (this.PlayerName != null)
                    hashCode = hashCode * 59 + this.PlayerName.GetHashCode();
                if (this.PickupTime != null)
                    hashCode = hashCode * 59 + this.PickupTime.GetHashCode();
                if (this.ConnectionTime != null)
                    hashCode = hashCode * 59 + this.ConnectionTime.GetHashCode();
                if (this.ItemNotificationId != null)
                    hashCode = hashCode * 59 + this.ItemNotificationId.GetHashCode();
                if (this.ItemName != null)
                    hashCode = hashCode * 59 + this.ItemName.GetHashCode();
                if (this.ItemType != null)
                    hashCode = hashCode * 59 + this.ItemType.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {

            
            // PlayerSteamId (string) pattern
            Regex regexPlayerSteamId = new Regex(@"^[0-9]{17}$", RegexOptions.CultureInvariant);
            if (false == regexPlayerSteamId.Match(this.PlayerSteamId).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PlayerSteamId, must match a pattern of " + regexPlayerSteamId, new [] { "PlayerSteamId" });
            }

            yield break;
        }
    }

}
