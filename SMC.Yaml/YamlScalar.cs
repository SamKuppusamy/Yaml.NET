namespace SMC.Yaml
{
    public abstract class YamlScalar : IYamlNode
    {
        
        public static IYamlNode Null
        {
            get { return null; }
        }

        #region Implementation of IYamlNode

        public abstract YamlTag Tag { get; }

        #endregion
    }
}