namespace BaloonsPopGame.Baloons
{
    using System.Collections.Generic;

    public class BaloonFactory
    {
        private Dictionary<byte, Baloon> baloons = new Dictionary<byte, Baloon>();

        public Baloon GetBaloon(byte key)
        {
            // Uses "lazy initialization"
            Baloon baloon = null;

            if (baloons.ContainsKey(key))
            {
                baloon = baloons[key];
            }
            else
            {
                switch (key)
                {
                    case 1: baloon = new BlackBaloon(); break;
                    case 2: baloon = new RedBaloon(); break;
                    case 3: baloon = new GreenBaloon(); break;
                    case 4: baloon = new BlueBaloon(); break;
                    case 5: baloon = new DarkYellowBaloon(); break;
                }

                baloons.Add(key, baloon);
            }

            return baloon;
        }
    }
}
