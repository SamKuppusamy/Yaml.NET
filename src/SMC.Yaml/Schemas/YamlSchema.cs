namespace SMC.Yaml.Schemas
{
    internal abstract class YamlSchema : IYamlSchema
    {
        protected YamlSchema()
        {
            DefaultTags = new YamlTagCollection();
        }
        
        protected static readonly YamlHandle DefaultSecondary = new YamlHandle( "!!", "tag:yaml.org,2002:" );

        public abstract YamlTag ResolveTag(string yamlToken);
        public YamlTagCollection DefaultTags { get; private set; }
    }
}