namespace BaloonsPopGame.Baloons
{
    public abstract class Baloon
    {
        private const char DefaultSymbol = '♥'; 

        public char Symbol { get; private set; }

        public BaloonColor Color { get; private set; }

        public Baloon(BaloonColor color)
        {
            this.Color = color;
            this.Symbol = DefaultSymbol;
        }

        public Baloon(BaloonColor color, char symbol)
        {
            this.Color = color;
            this.Symbol = symbol;
        }

        public override string ToString()
        {
            return this.Symbol.ToString();
        }
    }
}
