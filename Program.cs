using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)

        {
            string input = @"C:\Users\Zi\Desktop\прогр\прогр6.2\ткст1.txt";
            string output = @"C:\Users\Zi\Desktop\прогр\прогр6.2\ткст2.txt";

            Dictionary<string, List<string>> library = new Dictionary<string, List<string>>();

            using (FileStream f = new FileStream(input, FileMode.Open)) 
            {
                using (StreamReader txt = new StreamReader(f)) 
                {   
                    string line;
                    while ((line = txt.ReadLine()) != null) 
                    {
                        string[] str = line.Split(" "); // s[0] - Фамилия автора; s[1] - Жанр; s[2 - ...] - Название произведения;
                        
                        string name = str[0]; 

                        for (int i = 2; i < str.Length; i++) name += str[i];

                        if (library.ContainsKey(str[1])) 
                        {
                            library[str[1]].Add(name);                            
                        }
                        else 
                        {
                            library[str[1]] = new List<string> {name};
                        }
                    }
                }
            } 

                using (FileStream fs = new FileStream(output, FileMode.Open)) {
                using (StreamWriter sw = new StreamWriter(fs)) 
                {
                    foreach (KeyValuePair<string, List<string>> keyValue in library)
                    {   
                        sw.WriteLine($"{keyValue.Key} : {keyValue.Value.Count}");
                    }
                }
            }
        }
    }
}