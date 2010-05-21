using System;

namespace SMC.Yaml.Scalars
{
    public class YamlBoolean : YamlScalar<bool>
    {
        public override YamlTag Tag
        {
            get { throw new NotImplementedException(); }
        }
    }
}