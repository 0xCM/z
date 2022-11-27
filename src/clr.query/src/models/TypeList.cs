//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TypeList : Seq<TypeList,TypeListEntry>
    {
        public TypeList()
        {
            Name = EmptyString;
        }

        public TypeList(string name, TypeListEntry[] src)
            : base(src)
        {
            Name = name;
        }

        public readonly string Name;
    }
}