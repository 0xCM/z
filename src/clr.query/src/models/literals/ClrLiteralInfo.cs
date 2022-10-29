//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct ClrLiteralInfo
    {
        public readonly PartName Part;

        public readonly string Group;

        public readonly string Type;

        public readonly string Name;

        public readonly object Value;

        public readonly ClrLiteralKind Kind;

        [MethodImpl(Inline)]
        public ClrLiteralInfo(PartName part, string group, string type, string name, object value, ClrLiteralKind clr)
        {
            Part = part;
            Group = group;
            Type = type;
            Name = name;
            Value = value;
            Kind = clr;
        }
    }
}