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

using System;
using System.Collections;
using System.Collections.Generic;

namespace SMC.Yaml
{
    public class YamlHandleCollection : ICollection< YamlHandle >, IDictionary< string, YamlHandle >
    {
        private readonly IDictionary< string, YamlHandle > _handleDictionary;
        private readonly IDictionary< string, YamlHandle > _prefixDictionary;

        public YamlHandleCollection()
        {
            _handleDictionary = new Dictionary< string, YamlHandle >();
            _prefixDictionary = new Dictionary< string, YamlHandle >();
            AddPrimaryAndSecondaryHandles();
        }

        private void AddPrimaryAndSecondaryHandles()
        {
            Add( YamlHandle.NewPrimary() );
            Add( YamlHandle.NewSecondary() );
        }

        #region Implementation of ICollection<YamlHandle>

        /// <summary>
        ///   Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///   A <see cref = "T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator< YamlHandle > GetEnumerator()
        {
            return _handleDictionary.Values.GetEnumerator();
        }

        /// <summary>
        ///   Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        ///   An <see cref = "T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///   Adds an item to the <see cref = "YamlHandleCollection" />.
        /// </summary>
        /// <param name = "item">The object to add to the <see cref = "YamlHandleCollection" />.</param>
        /// <exception cref = "T:System.NotSupportedException">
        ///   The <see cref = "YamlHandleCollection" /> is read-only.
        /// </exception>
        public void Add( YamlHandle item )
        {
            _handleDictionary.Add( item.Handle, item );
            _prefixDictionary.Add( item.Prefix, item );
        }

        /// <summary>
        ///   Removes all items from the <see cref = "YamlHandleCollection" />, except for the Primary and Secondary tags.
        /// </summary>
        /// <exception cref = "T:System.NotSupportedException">
        ///   The <see cref = "YamlHandleCollection" /> is read-only.
        /// </exception>
        public void Clear()
        {
            _handleDictionary.Clear();
            _prefixDictionary.Clear();
            // Explicitly add Primary and Secondary
            AddPrimaryAndSecondaryHandles();
        }

        /// <summary>
        ///   Determines whether the <see cref = "YamlHandleCollection" /> contains a specific value.
        /// </summary>
        /// <param name = "item">The object to locate in the <see cref = "YamlHandleCollection" />.</param>
        /// <returns>
        ///   true if <paramref name = "item" /> is found in the <see cref = "YamlHandleCollection" />; otherwise, false.
        /// </returns>
        public bool Contains( YamlHandle item )
        {
            return _handleDictionary.ContainsKey( item.Handle );
        }

        /// <summary>
        ///   Copies the elements of the <see cref = "YamlHandleCollection" /> to an <see cref = "T:System.Array" />, starting at a particular <see cref = "T:System.Array" /> index.
        /// </summary>
        /// <param name = "array">The one-dimensional <see cref = "T:System.Array" /> that is the destination of the elements copied from <see cref = "YamlHandleCollection" />. The <see cref = "T:System.Array" /> must have zero-based indexing.</param>
        /// <param name = "arrayIndex">The zero-based index in <paramref name = "array" /> at which copying begins.</param>
        /// <exception cref = "T:System.ArgumentNullException">
        ///   <paramref name = "array" /> is null.
        /// </exception>
        /// <exception cref = "T:System.ArgumentOutOfRangeException">
        ///   <paramref name = "arrayIndex" /> is less than 0.
        /// </exception>
        /// <exception cref = "T:System.ArgumentException">
        ///   <paramref name = "array" /> is multidimensional.
        ///   -or-
        ///   <paramref name = "arrayIndex" /> is equal to or greater than the length of <paramref name = "array" />.
        ///   -or-
        ///   The number of elements in the source <see cref = "YamlHandleCollection" /> is greater than the available space from <paramref name = "arrayIndex" /> to the end of the destination <paramref name = "array" />.
        ///   -or-
        ///   Type <paramref name = "array" /> cannot be cast automatically to the type of the destination <paramref name = "array" />.
        /// </exception>
        public void CopyTo( YamlHandle[] array, int arrayIndex )
        {
            _handleDictionary.Values.CopyTo( array, arrayIndex );
        }

