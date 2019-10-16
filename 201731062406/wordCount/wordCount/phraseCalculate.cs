using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;


namespace wordCount
{
    public class phraseCalculate
    {
        

        public Dictionary<string, int> PhraseStat(string path,int m)
        {
           
            Dictionary<string, int> keyValuesPairPhrase = new Dictionary<string, int>();
            //Console.WriteLine("请输入您想输出的词组数");
            //m = Convert.ToInt32(Console.Read());
            string tool1 = @"\b[a-zA-z]\w{0,}";
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string Line = "";
            while ((Line = sr.ReadLine()) != null)
            {
                MatchCollection mc = Regex.Matches(Line, tool1);
                for (int i = 0; i < mc.Count - m + 1; i++)
                {
                    string tmp = "";
                    for (int j = i; j < i + m; j++)
                    {
                        if (mc[j].Length < 4)
                        {
                            goto tick;
                        }
                        tmp += mc[j].ToString() + " ";
                    }
                    if (!keyValuesPairPhrase.ContainsKey(tmp))
                    {
                        keyValuesPairPhrase.Add(tmp, 1);
                    }
                    else
                    {
                        keyValuesPairPhrase[tmp]++;
                    }
                tick:;
                }
            }

            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var i in keyValuesPairPhrase)
            {
                Console.WriteLine(i.Key + ":" + i.Value);
                result.Add(i.Key, i.Value);
            }
            sr.Close();
            fs.Close();
            return result;
        }
    }
}
