using System;
using System.Collections.Generic;

namespace Implement_Trie__Prefix_Tree_
{
    class Program
    {
        public class Trie
        {
            public TrieNode root;
            public class TrieNode
            {
                public string Val;
                public Dictionary<char, TrieNode> children;
                public bool isWord;
                public TrieNode()
                {
                    children = new Dictionary<char, TrieNode>();
                    isWord = false;
                }
            }
            public Trie()
            {
                root = new TrieNode();
            }

            public void Insert(string word)
            {
                TrieNode current = root;
                foreach(char c in word)
                {
                    TrieNode node;
                    current.children.TryGetValue(c, out node);
                    if (node== null)
                    {
                        node = new TrieNode();
                        current.children[c] = node;
                        current.Val = current.Val == "" ? c.ToString() : current.Val + c.ToString();
                    }
                    current = node;
                }
                current.isWord = true;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                TrieNode current = root;
                foreach(char c in word)
                {
                    TrieNode node;
                    current.children.TryGetValue(c, out node);
                    if (node == null) return false;
                    current = node;
                }
                return current.isWord;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                TrieNode current = root;
                foreach(char c in prefix)
                {
                    TrieNode node;
                    current.children.TryGetValue(c, out node);
                    if (node == null) return false;
                    current = node;
                }
                return true;
            }
        }

        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Insert("apple");
            Console.WriteLine("Inserted apple");
            Console.WriteLine("apple found = {0}", trie.Search("apple"));
            Console.WriteLine("app found = {0}", trie.Search("app"));
            Console.WriteLine("starts with app = {0}", trie.StartsWith("app"));
            trie.Insert("app");
            Console.WriteLine("Inserted app");
            Console.WriteLine("app found = {0}", trie.Search("app"));
            trie.Insert("abcd");
            trie.Insert("abgl");
            trie.Insert("cdf");
            trie.Insert("abcde");
            trie.Insert("lmn");
        }
    }
}
