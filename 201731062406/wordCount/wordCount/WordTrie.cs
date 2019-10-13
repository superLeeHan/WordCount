using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordCount
{
    class WordTrie
    {
        //Trie树节点
        private class TrieNode
        {
            public int PrefixNum = 0;  //前缀词频
            public int WordNum = 0;  //词频
            public Dictionary<char, TrieNode> Sons = new Dictionary<char, TrieNode>();  //子节点
            public bool IsEnd = false;  //是否可为终节点
            public char Val;  //节点值
            public string Word = null;  //单词值
            //构造函数
            public TrieNode() { }
            public TrieNode(char val)
            {
                Val = val;
            }
        }

        private TrieNode _Root = new TrieNode();

        //所有单词词频总和
        public int CountSum
        {
            get { return _Root.PrefixNum; }
        }

        //插入单词
        public void Insert(string word)
        {
            if (string.IsNullOrEmpty(word)) return;
            TrieNode node = _Root;
            node.PrefixNum++;
            for (int i = 0, len = word.Length; i < len; i++)
            {
                char pos = word[i];
                if (!node.Sons.ContainsKey(pos))
                {
                    node.Sons[pos] = new TrieNode(pos);
                }
                node.Sons[pos].PrefixNum++;
                node = node.Sons[pos];
            }
            node.Word = word;
            node.IsEnd = true;
            node.WordNum++;
        }

        //获取前缀词频
        public int PrefixCount(string prefix)
        {
            return GetCount(prefix, false);
        }

        //获取单词词频
        public int WordCount(string word)
        {
            return GetCount(word, true);
        }

        private int GetCount(string str, bool isword)
        {
            if (string.IsNullOrEmpty(str)) return -1;
            TrieNode node = _Root;
            for (int i = 0, len = str.Length; i < len; i++)
            {
                char pos = str[i];
                if (!node.Sons.ContainsKey(pos)) return 0;
                else node = node.Sons[pos];
            }
            return isword ? node.WordNum : node.PrefixNum;
        }

        //是否包含指定的单词
        public bool ContainsWord(string word)
        {
            return WordCount(word) > 0;
        }

        //单词表单元
        public class ListUnit
        {
            public string Word;  //单词
            public int WordNum;  //词频
        }

        //词频排序
        public List<ListUnit> Sort()
        {
            TrieNode node = _Root;
            List<ListUnit> WordList = new List<ListUnit>();
            WordList = WordPreOrder(node, WordList);
            //按词频降序排列，若词频相等按字典序排列
            WordList.Sort((a, b) =>
            {
                if (a.WordNum.CompareTo(b.WordNum) != 0)
                    return -a.WordNum.CompareTo(b.WordNum);
                else
                    return a.Word.CompareTo(b.Word);
            });
            return WordList;
        }

        //单词表生成（Trie树的前序遍历）
        private List<ListUnit> WordPreOrder(TrieNode node, List<ListUnit> WordList)
        {
            if (node.PrefixNum == 0) { return WordList; }
            if (node.WordNum != 0)
            {
                ListUnit unit = new ListUnit();
                unit.Word = node.Word;
                unit.WordNum = node.WordNum;
                WordList.Add(unit);
            }
            foreach (char key in node.Sons.Keys)
            {
                WordList = WordPreOrder(node.Sons[key], WordList);
            }
            return WordList;
        }
    }
}
