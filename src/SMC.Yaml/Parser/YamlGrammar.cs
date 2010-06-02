using Irony.Parsing;

namespace SMC.Yaml.Parser
{
    public class YamlGrammar : Grammar
    {
        public YamlGrammar()
        {
            // Terminals
// ReSharper disable InconsistentNaming
            var unsigned_number = new NumberLiteral("Unsigned Number");
            var eol = new NewLineTerminal("Eol");
            var tag_identifier = new IdentifierTerminal("Tag Identifier");
            var bang = ToTerm("!");
            var bangbang = ToTerm("!!");

            // Non-Terminals

            // Documents
            var yaml_document_list = new NonTerminal("Document List");
            var yaml_document = new NonTerminal("Document");
            var yaml_document_end = new NonTerminal("Document End");

            // Directives
            var yaml_directives = new NonTerminal("Directives");
            var yaml_directive_list = new NonTerminal("Directive List");
            var yaml_directive = new NonTerminal("Directive");
            var yaml_directive_yaml = new NonTerminal("Yaml Directive");
            var yaml_directive_tag_list = new NonTerminal("Tag List");
            var yaml_directive_tag = new NonTerminal("Tag Directive");

            // Tags
            var yaml_tag_handle = new NonTerminal("Tag Handle");
            var yaml_tag_prefix = new NonTerminal("Tag Prefix");

            // Document Content
            var yaml_document_content_list = new NonTerminal("Document Content List");
            var yaml_document_content = new NonTerminal("Document Content");

// ReSharper restore InconsistentNaming
            // Rules

            // Documents
            yaml_document_list.Rule = MakePlusRule(yaml_document_list, yaml_document_end, yaml_document, TermListOptions.AllowTrailingDelimiter);
            yaml_document.Rule = yaml_directives + yaml_document_content_list;
            yaml_document_end.Rule = LineStartTerminal + "..." | Eof;

            // Directives
            yaml_directives.Rule = yaml_directive_list + "---" + eol | Empty;
            yaml_directive_list.Rule = MakeStarRule(yaml_directive_list, eol, yaml_directive);
            yaml_directive.Rule = yaml_directive_yaml | yaml_directive_tag;
            yaml_directive_yaml.Rule = "%YAML" + unsigned_number;
            yaml_directive_tag_list.Rule = MakeStarRule(yaml_directive_tag_list, eol, yaml_directive_tag);
            yaml_directive_tag.Rule = "%TAG" + yaml_tag_handle + yaml_tag_prefix;

            // Tags
            yaml_tag_handle.Rule = bang | bangbang | bang + tag_identifier + bang; // TODO: How do we force no whitespace?
            yaml_tag_prefix.Rule = bang + tag_identifier | tag_identifier;

            // Document Content
            yaml_document_content_list.Rule = MakeStarRule(yaml_document_content_list, eol, yaml_document_content);

            // TODO: yaml_document_content
        }
    }
}