        /// <summary>
        ///   Removes the first occurrence of a specific object from the <see cref = "YamlHandleCollection" />.
        /// </summary>
        /// <param name = "item">The object to remove from the <see cref = "YamlHandleCollection" />.</param>
        /// <returns>
        ///   true if <paramref name = "item" /> was successfully removed from the <see cref = "YamlHandleCollection" />; otherwise, false. This method also returns false if <paramref name = "item" /> is not found in the original <see cref = "YamlHandleCollection" />.
        /// </returns>
        /// <exception cref = "T:System.NotSupportedException">
        ///   The <see cref = "YamlHandleCollection" /> is read-only.
        /// </exception>
        public bool Remove( YamlHandle item )
        {
            if ( item.Handle == YamlHandle.DefaultPrimaryHandle || item.Handle == YamlHandle.DefaultSecondaryHandle )
                return false;

            return _handleDictionary.Remove( item.Handle ) && _prefixDictionary.Remove( item.Prefix );
        }

        /// <summary>
        ///   Gets the number of elements contained in the <see cref = "YamlHandleCollection" />.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///   The number of elements contained in the <see cref = "YamlHandleCollection" />.
        /// </returns>
        public int Count
        {
            get { return _handleDictionary.Count; }
        }

        /// <summary>
        ///   Gets a value indicating whether the <see cref = "YamlHandleCollection" /> is read-only.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref = "YamlHandleCollection" /> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region Implementation of ICollection<KeyValuePair<string, YamlHandle>>

        IEnumerator< KeyValuePair< string, YamlHandle > > IEnumerable< KeyValuePair< string, YamlHandle > >.
            GetEnumerator()
        {
            return _handleDictionary.GetEnumerator();
        }

        [ TerminatesProgram ]
        public void Add( KeyValuePair< string, YamlHandle > item )
        {
            throw new NotSupportedException( "Dictionary is read-only" );
        }

        public bool Contains( KeyValuePair< string, YamlHandle > item )
        {
            return _handleDictionary.Contains( item );
        }

        public void CopyTo( KeyValuePair< string, YamlHandle >[] array, int arrayIndex )
        {
            _handleDictionary.CopyTo( array, arrayIndex );
        }

        [ TerminatesProgram ]
        public bool Remove( KeyValuePair< string, YamlHandle > item )
        {
            throw new NotSupportedException( "Dictionary is read-only" );
        }

        bool ICollection< KeyValuePair< String, YamlHandle > >.IsReadOnly
        {
            get { return true; }
        }

        #endregion

        #region Implementation of IDictionary<string,YamlHandle>

        public bool ContainsKey( string key )
        {
            return _handleDictionary.ContainsKey( key ) || _prefixDictionary.ContainsKey( key );
        }

        [ TerminatesProgram ]
        public void Add( string key, YamlHandle value )
        {
            throw new NotSupportedException( "Dictionary is read-only" );
        }

        [ TerminatesProgram ]
        public bool Remove( string key )
        {
            throw new NotSupportedException( "Dictionary is read-only" );
        }

        public bool TryGetValue( string key, out YamlHandle value )
        {
            return _handleDictionary.TryGetValue( key, out value ) || _prefixDictionary.TryGetValue( key, out value );
        }

        public YamlHandle this[ string key ]
        {
            get { return _handleDictionary.ContainsKey( key ) ? _handleDictionary[ key ] : _prefixDictionary[ key ]; }
            [ TerminatesProgram ]
            set { throw new NotSupportedException( "Dictionary is read-only" ); }
        }

        public ICollection< string > Keys
        {
            get { return _handleDictionary.Keys; }
        }

        public ICollection< YamlHandle > Values
        {
            get { return this; }
        }

        #endregion
    }
}