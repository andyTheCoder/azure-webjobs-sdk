﻿using Newtonsoft.Json;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.Jobs.Protocols
#else
namespace Microsoft.Azure.Jobs.Host.Protocols
#endif
{
    /// <summary>Represents a parameter to an Azure Jobs function.</summary>
    [JsonConverter(typeof(ParameterDescriptorConverter))]
#if PUBLICPROTOCOL
    public class ParameterDescriptor
#else
    internal class ParameterDescriptor
#endif
    {
        /// <summary>Gets or sets the parameter type.</summary>
        public string Type { get; set; }

        private class ParameterDescriptorConverter : PolymorphicJsonConverter
        {
            public ParameterDescriptorConverter()
                : base("Type", PolymorphicJsonConverter.GetTypeMapping<ParameterDescriptor>())
            {
            }
        }
    }
}