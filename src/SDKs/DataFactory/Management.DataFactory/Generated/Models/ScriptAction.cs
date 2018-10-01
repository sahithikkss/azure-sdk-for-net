// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.DataFactory.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Custom script action to run on HDI ondemand cluster once it's up.
    /// </summary>
    public partial class ScriptAction
    {
        /// <summary>
        /// Initializes a new instance of the ScriptAction class.
        /// </summary>
        public ScriptAction()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ScriptAction class.
        /// </summary>
        /// <param name="name">The user provided name of the script
        /// action.</param>
        /// <param name="uri">The URI for the script action.</param>
        /// <param name="roles">The node types on which the script action
        /// should be executed.</param>
        /// <param name="parameters">The parameters for the script
        /// action.</param>
        public ScriptAction(string name, string uri, object roles, string parameters = default(string))
        {
            Name = name;
            Uri = uri;
            Roles = roles;
            Parameters = parameters;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the user provided name of the script action.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URI for the script action.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the node types on which the script action should be
        /// executed.
        /// </summary>
        [JsonProperty(PropertyName = "roles")]
        public object Roles { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the script action.
        /// </summary>
        [JsonProperty(PropertyName = "parameters")]
        public string Parameters { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (Uri == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Uri");
            }
            if (Roles == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Roles");
            }
        }
    }
}
