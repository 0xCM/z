//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class t_rotl : t_bits<t_rotl>
    {
        public void rotl_8()
            => rotl_check<byte>();

        public void rotl_16()
            => rotl_check<ushort>();

        public void rotl_32()
            => rotl_check<uint>();

        public void rotl_64()
            => rotl_check<ulong>();

        /// <summary>
        /// Generic scalar bit left rotation check
        /// </summary>
        /// <typeparam name="T">The scalar type</typeparam>
        void rotl_check<T>(T t = default)
            where T : unmanaged
        {
            var offset = Random.Next(1, width<T>(w32));
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.Next<T>();
                var y = BitStrings.scalar(x);
                Claim.eq(x, y.TakeScalar<T>());

                x = gbits.rotl(x, (byte)offset);
                y = y.RotL(offset);

                var z = y.TakeScalar<T>();
                Claim.eq(x,z);
            }
        }
    }
}