//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LiteralProvider
    {
        public readonly PartId Part;

        public readonly Type Type;

        public readonly string Group;

        public readonly string Name;

        [MethodImpl(Inline)]
        public LiteralProvider(PartId part, Type type, string group, string name)
        {
            Type = type;
            Name = name;
            Part = part;
            Group = group;
        }
    }
}