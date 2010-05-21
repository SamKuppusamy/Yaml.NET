using System.Collections.Generic;
using System.IO;

namespace SMC.Yaml.Schemas
{
    public abstract class YamlSchema : IYamlSchema
    {
        protected YamlSchema()
        {
            DefaultTags = new YamlTagCollection();
        }

        public IEnumerable<YamlDocument> ParseStream(Stream inputStream)
        {
            PopulateDefaultTags();

            yield return new YamlDocument();

            yield break;
        }
        
        protected static readonly YamlHandle DefaultSecondary = new YamlHandle( "!!", "tag:yaml.org,2002:" );
        public YamlTagCollection DefaultTags { get; private set; }
        protected abstract void PopulateDefaultTags();
    }
}