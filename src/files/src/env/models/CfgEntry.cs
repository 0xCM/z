//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public record class CfgEntry<E,T> : ICfgEntry<E,T>
        where E : CfgEntry<E,T>, new()
        where T : ICfgValue, new()
    {
        public readonly @string Name;

        public readonly T Value;

        [MethodImpl(Inline)]
        public CfgEntry(string name, T value)
        {
            Name = name;
            Value = value;
        }

        @string ICfgEntry.Name
            => Name;

        T ICfgEntry<T>.Value
            => Value;

        public string Format()
            => $"{Name}={Value}";

        public override string ToString()
            => Format();
    }
}
