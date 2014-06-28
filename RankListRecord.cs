namespace BaloonsPopGame
{
    using System;

    public class RankListRecord : IComparable<RankListRecord>
    {
        //private readonly DateTime
        private int value;
        private string name;

        public RankListRecord(int value, string name)
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

        public string ToFormattedString() 
        {
            string recordAsString = string.Format(".    {0} with {1} moves.", this.Name, this.Value);
            return recordAsString;
        }

        public override string ToString()
        {
            string recordAsString = string.Format("{0}, {1}", this.Name, this.Value);
            return recordAsString;
        }

        public int CompareTo(RankListRecord other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}