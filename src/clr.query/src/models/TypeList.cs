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

        }

        public TypeList(TypeListEntry[] src)
            : base(src)
        {

        }
    }
}