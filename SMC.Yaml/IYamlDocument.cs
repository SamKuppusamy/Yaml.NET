namespace SMC.Yaml
{
    public interface IYamlDocument
    {
        YamlHandleCollection Handles { get; }
        YamlTagCollection Tags { get; }
    }
}