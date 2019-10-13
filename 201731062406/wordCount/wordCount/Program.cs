using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordCount
{
    class Program
    {
        public static void Main()
        {
            WordIO io = new WordIO();
            WordCalculate datanumber = new WordCalculate();
            WordTrie wtrie = new WordTrie();

            io.pathIn = @"C:\Download\WordCount\201731062406\wordCount\input.txt";
            io.pathOut = @"C:\Download\WordCount\201731062406\wordCount\input.txt";
            datanumber = io.Input(datanumber, wtrie);  //按行读取文件并统计
            io.Output(datanumber, wtrie);
            Console.ReadKey();
        }
    }
}
