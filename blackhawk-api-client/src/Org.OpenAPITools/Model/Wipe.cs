/* 
 * Blackhawk API
 *
 * Blackhawk API for the rust server
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
    /// Wipe
    /// </summary>
    [DataContract]
    public partial class Wipe :  IEquatable<Wipe>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Wipe" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Wipe() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Wipe" /> class.
        /// </summary>
        /// <param name="wipeId">wipeId (required).</param>
        /// <param name="wipeStart">wipeStart (required).</param>
        /// <param name="wipeEnd">wipeEnd.</param>
        public Wipe(int wipeId = default(int), DateTime wipeStart = default(DateTime), DateTime wipeEnd = default(DateTime))
        {
            // to ensure "wipeId" is required (not null)
            if (wipeId == null)
            {
                throw new InvalidDataException("wipeId is a required property for Wipe and cannot be null");
            }
            else
            {
                this.WipeId = wipeId;
            }
            
            // to ensure "wipeStart" is required (not null)
            if (wipeStart == null)
            {
                throw new InvalidDataException("wipeStart is a required property for Wipe and cannot be null");
            }
            else
            {
                this.WipeStart = wipeStart;
            }
            
            this.WipeEnd = wipeEnd;
        }
        
        /// <summary>
        /// Gets or Sets WipeId
        /// </summary>
        [DataMember(Name="wipe_id", EmitDefaultValue=true)]
        public int WipeId { get; set; }

        /// <summary>
        /// Gets or Sets WipeStart
        /// </summary>
        [DataMember(Name="wipe_start", EmitDefaultValue=true)]
        public DateTime WipeStart { get; set; }

        /// <summary>
        /// Gets or Sets WipeEnd
        /// </summary>
        [DataMember(Name="wipe_end", EmitDefaultValue=false)]
        public DateTime WipeEnd { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Wipe {\n");
            sb.Append("  WipeId: ").Append(WipeId).Append("\n");
            sb.Append("  WipeStart: ").Append(WipeStart).Append("\n");
            sb.Append("  WipeEnd: ").Append(WipeEnd).Append("\n");
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
            return this.Equals(input as Wipe);
        }

        /// <summary>
        /// Returns true if Wipe instances are equal
        /// </summary>
        /// <param name="input">Instance of Wipe to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Wipe input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.WipeId == input.WipeId ||
                    (this.WipeId != null &&
                    this.WipeId.Equals(input.WipeId))
                ) && 
                (
                    this.WipeStart == input.WipeStart ||
                    (this.WipeStart != null &&
                    this.WipeStart.Equals(input.WipeStart))
                ) && 
                (
                    this.WipeEnd == input.WipeEnd ||
                    (this.WipeEnd != null &&
                    this.WipeEnd.Equals(input.WipeEnd))
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
                if (this.WipeId != null)
                    hashCode = hashCode * 59 + this.WipeId.GetHashCode();
                if (this.WipeStart != null)
                    hashCode = hashCode * 59 + this.WipeStart.GetHashCode();
                if (this.WipeEnd != null)
                    hashCode = hashCode * 59 + this.WipeEnd.GetHashCode();
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
            yield break;
        }
    }

}
