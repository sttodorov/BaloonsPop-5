namespace BaloonsPopGame
{
    using System;

    public class RankList : IComparable<RankList>
    {
        public int Value;
        public string Name;

        public RankList(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int CompareTo(RankList other)
        {
            return Value.CompareTo(other.Value);
        }

    }
}