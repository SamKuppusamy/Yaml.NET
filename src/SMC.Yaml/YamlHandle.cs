namespace SMC.Yaml
{
    public class YamlHandle : IYamlHandle
    {
        internal const string DefaultPrimaryHandle = "!";
        internal const string DefaultPrimaryPrefix = "!";
        internal const string DefaultSecondaryHandle = "!!";
        internal const string DefaultSecondaryPrefix = "tag:yaml.org,2002:";

        public YamlHandle(string handle, string prefix)
        {
            Handle = handle;
            Prefix = prefix;
        }

        public string Handle { get; private set; }

        public string Prefix { get; set; }

        public static YamlHandle NewPrimary()
        {
            return new YamlHandle(DefaultPrimaryHandle, DefaultPrimaryPrefix);
        }

        public static YamlHandle NewSecondary()
        {
            return new YamlHandle(DefaultSecondaryHandle, DefaultSecondaryPrefix);
        }
    }
}