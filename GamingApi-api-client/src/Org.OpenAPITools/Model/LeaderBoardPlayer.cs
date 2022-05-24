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
    /// LeaderBoardPlayer
    /// </summary>
    [DataContract]
    public partial class LeaderBoardPlayer :  IEquatable<LeaderBoardPlayer>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeaderBoardPlayer" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected LeaderBoardPlayer() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LeaderBoardPlayer" /> class.
        /// </summary>
        /// <param name="rank">rank (required).</param>
        /// <param name="steamId">The player&#39;s steamID64, must be 17 chars long. (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="killCount">killCount (required).</param>
        /// <param name="deathCount">deathCount (required).</param>
        public LeaderBoardPlayer(int rank = default(int), string steamId = default(string), string name = default(string), int killCount = default(int), int deathCount = default(int))
        {
            // to ensure "rank" is required (not null)
            if (rank == null)
            {
                throw new InvalidDataException("rank is a required property for LeaderBoardPlayer and cannot be null");
            }
            else
            {
                this.Rank = rank;
            }
            
            // to ensure "steamId" is required (not null)
            if (steamId == null)
            {
                throw new InvalidDataException("steamId is a required property for LeaderBoardPlayer and cannot be null");
            }
            else
            {
                this.SteamId = steamId;
            }
            
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for LeaderBoardPlayer and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            
            // to ensure "killCount" is required (not null)
            if (killCount == null)
            {
                throw new InvalidDataException("killCount is a required property for LeaderBoardPlayer and cannot be null");
            }
            else
            {
                this.KillCount = killCount;
            }
            
            // to ensure "deathCount" is required (not null)
            if (deathCount == null)
            {
                throw new InvalidDataException("deathCount is a required property for LeaderBoardPlayer and cannot be null");
            }
            else
            {
                this.DeathCount = deathCount;
            }
            
        }
        
        /// <summary>
        /// Gets or Sets Rank
        /// </summary>
        [DataMember(Name="rank", EmitDefaultValue=true)]
        public int Rank { get; set; }

        /// <summary>
        /// The player&#39;s steamID64, must be 17 chars long.
        /// </summary>
        /// <value>The player&#39;s steamID64, must be 17 chars long.</value>
        [DataMember(Name="steam_id", EmitDefaultValue=true)]
        public string SteamId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets KillCount
        /// </summary>
        [DataMember(Name="kill_count", EmitDefaultValue=true)]
        public int KillCount { get; set; }

        /// <summary>
        /// Gets or Sets DeathCount
        /// </summary>
        [DataMember(Name="death_count", EmitDefaultValue=true)]
        public int DeathCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LeaderBoardPlayer {\n");
            sb.Append("  Rank: ").Append(Rank).Append("\n");
            sb.Append("  SteamId: ").Append(SteamId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  KillCount: ").Append(KillCount).Append("\n");
            sb.Append("  DeathCount: ").Append(DeathCount).Append("\n");
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
            return this.Equals(input as LeaderBoardPlayer);
        }

        /// <summary>
        /// Returns true if LeaderBoardPlayer instances are equal
        /// </summary>
        /// <param name="input">Instance of LeaderBoardPlayer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LeaderBoardPlayer input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Rank == input.Rank ||
                    (this.Rank != null &&
                    this.Rank.Equals(input.Rank))
                ) && 
                (
                    this.SteamId == input.SteamId ||
                    (this.SteamId != null &&
                    this.SteamId.Equals(input.SteamId))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.KillCount == input.KillCount ||
                    (this.KillCount != null &&
                    this.KillCount.Equals(input.KillCount))
                ) && 
                (
                    this.DeathCount == input.DeathCount ||
                    (this.DeathCount != null &&
                    this.DeathCount.Equals(input.DeathCount))
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
                if (this.Rank != null)
                    hashCode = hashCode * 59 + this.Rank.GetHashCode();
                if (this.SteamId != null)
                    hashCode = hashCode * 59 + this.SteamId.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.KillCount != null)
                    hashCode = hashCode * 59 + this.KillCount.GetHashCode();
                if (this.DeathCount != null)
                    hashCode = hashCode * 59 + this.DeathCount.GetHashCode();
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

            
            // SteamId (string) pattern
            Regex regexSteamId = new Regex(@"^[0-9]{17}$", RegexOptions.CultureInvariant);
            if (false == regexSteamId.Match(this.SteamId).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SteamId, must match a pattern of " + regexSteamId, new [] { "SteamId" });
            }

            yield break;
        }
    }

}