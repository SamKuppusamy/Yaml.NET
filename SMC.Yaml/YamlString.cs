using System;

namespace SMC.Yaml
{
    public class YamlString : YamlScalar
    {
        public override YamlTag Tag
        {
            get { throw new NotImplementedException(); }
        }
    }
}