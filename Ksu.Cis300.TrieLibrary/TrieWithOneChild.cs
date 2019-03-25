using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmptyString = false;

        /// <summary>
        /// The child of this node.
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// The child's label
        /// </summary>
        private char _label;

        /// <summary>
        /// Consturcts a new trie node with one child by adding a string
        /// </summary>
        /// <param name="s">string to add</param>
        /// <param name="empty">Whether the empty string is to be included</param>
        public TrieWithOneChild(string s, bool empty)
        {
            if(s.Equals("") || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _hasEmptyString = empty;
            _label = s[0];
            _child = new TrieWithNoChildren().Add(s.Substring(1));
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        /// <returns>A new trie with the given string added</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else if (_label == s[0])
            {
                _child = _child.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _label, _child);
            }
        }

        /// <summary>
        /// Gets whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if(s.Equals(""))
            {
                return _hasEmptyString;
            }
            else if(s[0] == _label)
            {
                return (_child.Contains(s.Substring(1)));
            }
            else
            {
                return false;
            }
        }
    }
}
