namespace SMC.Yaml
{
    public class YamlTag
    {
        public YamlTag(YamlHandle handle, string tag)
        {
            Handle = handle;
            Tag = tag;
        }

        public YamlHandle Handle { get; private set; }
        public string Tag { get; private set; }

        public string VerbatimTag { get { return string.Format("!<{0}{1}>", Handle.Prefix, Tag); } }

        public string AbbreviatedTag { get { return string.Format("{0}{1}", Handle.Handle, Tag); } }
        }
}