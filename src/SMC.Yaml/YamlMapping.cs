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
    public class YamlMapping : IYamlNode, IDictionary< IYamlNode, IYamlNode >
    {
        private readonly IDictionary< IYamlNode, IYamlNode > _internalDictionary =
            new Dictionary< IYamlNode, IYamlNode >();

        #region Implementation of IEnumerable

        /// <summary>
        ///   Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///   A <see cref = "T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator< KeyValuePair< IYamlNode, IYamlNode > > GetEnumerator()
        {
            return _internalDictionary.GetEnumerator();
        }

        /// <summary>
        ///   Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        ///   An <see cref = "T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<KeyValuePair<YamlScalar,YamlNode>>

        /// <summary>
        ///   Adds an item to the <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name = "item">The object to add to the <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </exception>
        public void Add( KeyValuePair< IYamlNode, IYamlNode > item )
        {
            _internalDictionary.Add( item );
        }

        /// <summary>
        ///   Removes all items from the <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only. 
        /// </exception>
        public void Clear()
        {
            _internalDictionary.Clear();
        }

        /// <summary>
        ///   Determines whether the <see cref = "T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <returns>
        ///   true if <paramref name = "item" /> is found in the <see cref = "T:System.Collections.Generic.ICollection`1" />; otherwise, false.
        /// </returns>
        /// <param name = "item">The object to locate in the <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        public bool Contains( KeyValuePair< IYamlNode, IYamlNode > item )
        {
            return _internalDictionary.Contains( item );
        }

        /// <summary>
        ///   Copies the elements of the <see cref = "T:System.Collections.Generic.ICollection`1" /> to an <see cref = "T:System.Array" />, starting at a particular <see cref = "T:System.Array" /> index.
        /// </summary>
        /// <param name = "array">The one-dimensional <see cref = "T:System.Array" /> that is the destination of the elements copied from <see cref = "T:System.Collections.Generic.ICollection`1" />. The <see cref = "T:System.Array" /> must have zero-based indexing.
        /// </param>
        /// <param name = "arrayIndex">The zero-based index in <paramref name = "array" /> at which copying begins.
        /// </param>
        /// <exception cref = "T:System.ArgumentNullException"><paramref name = "array" /> is null.
        /// </exception>
        /// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "arrayIndex" /> is less than 0.
        /// </exception>
        /// <exception cref = "T:System.ArgumentException"><paramref name = "array" /> is multidimensional.
        ///   -or-
        ///   <paramref name = "arrayIndex" /> is equal to or greater than the length of <paramref name = "array" />.
        ///   -or-
        ///   The number of elements in the source <see cref = "T:System.Collections.Generic.ICollection`1" /> is greater than the available space from <paramref name = "arrayIndex" /> to the end of the destination <paramref name = "array" />.
        ///   -or-
        ///   Type <paramref name = "array" /> cannot be cast automatically to the type of the destination <paramref name = "array" />.
        /// </exception>
        public void CopyTo( KeyValuePair< IYamlNode, IYamlNode >[] array, int arrayIndex )
        {
            _internalDictionary.CopyTo( array, arrayIndex );
        }

        /// <summary>
        ///   Removes the first occurrence of a specific object from the <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <returns>
        ///   true if <paramref name = "item" /> was successfully removed from the <see cref = "T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name = "item" /> is not found in the original <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        /// <param name = "item">The object to remove from the <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </exception>
        public bool Remove( KeyValuePair< IYamlNode, IYamlNode > item )
        {
            return _internalDictionary.Remove( item );
        }

        /// <summary>
        ///   Gets the number of elements contained in the <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <returns>
        ///   The number of elements contained in the <see cref = "T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public int Count
        {
            get { return _internalDictionary.Count; }
        }

        /// <summary>
        ///   Gets a value indicating whether the <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        /// <returns>
        ///   true if the <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region Implementation of IDictionary<YamlScalar,YamlNode>

        /// <summary>
        ///   Determines whether the <see cref = "T:System.Collections.Generic.IDictionary`2" /> contains an element with the specified key.
        /// </summary>
        /// <returns>
        ///   true if the <see cref = "T:System.Collections.Generic.IDictionary`2" /> contains an element with the key; otherwise, false.
        /// </returns>
        /// <param name = "key">The key to locate in the <see cref = "T:System.Collections.Generic.IDictionary`2" />.
        /// </param>
        /// <exception cref = "T:System.ArgumentNullException"><paramref name = "key" /> is null.
        /// </exception>
        public bool ContainsKey( IYamlNode key )
        {
            return _internalDictionary.ContainsKey( key );
        }

        /// <summary>
        ///   Adds an element with the provided key and value to the <see cref = "T:System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <param name = "key">The object to use as the key of the element to add.
        /// </param>
        /// <param name = "value">The object to use as the value of the element to add.
        /// </param>
        /// <exception cref = "T:System.ArgumentNullException"><paramref name = "key" /> is null.
        /// </exception>
        /// <exception cref = "T:System.ArgumentException">An element with the same key already exists in the <see cref = "T:System.Collections.Generic.IDictionary`2" />.
        /// </exception>
        /// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.IDictionary`2" /> is read-only.
        /// </exception>
        public void Add( IYamlNode key, IYamlNode value )
        {
            _internalDictionary.Add( key, value );
        }

        /// <summary>
        ///   Removes the element with the specified key from the <see cref = "T:System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <returns>
        ///   true if the element is successfully removed; otherwise, false.  This method also returns false if <paramref name = "key" /> was not found in the original <see cref = "T:System.Collections.Generic.IDictionary`2" />.
        /// </returns>
        /// <param name = "key">The key of the element to remove.
        /// </param>
        /// <exception cref = "T:System.ArgumentNullException"><paramref name = "key" /> is null.
        /// </exception>
        /// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.IDictionary`2" /> is read-only.
        /// </exception>
        public bool Remove( IYamlNode key )
        {
            return _internalDictionary.Remove( key );
        }

        /// <summary>
        ///   Gets the value associated with the specified key.
        /// </summary>
        /// <returns>
        ///   true if the object that implements <see cref = "T:System.Collections.Generic.IDictionary`2" /> contains an element with the specified key; otherwise, false.
        /// </returns>
        /// <param name = "key">The key whose value to get.
        /// </param>
        /// <param name = "value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name = "value" /> parameter. This parameter is passed uninitialized.
        /// </param>
        /// <exception cref = "T:System.ArgumentNullException"><paramref name = "key" /> is null.
        /// </exception>
        public bool TryGetValue( IYamlNode key, out IYamlNode value )
        {
            return _internalDictionary.TryGetValue( key, out value );
        }

        /// <summary>
        ///   Gets or sets the element with the specified key.
        /// </summary>
        /// <returns>
        ///   The element with the specified key.
        /// </returns>
        /// <param name = "key">The key of the element to get or set.
        /// </param>
        /// <exception cref = "T:System.ArgumentNullException"><paramref name = "key" /> is null.
        /// </exception>
        /// <exception cref = "T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and <paramref name = "key" /> is not found.
        /// </exception>
        /// <exception cref = "T:System.NotSupportedException">The property is set and the <see cref = "T:System.Collections.Generic.IDictionary`2" /> is read-only.
        /// </exception>
        public IYamlNode this[ IYamlNode key ]
        {
            get { return _internalDictionary[ key ]; }
            set { _internalDictionary[ key ] = value; }
        }

        /// <summary>
        ///   Gets an <see cref = "T:System.Collections.Generic.ICollection`1" /> containing the keys of the <see cref = "T:System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <returns>
        ///   An <see cref = "T:System.Collections.Generic.ICollection`1" /> containing the keys of the object that implements <see cref = "T:System.Collections.Generic.IDictionary`2" />.
        /// </returns>
        public ICollection< IYamlNode > Keys
        {
            get { return _internalDictionary.Keys; }
        }

        /// <summary>
        ///   Gets an <see cref = "T:System.Collections.Generic.ICollection`1" /> containing the values in the <see cref = "T:System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <returns>
        ///   An <see cref = "T:System.Collections.Generic.ICollection`1" /> containing the values in the object that implements <see cref = "T:System.Collections.Generic.IDictionary`2" />.
        /// </returns>
        public ICollection< IYamlNode > Values
        {
            get { return _internalDictionary.Values; }
        }

        #endregion

        #region IYamlNode Members

        public YamlTag Tag
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}