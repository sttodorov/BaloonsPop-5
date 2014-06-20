using System;

namespace BaloonsPopGame
{
    public class RankListReccord : IComparable<RankListReccord>
    {
        private int value;
        private string name;

        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                //TODO: VAlidate
                this.value = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                //TODO: VAlidate
                this.name = value;
            }
        }
        public RankListReccord(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public void PrintReccord()
        {
            Console.WriteLine(".   {0} with {1} moves.", this.Name, this.Value);
        }

        public int CompareTo(RankListReccord other)
        {
            return this.Value.CompareTo(other.Value);
        }

    }
}