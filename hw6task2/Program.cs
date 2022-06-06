using System.Text;

namespace hw6task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var text1 = new TextObject();
            text1.ReadFromFile(@"..\..\..\input.txt");
            {
                string filePath = @"..\..\..\Result.txt";

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                foreach (var sentence in text1.SplitToSentences())
                {
                    StringUtils.WriteToFile(filePath, sentence + '.', append: true, appendNewline: true);
                    var prettySentence = StringUtils.PrettifySentence(sentence);
                    var words = StringUtils.SplitSentenceToWords(prettySentence);
                    var wordListsPair = StringUtils.FindExtremumWords(words);
                    {
                        Console.Write(" longest words: ");
                        foreach (var word in wordListsPair.Value)
                        {
                            Console.Write("{0} ", word);
                        }
                        Console.WriteLine();
                    }
                    {
                        Console.Write("shortest words: ");
                        foreach (var word in wordListsPair.Key)
                        {
                            Console.Write("{0} ", word);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}