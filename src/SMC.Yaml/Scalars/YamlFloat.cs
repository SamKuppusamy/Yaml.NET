using System;

namespace SMC.Yaml.Scalars
{
    public class YamlFloat : YamlScalar<double>
    {
        public override YamlTag Tag
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsNaN { get; set; }
        public bool IsNegativeInfinity { get; set; }
        public bool IsInfinity { get; set; }
    }
}