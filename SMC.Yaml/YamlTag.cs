namespace SMC.Yaml
{
    public class YamlTag
    {
        public YamlTag(string handle, string prefix)
        {
            Handle = handle;
            Prefix = prefix;
        }

        public string Handle { get; private set; }

        public string Prefix { get; private set; }
    }
}