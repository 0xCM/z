//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public sealed class t_bitstream : t_bits<t_bitstream>
    {
        public void check_singletons()
        {
            check_singletons<byte>();
            check_singletons<ushort>();
            check_singletons<uint>();
            check_singletons<ulong>();
        }

        void check_singletons<T>()
            where T : unmanaged
        {
            Span<bit> buffer = stackalloc bit[64];
            var formatter = BitRender.formatter<T>();
            for(var i=0; i<RepCount; i++)
            {
                buffer.Clear();
                var a = Random.Next<T>();
                bit.unpack(a, ref first(buffer));
                var s1 = buffer.FormatList();
                var s2 = formatter.Format(a);
                Claim.eq(s1,s1);
            }
        }
    }
}