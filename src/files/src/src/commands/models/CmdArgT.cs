//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdArg<T>
        where T : new()
    {
        public readonly @string Name;

        public readonly T Value;

        [MethodImpl(Inline)]
        public CmdArg(T value)
        {
            Value = value;
            Name = value.ToString();
        }

        [MethodImpl(Inline)]
        public CmdArg(uint index, T value)
        {
            Value = value;
            Name = value.ToString();
        }

        [MethodImpl(Inline)]
        public CmdArg(uint index, string name, T value)
        {
            Name = name;
            Value = value;
        }

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
            get => Name.Hash | sys.hash(Value);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(CmdArg<T> src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator CmdArg<T>(T src)
            => new CmdArg<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdArg(CmdArg<T> src)
            => new CmdArg(src.Name, src.Value.ToString());

        public static CmdArg<T> Empty
            => new CmdArg<T>(0, new T());
    }
}