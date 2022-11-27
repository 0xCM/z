//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdArg<T> : ICmdArg<CmdArg<T>,T>
        where T : IEquatable<T>, IComparable<T>
    {
        public readonly uint Index;

        public readonly @string Name;

        public readonly T Value;

        [MethodImpl(Inline)]
        public CmdArg(T value)
        {
            Index = 0;
            Value = value;
            Name = value.ToString();
        }

        [MethodImpl(Inline)]
        public CmdArg(uint index, T value)
        {
            Index = 0;
            Value = value;
            Name = value.ToString();
        }

        [MethodImpl(Inline)]
        public CmdArg(uint index, string name, T value)
        {
            Index = index;
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public int CompareTo(CmdArg<T> src)
            => Index.CompareTo(src.Index);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(Format());
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
            => $"{Value?.ToString() ?? EmptyString}";

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.hash(Value);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(CmdArg<T> src)
            => Value.Equals(src.Value);

        T ICmdArg<T>.Value 
            => Value;

        uint ICmdArg.Index 
            => Index;

        @string ICmdArg.Name 
            => Name;

        [MethodImpl(Inline)]
        public static implicit operator CmdArg<T>(T src)
            => new CmdArg<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdArg(CmdArg<T> src)
            => new CmdArg(src.Index, src.Name, src.Value.ToString());


        public static CmdArg<T> Empty
            => new CmdArg<T>(0, default(T));
    }
}