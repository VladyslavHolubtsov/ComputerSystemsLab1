using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frequency
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alfavit = "АаБбВвГгҐґДдЕеЄєЖжЗзИиІіЇїЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЬьЮюЯя0123456789.,'!?()/ -\";:".ToCharArray();
            string text = File.ReadAllText(args[0], Encoding.GetEncoding(65001));
            Dictionary<char, int> frequency = new Dictionary<char, int>();
            for (int i = 0; i < alfavit.Length; i++)
            {
                frequency[alfavit[i]] = 0;
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (frequency.ContainsKey(text[i]))
                {
                    frequency[text[i]]++;
                }
            }
            double  Ent = 0;
            double info = 0;
            Console.WriteLine("Символ|Кількість| Частота");
            for (int i = 0; i < alfavit.Length; i++)
            {
                double p, H = 0;
                p = (double)frequency[alfavit[i]] / text.Length;
                H = ((-p) * Math.Log(p, 2.0));
                Console.WriteLine(alfavit[i] + "        " + (double)frequency[alfavit[i]] + "        " + p);
                if(p!=0)
                {
                    Ent += H;
                }
            }
            info =Ent*text.Length/8;
            Console.WriteLine("Середня ентропія нерівноймовірного алфавіту: " + Ent.ToString());
            Console.WriteLine("Kількість інформації: " + info.ToString());
        }
    }
}