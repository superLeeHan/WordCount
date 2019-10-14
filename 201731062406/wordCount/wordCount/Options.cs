using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;
using System.Threading.Tasks;

namespace wordCount
{
    public class Options
    {
        [Option('i', "InputFile", MetaValue = "FILE", Required = true, HelpText = "输入数据文件")]
        public string InputFile { get; set; }

        [Option('o', "OutFile", MetaValue = "FILE", Required = true, HelpText = "输出数据文件")]
        public string OutputFile { get; set; }

        [Option('m', "phraseLength", MetaValue = "INT", Required = false, HelpText = "输入词组长度")]
        public int phraseLength { get; set; }

        [Option('n', "WordNumber", MetaValue = "INT", Required = false, HelpText = "输入需要显示的单词数量")]
        public int WordNumber { get; set; }

    }
}
