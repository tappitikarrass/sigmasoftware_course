namespace hw3
{
    public class Pair
    {
        private int _number;
        private int _freq;

        public Pair(int number, int freq)
        {
            this._number = number;
            this._freq = freq;
        }

        public int Number { get => _number; set => _number = value; }
        public int Freq { get => _freq; set => _freq = value; }

        public override string ToString()
        {
            return $"{_number} - {_freq}";
        }
    }
}
