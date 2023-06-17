//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class Relative
    {
        [MethodImpl(Inline), Op]
        public static RelAddress address(MemoryAddress @base, MemoryAddress offset)
            => new RelAddress(@base, offset);

        [MethodImpl(Inline)]
        public static RelAddress<T> address<T>(MemoryAddress @base, T offset)
            where T : unmanaged, IAddress
                    => new RelAddress<T>(@base, offset);
    }
}