using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Code.ContractResolver
{
    public class IgnorePropertiesContractResolver : DefaultContractResolver
    {
        private readonly List<String> _ignoreColumnsValueZero = new List<string>();

        public IgnorePropertiesContractResolver(List<String> ignoreColumnsValueZero) 
        {
            _ignoreColumnsValueZero = ignoreColumnsValueZero;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if(_ignoreColumnsValueZero.Contains(property.PropertyName.ToString()))
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        var val = property.ValueProvider.GetValue(instance);

                        if (val == "0") 
                        {
                            return false;
                        }
                            
                        return true;
                    };
            }
            return property;
        }
    }
}
