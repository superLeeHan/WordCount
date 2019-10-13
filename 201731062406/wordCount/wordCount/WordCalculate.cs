using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordCount
{
    class WordCalculate
    {
        public long charactersnumber = 0;  //字符数
        public long wordsnumber = 0;  //单词数
        public long linesnumber = 0;  //行数
        //数据统计
        public void Calculate(string dataline, WordTrie wtrie)
        {
            if (string.IsNullOrEmpty(dataline)) return;
            string word = null;
            for (int i = 0, len = dataline.Length; i < len; i++)
            {
                char unit = dataline[i];
                if (unit >= 65 && unit <= 90){
                    unit = (char)(unit + 32);
                }  //大写转小写
                if ((unit >= 48 && unit <= 57) || (unit >= 97 && unit <= 122)){
                    word = String.Concat(word, unit);
                }
                else{
                    if (!string.IsNullOrEmpty(word)){  //判断是否为词尾后的字符
                        if (word[0] >= 97 && word[0] <= 122){  //首字符是否为字母
                            wtrie.Insert(word);
                        }
                        word = null;
                    }
                }
            }
            if (!string.IsNullOrEmpty(word))  //判断行尾是否有单词
            {
                if (word[0] >= 97 && word[0] <= 122){  //首字符是否为字母
                 wtrie.Insert(word);
                }
                word = null;
            }
            this.linesnumber++;  //统计行数
            this.wordsnumber = wtrie.CountSum;  //统计单词数
            this.charactersnumber += dataline.Length;  //统计字符数
        }
    }
}
