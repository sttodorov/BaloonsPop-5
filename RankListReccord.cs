namespace BaloonsPopGame
{
    using System;

    public class RankListReccord : IComparable<RankListReccord>
    {
        //private readonly DateTime
        private int value;
        private string name;

        public RankListReccord(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }

        public int Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                if (value < 1 || value > (GameConstants.FieldCols * GameConstants.FieldRows))
                {
                    throw new ArgumentOutOfRangeException("Score value must be between 1 and the total number of squares.");
                }

                this.value = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("User must enter a name that is at least one printable non-whitespace character.");
                }

                this.name = value;
            }
        }

        public void PrintReccord() //replace with override ToString()
        {
            Console.WriteLine(".    {0} with {1} moves.", this.Name, this.Value);
        }

        public int CompareTo(RankListReccord other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}