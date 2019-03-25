using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        public ITrie Add(string s)
        {
            if (s == "")
            {
                ITrie child = new TrieWithOneChild(s, true);
                return child;
            }
            if(s[0] != _childLabel)
            {
                ITrie newTrie = new TrieWithManyChildren(s, _hasEmptyString, _childLabel, _children[_childLabel - 'a']);
                return newTrie;
            }
            else
            {
                //replace the child?
                _children[_childLabel - 'a'].Add(s.Substring(1));
                return this;
            }

        }

        public bool Contains(string s)
        {
            if(_childLabel == s[0])
            {
                Contains(s.Substring(1));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// The children of this node.
        /// </summary>
        private ITrie[] _children = new ITrie[26];

        /// <summary>
        /// Holds the childs label
        /// </summary>
        private char _childLabel;

        public TrieWithOneChild(string s, bool hasEmpty)
        {
            
            if ( s == "")
            {
                throw new ArgumentException();
            }
            if(s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _childLabel = s[0];
            _hasEmptyString = hasEmpty;
            _children[_childLabel - 'a'] = new TrieWithNoChildren().Add(s.Substring(1));
            //Add(s);
        }
    }
}
