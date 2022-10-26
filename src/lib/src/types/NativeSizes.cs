//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct NativeSizes
    {
        [MethodImpl(Inline)]
        public static NativeSegType seg(NativeScalar type, byte count)
            => new NativeSegType(type,count);

        [MethodImpl(Inline)]
        public static NativeSegType seg(NativeClass @class, NativeSizeCode total, NativeSizeCode cell)
        {
            var a = (uint)total;
            var count = ((uint)Sized.width(total))/((uint)Sized.width(cell));
            var dst =  (ushort)((uint)cell | ((uint)@class << 4) | (count << 8));
            return @as<ushort,NativeSegType>(dst);
        }

        [MethodImpl(Inline)]
        public static NativeSegType seg(NativeClass @class, ushort total, ushort cell)
            => seg(@class, Sized.native(total), Sized.native(cell));

        [MethodImpl(Inline)]
        public static NativeSegType seg(NativeSegKind kind)
            => @as<NativeSegKind,NativeSegType>(kind);
    }
}