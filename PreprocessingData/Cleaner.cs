using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PreprocessingData
{
    class Cleaner
    {
        //public static Dictionary<string, bool> years = new Dictionary<string, bool>();
        //public static Dictionary<string, bool> getNumbers(string document)
        //{
        //    Dictionary<string, bool> numbers = new Dictionary<string, bool>();

        //    Regex regex = new Regex(@"[0-9]+");
        //    foreach (var match in regex.Matches(document))
        //    {
        //        if(match.ToString().Length != 4)
        //        {
        //            if (!numbers.ContainsKey(match.ToString()))
        //                numbers.Add(match.ToString(), true);
        //        }
        //        else
        //        {
        //            if(!years.ContainsKey(match.ToString()))
        //            {
        //                years.Add(match.ToString(), true);
        //            }
        //        }
        //    }

        //    return numbers;
        //}

        //public string getErasedNumberDocumentExceptYear(string document, Dictionary<string, bool> numbers)
        //{
        //    string[] words = document.Split(' ');
        //    StringBuilder builder = new StringBuilder();

        //    foreach (string currentWord in words)
        //    {
        //        if (!_stops.ContainsKey(currentWord))
        //        {
        //            builder.Append(currentWord).Append(' ');
        //        }
        //    }

        //    return builder.ToString().Trim();
        //}

        public List<string> getCharEntities(string document)
        {
            List<string> charEntities = new List<string>();

            Regex regex = new Regex("&.*?;");
            foreach (var match in regex.Matches(document))
            {
                if (!charEntities.Contains(match.ToString()))
                    charEntities.Add(match.ToString());
            }

            return charEntities;
        }

        public string getErasedCharEntitiesDocument(string document, List<string> charEntities)
        {
            string text = document;

            // erase char entitiess in document
            foreach (string charEntity in charEntities)
            {
                text = text.Replace(charEntity, "");
            }

            return text;
        }

        public List<string> getTags(string document)
        {
            // get tags in document
            List<string> tags = new List<string>();

            Regex regex = new Regex("</?.*?>");
            foreach (var match in regex.Matches(document))
            {
                if (!tags.Contains(match.ToString()))
                    tags.Add(match.ToString());
            }

            return tags;
        }

        public string getErasedTagDocument(string document, List<string> tags)
        {
            string text = document;

            // erase tags in document
            foreach (string tag in tags)
            {
                text = text.Replace(tag, "");
            }

            //// remove author in the end document
            //text = Regex.Replace(text, @"\s+\(\w*/?\w*\)(\(\++\))*\s*$", string.Empty);

            return text;
        }

        public string getReplacedOddCharDocument(string text)
        {
            string document = text;

            // check if document contains â€™ or â€˜
            if (document.Contains("â€™"))
            {
                document = document.Replace("â€™", "’");
            }

            if (document.Contains("â€˜"))
            {
                document = document.Replace("â€˜", "‘");
            }

            if (document.Contains("Ã©"))
            {
                document = document.Replace("Ã©", "é");
            }

            if (document.Contains("â€œ"))
            {
                document = document.Replace("â€œ", "“");
            }

            if (document.Contains("â€"))
            {
                document = document.Replace("â€", "”");
            }

            if (document.Contains("Â"))
            {
                document = document.Replace("Â", "");
            }

            return document;
        }

        public string getErasedAuthordocument(string text)
        {
            // remove author in the end document
            string document = Regex.Replace(text, @"\s+\(\w*/?\w*\)(\(\++\))*\s*$", string.Empty);

            return document;
        }

        public string getLowerCaseDocument(string document)
        {
            string text = document.ToLower();

            return text;
        }

        public string getErasedWhiteSpaceDocument(string document)
        {
            // remove white space in the end document
            string content = Regex.Replace(document, @"\s+$", string.Empty);

            // remove white space in the start document
            content = Regex.Replace(content, @"^\s+", string.Empty);

            return content;
        }

        //public List<string> getYear(string document)
        //{
        //    List<string> years = new List<string>();

        //    Regex regex = new Regex("\d{4}");
        //    foreach (var match in regex.Matches(document))
        //    {
        //        if (!years.Contains(match.ToString()))
        //            years.Add(match.ToString());
        //    }

        //    return years;
        //}

        //public Dictionary<string, bool> getNumbers(string document)
        //{
        //    // get numbers in document
        //    Dictionary<string, bool> numbers = new Dictionary<string, bool>();

        //    Regex regex = new Regex(@"[0-9]+( |$)");
        //    foreach (var match in regex.Matches(document))
        //    {
        //        if (!numbers.ContainsKey(match.ToString()))
        //            numbers.Add(match.ToString(), true);
        //    }

        //    return numbers;
        //}

        public string getErasedNumberDocument(string document)
        {
            // remove numbers in document
            string content = Regex.Replace(document, @"[0-9]+( |$)", string.Empty);

            return content;
        }

        public string getErasedPunctuationDocument(string document)
        {
            // split document into words
            string[] words = document.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string result = string.Join(" ", words);

            return result;
        }

        private char[] delimiters = new char[]
        {
	        ' ',
	        ',',
	        ';',
	        '.',
            '-',
            '\n',
            '\'',
            ':',
            '(',
            ')',
            '/',
            '?',
            '\t',
            '[',
            ']',
            '"',
            '%',
            '=',
            '>',
            '<',
            '*',
            '#',
            '@',
            '!',
            '$',
            '{',
            '}',
            '^',
            '&',
            '+',
            'â',
            '€',
            '™',
            '”',
            '“',
            '’',
            'œ',
            ''     // odd character
        };
    }
}
