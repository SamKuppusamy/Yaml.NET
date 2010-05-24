using System.Collections.Generic;
using System.IO;

namespace SMC.Yaml.Schemas
{
    public interface IYamlSchema {
        IEnumerable<YamlDocument> ParseStream(Stream inputStream);
        YamlTagCollection DefaultTags { get; }
    }
}