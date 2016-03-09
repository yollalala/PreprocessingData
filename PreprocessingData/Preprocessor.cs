using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreprocessingData
{
    class Preprocessor
    {
        public static void cleanTag(string directory, string output)
        {
            Cleaner cleaner = new Cleaner();

            // load document
            string text = DataController.readFile(directory);

            // replace odd character from document
            string document = cleaner.getReplacedOddCharDocument(text);
            
            // get tags from document
            List<string> tags = cleaner.getTags(document);

            // remove tag from document
            string cleanedDocument = cleaner.getErasedTagDocument(document, tags);

            // write cleaned document to file
            DataController.addToFile(output, cleanedDocument);
        }

        public static void cleanCharEntities(string directory, string output)
        {
            Cleaner cleaner = new Cleaner();

            // load document
            string document = DataController.readFile(directory);

            // get char entities from document
            List<string> charEntities = cleaner.getCharEntities(document);

            // remove char entities from document
            string cleanedDocument = cleaner.getErasedCharEntitiesDocument(document, charEntities);

            // write cleaned document to file
            DataController.addToFile(output, cleanedDocument);
        }

        public static void cleanAuthor(string directory, string output)
        {
            Cleaner cleaner = new Cleaner();

            // load document
            string document = DataController.readFile(directory);

            // remove author from document
            string cleanedDocument = cleaner.getErasedAuthordocument(document);

            // write cleaned document to file
            DataController.addToFile(output, cleanedDocument);
        }

        public static void makeLowerCase(string directory, string output)
        {
            Cleaner cleaner = new Cleaner();

            // load document
            string document = DataController.readFile(directory);

            // make lower case document
            string cleanedDocument = cleaner.getLowerCaseDocument(document);

            // write lower-cased document to file
            DataController.addToFile(output, cleanedDocument);
        }


        public static void cleanWhiteSpace(string directory, string output)
        {
            Cleaner cleaner = new Cleaner();

            // load document
            string document = DataController.readFile(directory);

            // remove white space at the start and end of document
            string cleanedDocument = cleaner.getErasedWhiteSpaceDocument(document);

            // write cleaned document to file
            DataController.addToFile(output, cleanedDocument);
        }

        public static void tokenize(string directory, string output)
        {
            Cleaner cleaner = new Cleaner();

            // load document
            string document = DataController.readFile(directory);

            // tokenize document (by remove punctuation)
            string cleanedDocument = cleaner.getErasedPunctuationDocument(document);

            // write tokenized document to file
            DataController.addToFile(output, cleanedDocument);
        }

        public static void cleanStopword(string directory, string output)
        {
            Cleaner cleaner = new Cleaner();

            // load document
            string document = DataController.readFile(directory);

            // remove white space at the start and end of document
            string cleanedDocument = cleaner.getErasedWhiteSpaceDocument(document);

            // remove stopword from document
            cleanedDocument = StopwordTool.RemoveStopwords(cleanedDocument);

            // write cleaned document to file
            DataController.addToFile(output, cleanedDocument);
        }

        public static void cleanNumber(string directory, string output)
        {
            Cleaner cleaner = new Cleaner();

            // load document
            string document = DataController.readFile(directory);

            // remove white space at the start and end of document
            string cleanedDocument = cleaner.getErasedWhiteSpaceDocument(document);

            // remove number from document
            cleanedDocument = cleaner.getErasedNumberDocument(cleanedDocument);

            // write cleaned document to file
            DataController.addToFile(output, cleanedDocument);
        }

        public static void cleanStopwordAdded(string directory, string output)
        {
            Cleaner cleaner = new Cleaner();

            string line = "";
            string cleanedDocument = "";
            System.IO.StreamReader file = new System.IO.StreamReader(directory);
            while ((line = file.ReadLine()) != null)
            {
                // remove stopword from document
                cleanedDocument = StopwordTool.RemoveStopwords(line);

                // write cleaned document to file
                DataController.addToFile(output, cleanedDocument);
            }
        }
    }
}
