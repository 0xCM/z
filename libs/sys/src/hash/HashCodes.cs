//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free,ApiHost]
    public partial class HashCodes
    {
        [MethodImpl(Inline), Op]
        public static Hash32 hash(string src)
            => MarvinHash.marvin(src);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(ReadOnlySpan<char> src)
            => MarvinHash.marvin(src);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(ReadOnlySpan<byte> src)
            => MarvinHash.marvin(src);

        [MethodImpl(Inline)]
        public static Hash32 bytehash<C>(C src)
            where C : struct
                => Generic.bytehash(src);

        [ApiHost("hash.generic")]
        public partial class Generic
        {
            const NumericKind Closure = UnsignedInts;
        }

        internal const uint K = 0xA5555529;

        internal const uint FnvOffsetBias = 2166136261;

        internal const uint FnvPrime = 16777619;

        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        static unsafe ulong u64(double src)
            => (*((ulong*)(&src)));

        [MethodImpl(Inline)]
        static unsafe ulong u64(decimal src)
            => (*((ulong*)(&src)));

        [MethodImpl(Inline)]
        static unsafe byte @byte(bool src)
            => (*((byte*)(&src)));

        [MethodImpl(Inline)]
        public static unsafe int i32(float src)
            => (*((int*)(&src)));
    }
}