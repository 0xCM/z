//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public record VarDef : IComparable<VarDef>
    {
        public readonly @string Name;

        public readonly @string Type;

        public readonly @string Usage;
        
        public VarDef(string name, string type, string usage)
        {
            Name = name;
            Type = type;
            Usage = usage;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash | Type.Hash;
        }

        public VarDef WithUsage(string usage)
            => new VarDef(Name, Type, usage);

        public override int GetHashCode()
            => Hash;

        public virtual bool Equals(VarDef src)
            => Name == src.Name && Type == src.Type;

        public int CompareTo(VarDef src)
            => Name.CompareTo(src.Name);

        public string Format()
        {
            var dst = EmptyString;
            if(IsNonEmpty)
            {
                if(nonempty(Usage))
                {
                    dst += $"// {Usage}";
                    dst += Chars.Eol;
                }
                dst += $"{Name}:{Type}";
            }
            return dst;
        }

        public override string ToString()
            => Format();

        public static VarDef Empty => new (EmptyString,EmptyString,EmptyString);
    }
}