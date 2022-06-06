using System.Text.RegularExpressions;

namespace hw6task2
{
    public static class StringUtils
    {
        public static string PrettifySentence(string sentence)
        {
            return Regex.Replace(sentence.Trim(), " +", " ");
        }

        public static KeyValuePair<List<string>, List<string>>
            FindExtremumWords(string[] words)
        {
            List<string> wordsList = new List<string>(words);
            List<string> shortestWords = new List<string>();
            List<string> longestWords = new List<string>();
            int shortestLength, longestLength;
            {
                var shortest = FindExtremumWord(words, true);
                shortestLength = shortest.Length;
                var longest = FindExtremumWord(words);
                longestLength = longest.Length;
            }
            foreach (var word in words)
            {
                if (word.Length == shortestLength)
                {
                    shortestWords.Add(word);
                }
                if (word.Length == longestLength)
                {
                    longestWords.Add(word);
                }
            }
            return new KeyValuePair<List<string>, List<string>>(shortestWords, longestWords);
        }

        public static string FindExtremumWord(string[] words, bool minimum = false)
        {
            int length = 0;
            string extremumWord = "";
            if (minimum)
            {
                length = 1000;
            }
            foreach (var word in words)
            {
                if (minimum)
                {
                    if (word.Length < length)
                    {
                        length = word.Length;
                        extremumWord = word;
                    }
                }
                else
                {
                    if (word.Length > length)
                    {
                        length = word.Length;
                        extremumWord = word;
                    }
                }
            }
            return extremumWord;
        }

        public static string[] SplitSentenceToWords(string sentence)
        {
            sentence = sentence.Trim().Replace(" +", "");
            return sentence.Split(" ");
        }

        public static void WriteToFile(string filePath, string text, bool append = false, bool appendNewline = false)
        {
            if (append)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    if (appendNewline)
                    {
                        text += "\n";
                    }
                    writer.Write(text);
                }
                return;
            }

            using (TextWriter writer = File.CreateText(filePath))
            {
                writer.Write(text);
            }
        }
    }
}
