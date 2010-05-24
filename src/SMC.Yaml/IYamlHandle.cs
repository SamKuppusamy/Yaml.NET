namespace SMC.Yaml
{
    public interface IYamlHandle
    {
        string Handle { get; }
        string Prefix { get; set; }
    }
}