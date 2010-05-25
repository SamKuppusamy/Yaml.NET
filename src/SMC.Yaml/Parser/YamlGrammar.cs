using Irony.Parsing;

namespace SMC.Yaml.Parser
{
    public class YamlGrammar : Grammar
    {
        public YamlGrammar()
        {
            // Terminals
            // TODO: Figure out the terminals

            // Non-Terminals
            // Stream
            var stream = new NonTerminal("Stream");

            // Document
            var document = new NonTerminal("Document");

            // Directives
            var yamlDirective = new NonTerminal("YamlDirective");
            var tagDirective = new NonTerminal("TagDirective");

            
            // Rules
            // Root
            Root = stream;

            // Stream
            

            // Documents
            
        }
    }
}