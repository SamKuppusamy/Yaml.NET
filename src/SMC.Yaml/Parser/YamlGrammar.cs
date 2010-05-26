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
            var documentList = new NonTerminal("DocumentList");
            var document = new NonTerminal("Document");

            // Directives
            var directiveList = new NonTerminal("DirectiveList");
            var directive = new NonTerminal("Directive");
            var yamlDirective = new NonTerminal("YamlDirective");
            var tagDirectiveList = new NonTerminal("TagDirectiveList");
            var tagDirective = new NonTerminal("TagDirective");

            
            // Rules
            // Root
            Root = stream;

            // Stream
            stream.Rule = MakeStarRule(documentList, document);

            // Documents
            document.Rule = MakeStarRule(directiveList, directive);
        }
    }
}