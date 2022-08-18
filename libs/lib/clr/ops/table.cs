//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Scalars;

    partial struct Clr
    {
        [Op]
        public static TableIndex? table(Handle handle)
        {
            if(MetadataTokens.TryGetTableIndex(handle.Kind, out var table))
                return table;
            else
                return null;
        }

        [Op]
        public static TableIndex? table(EntityHandle handle)
        {
            if(MetadataTokens.TryGetTableIndex(handle.Kind, out var table))
                return table;
            else
                return null;
        }

        [Op]
        public static uint row(EntityHandle handle)
            => uint32(handle) & 0xFFFFFF;
    }
}