using System;

namespace SMC.Yaml.Scalars
{
    public class YamlInteger : YamlScalar<int>
    {
        public override YamlTag Tag
        {
            get { throw new NotImplementedException(); }
        }
    }
}