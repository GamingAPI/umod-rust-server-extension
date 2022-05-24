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
    /// CombatKill
    /// </summary>
    [DataContract]
    public partial class CombatKill :  IEquatable<CombatKill>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CombatKill" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CombatKill() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CombatKill" /> class.
        /// </summary>
        /// <param name="victim">The victims&#39;s steamID64, must be 17 chars long. (required).</param>
        /// <param name="killer">The killers&#39;s steamID64, must be 17 chars long. (required).</param>
        /// <param name="assists">assists (required).</param>
        /// <param name="hits">This array list is sorted inverted, so the last hit (kill hit) at index 0, second last hit at index 1, etc (required).</param>
        public CombatKill(string victim = default(string), string killer = default(string), List<string> assists = default(List<string>), List<Hit> hits = default(List<Hit>))
        {
            // to ensure "victim" is required (not null)
            if (victim == null)
            {
                throw new InvalidDataException("victim is a required property for CombatKill and cannot be null");
            }
            else
            {
                this.Victim = victim;
            }
            
            // to ensure "killer" is required (not null)
            if (killer == null)
            {
                throw new InvalidDataException("killer is a required property for CombatKill and cannot be null");
            }
            else
            {
                this.Killer = killer;
            }
            
            // to ensure "assists" is required (not null)
            if (assists == null)
            {
                throw new InvalidDataException("assists is a required property for CombatKill and cannot be null");
            }
            else
            {
                this.Assists = assists;
            }
            
            // to ensure "hits" is required (not null)
            if (hits == null)
            {
                throw new InvalidDataException("hits is a required property for CombatKill and cannot be null");
            }
            else
            {
                this.Hits = hits;
            }
            
        }
        
        /// <summary>
        /// The victims&#39;s steamID64, must be 17 chars long.
        /// </summary>
        /// <value>The victims&#39;s steamID64, must be 17 chars long.</value>
        [DataMember(Name="victim", EmitDefaultValue=true)]
        public string Victim { get; set; }

        /// <summary>
        /// The killers&#39;s steamID64, must be 17 chars long.
        /// </summary>
        /// <value>The killers&#39;s steamID64, must be 17 chars long.</value>
        [DataMember(Name="killer", EmitDefaultValue=true)]
        public string Killer { get; set; }

        /// <summary>
        /// Gets or Sets Assists
        /// </summary>
        [DataMember(Name="assists", EmitDefaultValue=true)]
        public List<string> Assists { get; set; }

        /// <summary>
        /// This array list is sorted inverted, so the last hit (kill hit) at index 0, second last hit at index 1, etc
        /// </summary>
        /// <value>This array list is sorted inverted, so the last hit (kill hit) at index 0, second last hit at index 1, etc</value>
        [DataMember(Name="hits", EmitDefaultValue=true)]
        public List<Hit> Hits { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CombatKill {\n");
            sb.Append("  Victim: ").Append(Victim).Append("\n");
            sb.Append("  Killer: ").Append(Killer).Append("\n");
            sb.Append("  Assists: ").Append(Assists).Append("\n");
            sb.Append("  Hits: ").Append(Hits).Append("\n");
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
            return this.Equals(input as CombatKill);
        }

        /// <summary>
        /// Returns true if CombatKill instances are equal
        /// </summary>
        /// <param name="input">Instance of CombatKill to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CombatKill input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Victim == input.Victim ||
                    (this.Victim != null &&
                    this.Victim.Equals(input.Victim))
                ) && 
                (
                    this.Killer == input.Killer ||
                    (this.Killer != null &&
                    this.Killer.Equals(input.Killer))
                ) && 
                (
                    this.Assists == input.Assists ||
                    this.Assists != null &&
                    input.Assists != null &&
                    this.Assists.SequenceEqual(input.Assists)
                ) && 
                (
                    this.Hits == input.Hits ||
                    this.Hits != null &&
                    input.Hits != null &&
                    this.Hits.SequenceEqual(input.Hits)
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
                if (this.Victim != null)
                    hashCode = hashCode * 59 + this.Victim.GetHashCode();
                if (this.Killer != null)
                    hashCode = hashCode * 59 + this.Killer.GetHashCode();
                if (this.Assists != null)
                    hashCode = hashCode * 59 + this.Assists.GetHashCode();
                if (this.Hits != null)
                    hashCode = hashCode * 59 + this.Hits.GetHashCode();
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

            
            // Victim (string) pattern
            Regex regexVictim = new Regex(@"^[0-9]{17}$", RegexOptions.CultureInvariant);
            if (false == regexVictim.Match(this.Victim).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Victim, must match a pattern of " + regexVictim, new [] { "Victim" });
            }


            
            // Killer (string) pattern
            Regex regexKiller = new Regex(@"^[0-9]{17}$", RegexOptions.CultureInvariant);
            if (false == regexKiller.Match(this.Killer).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Killer, must match a pattern of " + regexKiller, new [] { "Killer" });
            }

            yield break;
        }
    }

}