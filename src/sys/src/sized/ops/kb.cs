//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Sized
    {
        [MethodImpl(Inline), Op]
        public static Kb kb(ByteSize src)
            => kb(src.Bits);

        [MethodImpl(Inline), Op]
        public static Kb kb(BitWidth src)
        {
            var kb = u32(src.Content/BitsPerKb);
            var rem = u32(src.Content % BitsPerKb);
            return new Kb(kb, rem);
        }
    }
}