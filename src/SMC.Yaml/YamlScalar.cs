namespace SMC.Yaml
{
    public abstract class YamlScalar<T> : IYamlNode
    {
        public T Value
        {
            get;
            set;
        }
        
        public static IYamlNode Null
        {
            get { return null; }
        }

        #region Implementation of IYamlNode

        public abstract YamlTag Tag { get; }

        #endregion
    }
}