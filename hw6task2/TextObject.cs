namespace hw6task2
{
    public class TextObject
    {
        public string Text { get; private set; }

        public TextObject()
        {
            Text = "";
        }

        public TextObject(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }

        public string[] SplitToSentences()
        {
            Text = Text.Replace(System.Environment.NewLine, "");
            return Text.Split(".");
        }

        #region File management
        public void ReadFromFile(string filePath)
        {
            using (TextReader reader = File.OpenText(filePath))
            {
                Text = reader.ReadToEnd();
            }
        }

        public void WriteToFile(string filePath, bool append = false)
        {
            StringUtils.WriteToFile(filePath, Text, append);
        }
        #endregion
    }
}
