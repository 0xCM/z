//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static ScalarCast;
    using static sys;

    partial class Sized
    {
        [MethodImpl(Inline), Op]
        public static BitWidth bits(ulong src)
            => new BitWidth(src);

        [MethodImpl(Inline), Op]
        public static BitWidth bits(long src)
            => new BitWidth(src);

        [MethodImpl(Inline), Op]
        public static BitWidth bits(NativeSizeCode src)
            => src != NativeSizeCode.W80 ? (Pow2.pow((byte)src)*8ul) : 80;

        [MethodImpl(Inline), Op]
        public static BitWidth bits(Kb src)
        {
            var bits = (ulong)size(src).Bits;
            var rem = (ulong)src.Rem;
            return new BitWidth(bits + rem);
        }
    }
}