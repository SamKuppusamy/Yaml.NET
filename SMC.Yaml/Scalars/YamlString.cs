using System;

namespace SMC.Yaml.Scalars
{
    public class YamlString : YamlScalar<string>
    {
        public override YamlTag Tag
        {
            get { throw new NotImplementedException(); }
        }
    }
}