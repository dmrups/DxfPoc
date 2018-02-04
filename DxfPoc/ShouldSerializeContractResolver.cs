using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace DxfPoc
{
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public new static readonly ShouldSerializeContractResolver Instance =
                                      new ShouldSerializeContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member,
                                         MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyName == "Owner"
                || property.PropertyName == "Reactors")
            {
                property.ShouldSerialize = instance =>
                {
                    return false;
                };
            }

            return property;
        }
    }
}
