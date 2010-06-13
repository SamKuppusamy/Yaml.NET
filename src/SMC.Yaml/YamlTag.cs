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

namespace SMC.Yaml
{
    public class YamlTag
    {
        public YamlTag( YamlHandle handle, string tag )
        {
            Handle = handle;
            Tag = tag;
        }

        public YamlHandle Handle { get; private set; }
        public string Tag { get; private set; }

        public string VerbatimTag
        {
            get { return string.Format( "!<{0}{1}>", Handle.Prefix, Tag ); }
        }

        public string AbbreviatedTag
        {
            get { return string.Format( "{0}{1}", Handle.Handle, Tag ); }
        }
    }
}