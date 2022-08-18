//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static unsafe TypeCode typecode(in SystemTypeCodes src, byte index)
            => (TypeCode)(*(core.address(src) + index).Pointer<byte>());
    }
}