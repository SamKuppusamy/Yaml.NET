using System;

namespace SMC.Yaml.Schemas
{
    internal class YamlFailsafeSchema : YamlSchema
    {
        public YamlFailsafeSchema()
        {
            PopulateDefaultTags();
        }

        protected void PopulateDefaultTags()
        {
            // Maps to a YamlMapping object
            DefaultTags.Add( new YamlTag( DefaultSecondary, "map" ) );

            // Maps to a YamlSequence object
            DefaultTags.Add( new YamlTag( DefaultSecondary, "seq" ) );

            // Maps to a YamlString object
            DefaultTags.Add( new YamlTag( DefaultSecondary, "str" ) );    
        }

        public override YamlTag ResolveTag(string yamlToken)
        {
            throw new NotImplementedException();
        }
    }
}