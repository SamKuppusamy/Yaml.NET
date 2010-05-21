using System;

namespace SMC.Yaml
{
    public class YamlDocument : IYamlDocument
    {
        public YamlDocument()
        {
            Handles = new YamlHandleCollection();
            Tags = new YamlTagCollection();
        }

        public YamlHandleCollection Handles { get; private set; }

        public YamlTagCollection Tags { get; private set; }

        public YamlTag Tag
        {
            get { throw new NotImplementedException(); }
        }
    }
}