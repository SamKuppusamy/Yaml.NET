namespace SMC.Yaml
{
    public class YamlAnchor
    {
        public YamlAnchor(string anchor, IYamlNode node)
        {
            Anchor = anchor;
            Node = node;
        }

        public IYamlNode Node { get; private set; }
        public string Anchor { get; private set; }
    }
}