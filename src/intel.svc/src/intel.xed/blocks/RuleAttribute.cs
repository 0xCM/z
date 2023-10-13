//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public partial class XedZ
{
    public class RuleAttribute : IEquatable<RuleAttribute>, IComparable<RuleAttribute>
    {
        public readonly string Name;

        public readonly string Value;

        public RuleAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public bool IsEmpty
        {
            get => text.empty(Name);
        }

        public bool IsNonEmpty
        {
            get => text.nonempty(Name);
        }

        public Hash32 Hash
        {
            get => hash(Name) | hash(Value);
        }
        
        public override int GetHashCode()
            => Hash;

        public string Format()
            => $"{Name}: {Value}";

        public override string ToString()
            => Format();

        public int CompareTo(RuleAttribute src)
        {
            var result = Name.CompareTo(src.Name);
            if(result == 0)
                result = Value.CompareTo(src.Value);
            return result;
        }

        public bool Equals(RuleAttribute src)
            => Name == src.Name && Value == src.Value;

        public override bool Equals(object src)
            => src is RuleAttribute x && Equals(x);
    }
}
