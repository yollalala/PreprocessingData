using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreprocessingData
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = @"D:\data_all_terbaru\data_document_v2-5_cleaned.txt";
            //string output = @"E:\output_real\data_complete\data_document_v2-5.txt";
            string output = @"D:\all_word_document_v2-5_cleaned.txt";

            // check how many docment each word belongs
            DataController.writeSumDocumentWord(directory, output);

            //// remove stopword added in document
            //StopwordTool.AddDictionaryFromText(@"D:\stopword_added_v2-5.txt");    // add stopword list
            //Preprocessor.cleanStopwordAdded(directory, output);

            //// check all word in document
            //DataController.writeAllWordInDocument(directory, output);

            //// combine all document into one file
            //for (int i = 1; i <= 10778; i++)
            //{
            //    string content = DataController.readFile(directory + i + ".txt");
            //    DataController.addToFile(output, content);
            //}

            //// remove number in document
            //for (int i = 1; i <= 10778; i++)
            //{
            //    Preprocessor.cleanNumber(directory + i + ".txt", output + i + ".txt");
            //}

            //// remove stopword in document
            //StopwordTool.AddDictionaryFromText(@"D:\stopword_long.txt");    // add stopword list
            //for (int i = 1; i <= 10778; i++)
            //{
            //    Preprocessor.cleanStopword(directory + i + ".txt", output + i + ".txt");
            //}

            //// tokenize document
            //for (int i = 1; i <= 10778; i++)
            //{
            //    Preprocessor.tokenize(directory + i + ".txt", output + i + ".txt");
            //    //Preprocessor.tokenize(directory + i + ".txt", output);
            //}

            //// remove white space at the start and end of document
            //for (int i = 1; i <= 10778; i++)
            //{
            //    Preprocessor.cleanWhiteSpace(directory + i + ".txt", output + i + ".txt");
            //}

            //// make lower-cased document
            //for (int i = 1; i <= 10778; i++)
            //{
            //    Preprocessor.makeLowerCase(directory + i + ".txt", output + i + ".txt");
            //}

            //// erase author from document
            //for (int i = 1; i <= 10778; i++)
            //{
            //    Preprocessor.cleanAuthor(directory + i + ".txt", output + i + ".txt");
            //}

            //// erase char entities from document
            //for (int i = 1; i <= 10778; i++)
            //{
            //    Preprocessor.cleanCharEntities(directory + i + ".txt", output + i + ".txt");
            //}

            //// check double space in document
            //for (int i = 1; i <= 10778; i++)
            //{
            //    string text = DataController.readFile(directory + i + ".txt");
            //    if(DataController.isDoubleSpaceInDocument(text))
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            //// erase tags from document
            //for (int i = 1; i <= 10778; i++)
            //{
            //    Preprocessor.cleanTag(directory + i + ".txt", output + i + ".txt");
            //}

            Console.WriteLine("Selesai!");
            Console.ReadLine();
        }
    }
}
