using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreprocessingData
{
    class DataController
    {
        public static void addToFile(string outputFile, string text)
        {
            // add text to outputFile
            File.AppendAllText(outputFile, text + Environment.NewLine);
            //File.AppendAllText(outputFile, text);

        }

        public static string readFile(string directory)
        {
            string content = File.ReadAllText(directory);

            return content;
        }

        public static void writeTagsToFile(string directory, string output)
        {
            Cleaner cleaner = new Cleaner();

            Dictionary<string, bool> tagDic = new Dictionary<string, bool>();
            for (int i = 1; i <= 10778; i++)
            {
                string document = DataController.readFile(directory + i + ".txt");
                List<string> tags = cleaner.getTags(document);      
                
                // save tag to dictionary
                foreach (string tag in tags)
                {
                    if(!tagDic.ContainsKey(tag))
                    {
                        tagDic.Add(tag, true);
                    }
                }
            }

            // write tags to file
            foreach(string tag in tagDic.Keys)
            {
                File.AppendAllText(output, tag + Environment.NewLine);
            }
        }

        public static void writeCharEntitiesToFile(string directory, string output)
        {
            Cleaner cleaner = new Cleaner();

            Dictionary<string, bool> charEntitiesDic = new Dictionary<string, bool>();
            for (int i = 1; i <= 10778; i++)
            {
                string document = DataController.readFile(directory + i + ".txt");
                List<string> charEntities = cleaner.getCharEntities(document);

                // save charEntities to dictionary
                foreach (string charEntity in charEntities)
                {
                    if (!charEntitiesDic.ContainsKey(charEntity))
                    {
                        charEntitiesDic.Add(charEntity, true);
                        Console.WriteLine(i);
                    }
                }
            }

            // write charentities to file
            foreach (string charEntity in charEntitiesDic.Keys)
            {
                File.AppendAllText(output, charEntity + Environment.NewLine);
            }
        }

        public static bool isDoubleSpaceInDocument(string document)
        {
            bool isDouble = false;

            if(document.Contains("  "))
            {
                isDouble = true;
            }

            return isDouble;
        }

        public static void writeAllWordInDocument(string directory, string output)
        {
             // check all word in document
            Console.WriteLine("split document");
            Dictionary<string, int> dWord = new Dictionary<string, int>();
            int i = 0;
            string line = "";

            Console.WriteLine("add word to dictionary");
            System.IO.StreamReader file = new System.IO.StreamReader(directory);
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(' ');

                foreach (string word in words)
                {
                    if(!dWord.ContainsKey(word))
                    {
                        dWord.Add(word, 1);
                    }
                    else
                    {
                        dWord[word] += 1;
                    }
                }
                i++;
                Console.WriteLine(i);
            }

            // sort distionary descendinng
            Console.WriteLine("sort dictionary");
            var sortedDWord = from entry in dWord orderby entry.Value descending select entry;

            // write to file
            Console.WriteLine("write to file");
            foreach(var word in sortedDWord)
            {
                addToFile(output, word.Key + " " + word.Value);
            }

            // sum the words
            int sum = 0;
            foreach(var word in dWord)
            {
                sum += word.Value;
            }
            addToFile(output, "all word = " + sum);
        }

        // get how many document contains the word
        public static void writeSumDocumentWord(string directory, string output)
        {
            Console.WriteLine("split document");
            Dictionary<string, int> dWord = new Dictionary<string, int>();
            int i = 0;
            string line = "";

            Console.WriteLine("add word to dictionary");
            System.IO.StreamReader file = new System.IO.StreamReader(directory);
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(' ');
                words = words.Distinct().ToArray();

                foreach (string word in words)
                {
                    if (!dWord.ContainsKey(word))
                    {
                        dWord.Add(word, 1);
                    }
                    else
                    {
                        dWord[word] += 1;
                    }
                }
                i++;
                Console.WriteLine(i);
            }

            // sort distionary descendinng
            Console.WriteLine("sort dictionary");
            var sortedDWord = from entry in dWord orderby entry.Value descending select entry;

            // write to file
            Console.WriteLine("write to file");
            foreach (var word in sortedDWord)
            {
                addToFile(output, word.Key + " " + word.Value);
            }

            // sum the words
            int sum = 0;
            foreach (var word in dWord)
            {
                sum += word.Value;
            }
            addToFile(output, "all word = " + sum);
        }
    }
}
