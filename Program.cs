using System;
using System.IO;
using System.Text.RegularExpressions;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            string datafile = @"tekstas.txt";
            string tekstas = File.ReadAllText(datafile);
            int daugiausiaiIsEilesPasikartojaciuRaidziuSkaicius = metodasA(tekstas);
            Console.WriteLine("Daugiausiai is eiles pasikartojaciu raidziu skaicius: {0}", daugiausiaiIsEilesPasikartojaciuRaidziuSkaicius);

            string[] datafiles = {"tekstas1.txt","tekstas2.txt","tekstas3.txt"};
            string[] tekstuMasyvas = new string[datafiles.Length];
            for(int i = 0 ; i < datafiles.Length; i++){
                tekstuMasyvas[i] = File.ReadAllText(datafiles[i]);
            }
            string[] tekstuMasyvasTurintisDaugiausiaiIsEilesPasikartojanciuRaidziu = metodasB(tekstuMasyvas);
            Console.WriteLine("Tekstu masyvai turintys daugiausiai is eiles pasikartojaciu raidziu: ");  
            for(int i = 0; i < tekstuMasyvasTurintisDaugiausiaiIsEilesPasikartojanciuRaidziu.Length; i++)
            {
                Console.WriteLine(tekstuMasyvasTurintisDaugiausiaiIsEilesPasikartojanciuRaidziu[i]);
            }
        }
        static int metodasA (string tekstas)
        {
            int max = 0;
            string pattern = @"([a-zA-Z])\1{1,}";
            Regex rg = new Regex(pattern);
            MatchCollection matched = rg.Matches(tekstas);
            for(int i = 0 ; i < matched.Count; i++){
                if(max < matched[i].Value.Length){
                    max = matched[i].Value.Length;
                }
            }
            return max;
        }
        static string[] metodasB(string[] tekstuMasyvas)
        {
            int max = 0;
            int k = 0;
             for(int i = 0; i < tekstuMasyvas.Length; i++){
                 if(max < metodasA(tekstuMasyvas[i])){
                     k = 1;
                     max = metodasA(tekstuMasyvas[i]);
                 }
                 else if(max == metodasA(tekstuMasyvas[i])){k++;}
             }
             string[] masyvai = new string[k];
             int b = 0;
              for(int i = 0; i < tekstuMasyvas.Length; i++){
                 if(metodasA(tekstuMasyvas[i]) == max){
                     masyvai[b] = tekstuMasyvas[i];
                     b++;
                 }
             }
             Console.WriteLine(max);
             return masyvai;
        }
    }
}
