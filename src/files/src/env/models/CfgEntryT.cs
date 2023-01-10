//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct CfgEntry<T> 
    {
        public readonly @string Name;

        public readonly T Value;

        public CfgEntry(string name, T value)
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