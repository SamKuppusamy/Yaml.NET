namespace SMC.Yaml
{
    public interface IYamlDocument : IYamlNode
    {
        YamlHandleCollection Handles { get; }
        YamlTagCollection Tags { get; }
    }
}