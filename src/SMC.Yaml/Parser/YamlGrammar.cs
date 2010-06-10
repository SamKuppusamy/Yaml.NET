using Irony.Parsing;

namespace SMC.Yaml.Parser
{
    [Language("Yaml", "1.2", "Grammar for Yaml Specification 1.2")]
    public class YamlGrammar : Grammar
    {
        public YamlGrammar()
        {
            // Terminals
// ReSharper disable InconsistentNaming
            var unsigned_number = new NumberLiteral("Unsigned Number");
            var eol = new NewLineTerminal("Eol");
            var yaml_tag_handle_named_identifier = new StringLiteral("Named Tag Handle", "!", StringOptions.NoEscapes);
            var bang = ToTerm("!");
            var bangbang = ToTerm("!!");
            var yaml_tag_prefix = new IdentifierTerminal("Tag Prefix");
            yaml_tag_prefix.AddPrefix("!", IdOptions.NameIncludesPrefix);

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

            // Document Content
            var yaml_document_content_list = new NonTerminal("Document Content List");
            var yaml_document_content = new NonTerminal("Document Content");

// ReSharper restore InconsistentNaming
            // Rules
            Root = yaml_document_list;

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
            yaml_tag_handle.Rule = bang | bangbang | yaml_tag_handle_named_identifier;

            // Document Content
            yaml_document_content_list.Rule = MakeStarRule(yaml_document_content_list, eol, yaml_document_content);

            // TODO: yaml_document_content
        }

        public override void CreateTokenFilters(LanguageData language, TokenFilterList filters)
        {
            filters.Add(new CodeOutlineFilter(language.GrammarData, OutlineOptions.ProduceIndents, null));
        }
    }
}
