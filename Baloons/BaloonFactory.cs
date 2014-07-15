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
                //    case 1: baloon = new CharacterA(); break;
                //    case 2: baloon = new CharacterB(); break;
                //    //...
                //    case 5: baloon = new CharacterZ(); break;
                }
                baloons.Add(key, baloon);
            }
            return baloon;

        }
    }
}
