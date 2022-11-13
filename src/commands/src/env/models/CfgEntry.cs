//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public record struct CfgEntry
    {
        public readonly string Name;

        public readonly string Value;

        [MethodImpl(Inline)]
        public CfgEntry(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => $"{Name}={Value}";

        public override string ToString()
            => Format();
    }
}
