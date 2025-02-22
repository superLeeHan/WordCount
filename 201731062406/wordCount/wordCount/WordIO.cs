﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace wordCount
{
    public class WordIO
    {
        public string pathIn;
        public string pathOut;

        //按行读取输入文件并统计
        public WordCalculate Input(WordCalculate datanumber, WordTrie wtrie)
        {
            FileStream fs = null;
            StreamReader sr = null;
            String dataline = String.Empty;
            try
            {
                fs = new FileStream(this.pathIn, FileMode.Open);
                sr = new StreamReader(fs);
                while ((dataline = sr.ReadLine()) != null)
                {
                    datanumber.Calculate(dataline, wtrie);  //按行统计数据
                }
            }
            catch { Console.WriteLine("文档读取失败！"); }
            finally
            {
                if (sr != null) { sr.Close(); }
                if (fs != null) { fs.Close(); }
            }
            return datanumber;
        }

        //将统计数据写到输出文件
        public void Output(WordCalculate datanumber, WordTrie wtrie,int n)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            List<WordTrie.ListUnit> WordList = new List<WordTrie.ListUnit>();
            try
            {
                fs = new FileStream(this.pathOut, FileMode.Create);
                sw = new StreamWriter(fs);
                WordList = wtrie.Sort();
                sw.WriteLine(String.Concat("characters:", datanumber.charactersnumber, "\n"));
                sw.WriteLine(String.Concat("words:", datanumber.wordsnumber, "\n"));
                sw.WriteLine(String.Concat("lines:", datanumber.linesnumber, "\n"));
                sw.WriteLine("\n词频\t单词\n");
                Console.WriteLine(String.Concat("characters：", datanumber.charactersnumber));
                Console.WriteLine(String.Concat("words：", datanumber.wordsnumber));
                Console.WriteLine(String.Concat("lines：", datanumber.linesnumber, "\n"));
                //Console.WriteLine("\n词频\t单词\n");
                for (int i = 0; (i < n && i < datanumber.wordsnumber); i++)
                {
                    sw.WriteLine(WordList[i].Word + "：" + String.Concat(WordList[i].WordNum));
                    Console.WriteLine(WordList[i].Word+"："+String.Concat(WordList[i].WordNum));
                }
            }
            //catch { Console.WriteLine("文档写入失败！"); }
            finally
            {
                if (sw != null) { sw.Close(); }
                if (fs != null) { fs.Close(); }
            }
        }
    }
}
