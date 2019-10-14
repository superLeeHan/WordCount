using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;


namespace wordCount
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //设置初始的参数值
            int word_num = 10;
            int phrase_num = 3;
            string input_path = @"C:\Download\WordCount\201731062406\wordCount\input.txt";
            string output_path = @"C:\Download\WordCount\201731062406\wordCount\int.txt";


            


            //Console.WriteLine("请输入您想输出的单词数");
            //word_num = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("请输入您想输出的词组长度");
            //phrase_num = Convert.ToInt32(Console.ReadLine());


            ///////////////////////////////////////////////////////////////////////////////////
            ///
            if (args.Length > 0)
            {
                //对命令行参数进行判断（-m、-n、-i、-o）并保存参数
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-i")
                        input_path = args[++i];
                    else if (args[i] == "-m")
                        word_num = Convert.ToInt32(args[++i]);
                    else if (args[i] == "-o")
                        output_path = args[++i];
                    else if (args[i] == "-n")
                        phrase_num = Convert.ToInt32(args[++i]);
                }



                if (input_path != null && output_path != null)
                {

                    //定义字符串，用于保存从文件中读取的内容
                    string content = null;

                    //读取参数-i的路径文件中的内容
                    content = File.ReadAllText(input_path);


                    //实例化附加功能类，父类功能可以直接调用
                    WordIO io = new WordIO();
                    WordCalculate datanumber = new WordCalculate();
                    WordTrie wtrie = new WordTrie();
                    phraseCalculate phcal = new phraseCalculate();
                    
                    io.pathIn = input_path;
                    io.pathOut = output_path;
                    datanumber = io.Input(datanumber, wtrie);  //按行读取文件并统计
                    io.Output(datanumber, wtrie, word_num);
                    phcal.PhraseStat(input_path, phrase_num);
                    Console.ReadKey();

                    
                }

                else
                    Console.WriteLine("路径不正确，读取文档失败！");

            }

            //无命令行参数
           
           
           

        }
    }
}
