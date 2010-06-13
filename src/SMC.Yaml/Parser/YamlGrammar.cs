#region Copyright

// This file is part of Yaml.NET.
// 
// Yaml.NET is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Yaml.NET is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with Yaml.NET.  If not, see <http://www.gnu.org/licenses/>.
//  
// Copyright 2010, Stephen Michael Czetty

#endregion

using Irony.Parsing;

namespace SMC.Yaml.Parser
{
    [ Language( "Yaml", "1.2", "Grammar for Yaml Specification 1.2" ) ]
    public class YamlGrammar : Grammar
    {
        public YamlGrammar()
        {
            #region Terminals

            // ReSharper disable InconsistentNaming

            var unsigned_number = new NumberLiteral( "Unsigned Number" );
            var yaml_integer = new NumberLiteral( "Integer", NumberOptions.IntOnly | NumberOptions.AllowSign );
            var yaml_float = new NumberLiteral( "Float", NumberOptions.AllowSign );
            var eol = new NewLineTerminal( "Eol" );
            var yaml_tag_handle_named_identifier = new StringLiteral( "Named Tag Handle", "!", StringOptions.NoEscapes );
            KeyTerm bang = ToTerm( "!" );
            KeyTerm bangbang = ToTerm( "!!" );
            var yaml_tag_prefix = new IdentifierTerminal( "Tag Prefix" );
            yaml_tag_prefix.AddPrefix( "!", IdOptions.NameIncludesPrefix );
            KeyTerm yaml_null = ToTerm( "null" );
            KeyTerm comma = ToTerm( "," );

            #endregion

            #region Non-Terminals

            // Documents
            var yaml_document_list = new NonTerminal( "Document List" );
            var yaml_document = new NonTerminal( "Document" );
            var yaml_document_end = new NonTerminal( "Document End" );

            // Directives
            var yaml_directives = new NonTerminal( "Directives" );
            var yaml_directive_list = new NonTerminal( "Directive List" );
            var yaml_directive = new NonTerminal( "Directive" );
            var yaml_directive_yaml = new NonTerminal( "Yaml Directive" );
            var yaml_directive_tag_list = new NonTerminal( "Tag List" );
            var yaml_directive_tag = new NonTerminal( "Tag Directive" );

            // Tags
            var yaml_tag_handle = new NonTerminal( "Tag Handle" );

            // Document Content
            var yaml_document_content_list = new NonTerminal( "Document Content List" );
            var yaml_document_content = new NonTerminal( "Document Content" );
            var yaml_scalar = new NonTerminal( "Scalar" );
            var yaml_map = new NonTerminal( "Map" );
            var yaml_map_content_list = new NonTerminal( "Map Content List" );
            var yaml_map_content = new NonTerminal( "Map content" );
            var yaml_list = new NonTerminal( "List" );
            var yaml_list_content = new NonTerminal( "List Content" );

            // Strings
            var yaml_string = new NonTerminal( "String" );

            // Boolean
            var yaml_boolean = new NonTerminal( "Boolean" );

            // ReSharper restore InconsistentNaming

            #endregion

            #region Rules

            Root = yaml_document_list;

            // Documents
            yaml_document_list.Rule = MakePlusRule( yaml_document_list, yaml_document_end, yaml_document,
                                                    TermListOptions.AllowTrailingDelimiter );
            yaml_document.Rule = yaml_directives + yaml_document_content_list;
            yaml_document_end.Rule = LineStartTerminal + "...";

            // Directives
            yaml_directives.Rule = yaml_directive_list + LineStartTerminal + "---" + eol | Empty;
            yaml_directive_list.Rule = MakeStarRule( yaml_directive_list, eol, yaml_directive );
            yaml_directive.Rule = yaml_directive_yaml | yaml_directive_tag;
            yaml_directive_yaml.Rule = "%YAML" + unsigned_number;
            yaml_directive_tag_list.Rule = MakeStarRule( yaml_directive_tag_list, eol, yaml_directive_tag );
            yaml_directive_tag.Rule = "%TAG" + yaml_tag_handle + yaml_tag_prefix;

            // Tags
            yaml_tag_handle.Rule = bang | bangbang | yaml_tag_handle_named_identifier;

            // Document Content
            yaml_document_content_list.Rule = MakeStarRule( yaml_document_content_list, eol, yaml_document_content,
                                                            TermListOptions.AllowTrailingDelimiter );
            yaml_document_content.Rule = yaml_scalar | yaml_map | yaml_list;

            // Scalars
            yaml_scalar.Rule = yaml_boolean | yaml_integer | yaml_float | yaml_string | yaml_null;

            // Maps
            yaml_map.Rule = "{" + yaml_map_content_list + "}";
            yaml_map_content_list.Rule = MakeStarRule( yaml_map_content_list, Eos, yaml_map_content,
                                                       TermListOptions.AllowTrailingDelimiter );
            yaml_map_content.Rule = yaml_scalar + ":" + yaml_document_content;

            // Lists
            yaml_list.Rule = "[" + yaml_list_content + "]";
            yaml_list_content.Rule = MakeStarRule( yaml_list_content, comma, yaml_document_content );

            // Boolean
            yaml_boolean.Rule = ToTerm( "true" ) | "false";

            // String
            yaml_string.Rule = Empty; // TODO: String rule

            #endregion
        }

        public override void CreateTokenFilters( LanguageData language, TokenFilterList filters )
        {
            filters.Add( new CodeOutlineFilter( language.GrammarData, OutlineOptions.ProduceIndents, null ) );
        }
    }
}