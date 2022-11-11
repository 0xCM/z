//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Bytes
    {
        /// <summary>
        /// Reads a sequence of bytes beginning at a specified address and halts when either the capacity
        /// of the target buffer is exdeeded or when a sequence of zeroes is encountered
        /// </summary>
        /// <param name="zmax">The maximum number of zeroes to allow</param>
        /// <param name="src">The base address</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static unsafe int readz(uint zmax, MemoryAddress src, Span<byte> dst)
        {
            var pSrc = src.Pointer<byte>();
            return readz(zmax, ref pSrc, dst.Length, dst);
        }

        /// <summary>
        /// Reads a sequence of bytes beginning at a specified address and halts when either a specified
        /// number of bytes are read or when a sequence of zeroes is encountered
        /// </summary>
        /// <param name="zmax">The maximum number of zeroes to allow</param>
        /// <param name="pSrc">The data source</param>
        /// <param name="limit">The maximum number of bytes to read</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static unsafe int readz(uint zmax, ref byte* pSrc, int limit, Span<byte> dst)
            => readz(zmax, ref pSrc, limit, ref first(dst));

        /// <summary>
        /// Reads a sequence of bytes beginning at a specified address and halts when either a specified
        /// number of bytes are read or when a sequence of zeroes is encountered
        /// </summary>
        /// <param name="zmax">The maximum number of zeroes to allow</param>
        /// <param name="pSrc">The data source</param>
        /// <param name="limit">The maximum number of bytes to read</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static unsafe int readz(uint zmax, ref byte* pSrc, int limit, ref byte dst)
        {
            var offset = 0;
            var count = 0;
            while(offset<limit && count<zmax)
            {
                var value = Unsafe.Read<byte>(pSrc++);
                seek(dst, offset++) = value;
                if(value != 0)
                    count = 0;
                else
                    count++;
            }
            return offset;
        }
    }
}