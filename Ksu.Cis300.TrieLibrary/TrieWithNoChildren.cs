/* TrieWithNoChildren.cs
 * Author: Antonio Carter
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        private bool _hasEmpty;

        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmpty = true;
                //ITrie child = new TrieWithOneChild(s, _hasEmpty);
                return this;
            }
            else
            {
                ITrie child = new TrieWithOneChild(s, _hasEmpty);
                return child;
            }
        }

        public bool Contains(string s)
        {
            if(s == "")
            {
                return _hasEmpty;
            }
            return false;
        }
    }
}
