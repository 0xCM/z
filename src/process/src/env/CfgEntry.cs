//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public record struct CfgEntry
    {
        public readonly ReadOnlySeq<char> Name;

        public readonly ReadOnlySeq<char> Value;

        [MethodImpl(Inline)]
        public CfgEntry(string name, string value)
        {
            Name = name.ToCharArray();
            Value = value.ToCharArray();
        }

        public string Format()
            => $"{new string(Name.Storage)}={new string(Value.Storage)}";

        public override string ToString()
            => Format();
    }
}
