namespace SMC.Yaml.Schemas
{
    internal interface IYamlSchema {
        YamlTag ResolveTag(string yamlToken);
        YamlTagCollection DefaultTags { get; }
    }
}