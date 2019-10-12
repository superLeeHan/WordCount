using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace wordCount{
    class Program{
        //统计txt文件的有效行数
        public static int acc_lines_num(String filepath)
        {
            int lines = 0;

            //按行读取
           
            using (var sr = new StreamReader(filepath))
            {
                var ls = "";
                while ((ls = sr.ReadLine()) != null)
                {
                    lines++;
                }
            }
           
            return lines;
        }
        //统计txt文件的字符数
        public static int acc_char_num(String filepath)
        {
            int char_num = 0;
            //\S——匹配任何非空白字符（除了空格、换行、制表符等的任何字符）
            //|——匹配二选一
            char_num = Regex.Matches(filepath, @"\f\n\r\t").Count;
            foreach (var i in filepath)
            {
                if(i >= 32 && i < 126)
                {
                    char_num++;
                }
            }
            return char_num;
        }
        //统计txt文件的单词数和单词出现次数,并按字典序输出TOP10
        public static int acc_words_num()
        {

            return 0;
            }
        

        static void Main(string[] args){
            string filepath = @"C:\Download\WordCount\201731062406\wordCount\input.txt";
            int line_num = acc_lines_num(filepath);
            int char_num = acc_char_num(filepath);
            Console.WriteLine("文件中的字符总数：" + char_num );
            Console.WriteLine("文件总行数：" + line_num);

        }
    }
}
