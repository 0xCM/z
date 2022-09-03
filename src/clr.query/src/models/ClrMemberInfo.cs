//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ClrMemberInfo
    {
        public Identifier Name;

        public TextBlock Description;

        public ClrAccessKind Access;

        public ClrModifierKind Modifiers;
    }
}