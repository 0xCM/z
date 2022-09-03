//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Security.Cryptography;

    using static core;

    public static class Entropy
    {
        /// <summary>
        /// Produces a specified number of entropic bytes
        /// </summary>
        /// <param name="count">The number of bytes</param>
        [MethodImpl(Inline)]
        public static Span<byte> Bytes(int count)
        {
            using var csp = new RNGCryptoServiceProvider();
            var dst = new byte[count];
            csp.GetBytes(dst);
            return dst;
        }

        [Op]
        public static Index<byte> bytes(ByteSize count)
        {
            var dst = new byte[count];
            fill(dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static void fill(Span<byte> dst)
        {
            using var csp = new RNGCryptoServiceProvider();
            csp.GetBytes(dst);
        }

        /// Produces a specified number of entropic primal values
        /// </summary>
        /// <param name="count">The number of bytes</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> Values<T>(int count)
            where T : unmanaged
        {
            var typeBz = Unsafe.SizeOf<T>();
            var bz = count * typeBz;
            var src = Bytes(bz);
            return MemoryMarshal.Cast<byte,T>(src);
        }

        /// <summary>
        /// Produces a single entropic value of primal type
        /// </summary>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static T value<T>()
            where T : unmanaged
        {
            var count = size<T>();
            var storage = default(T);
            fill(core.bytes(storage));
            return storage;
        }
    }
}