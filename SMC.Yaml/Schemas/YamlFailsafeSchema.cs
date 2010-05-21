namespace SMC.Yaml.Schemas
{
    public class YamlFailsafeSchema : YamlSchema
    {
        protected override void PopulateDefaultTags()
        {
            // Maps to a YamlMapping object
            DefaultTags.Add( new YamlTag( DefaultSecondary, "map" ) );

            // Maps to a YamlSequence object
            DefaultTags.Add( new YamlTag( DefaultSecondary, "seq" ) );

            // Maps to a YamlString object
            DefaultTags.Add( new YamlTag( DefaultSecondary, "str" ) );    
        }
    }
}