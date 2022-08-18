//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq.Expressions;

    using static LinqXFunc;
    using static core;

    [ApiHost]
    public readonly partial struct ModelsDynamic
    {
        [FixedAddressValueType]
        static readonly Ops8u _ops8u;

        [FixedAddressValueType]
        static readonly Ops8i _ops8i;

        [FixedAddressValueType]
        static readonly Ops16u _ops16u;

        [FixedAddressValueType]
        static readonly Ops16uC _ops16uC;

        [FixedAddressValueType]
        static readonly Ops32u _ops32u;

        [FixedAddressValueType]
        static readonly Ops32i _ops32i;

        [FixedAddressValueType]
        static readonly ModelsDynamic Self;

        [Op]
        public static Index<MemoryAddress> init()
        {
            var src = Self;
            var buffer = new MemoryAddress[7];
            ref var dst = ref first(buffer);
            seek(buffer,0) = address(Self);
            seek(buffer,1) = address(_ops8u);
            seek(buffer,2) = address(_ops8i);
            seek(buffer,3) = address(_ops32u);
            seek(buffer,4) = address(_ops32i);
            seek(buffer,5) = address(_ops16u);
            seek(buffer,6) = address(_ops16uC);
            return buffer;
        }


        public static Expression<Func<ushort, ushort>> abs16u()
            => f((ushort x) => x);

        public static Expression<Func<ushort, ushort, ushort>> add16u()
            => f<ushort>((x, y) => (ushort)(x + y));

        public static Expression<Func<ushort, ushort, ushort>> mul16u()
            => f<ushort>((x, y) => (ushort)(x * y));

        public static Expression<Func<ushort, ushort, ushort>> sub16u()
            => f<ushort>((x, y) => (ushort)(x - y));

        public static Expression<Func<ushort,ushort,ushort>> and16u()
            => f<ushort>((x, y) => (ushort)(x & y));

        public static Expression<Func<ushort,ushort,ushort>> or16u()
            => f<ushort>((x, y) => (ushort)(x | y));

        public static Expression<Func<ushort,ushort,ushort>> xor16u()
            => f<ushort>((x, y) => (ushort)(x ^ y));

        public static Expression<Func<ushort, ushort>> inc16u
            => f((ushort x) => ++x);

        public static Expression<Func<ushort, ushort>> dec16u()
            => f((ushort x) => --x);

        public static Expression<Func<ushort, ushort, bool>> lt16u()
            => f((ushort x, ushort y) => x < y);

        public static Expression<Func<ushort, ushort, bool>> lteq16u()
            => f((ushort x, ushort y) => x <= y);

        public static Expression<Func<ushort, ushort, bool>> gt16u()
            => f((ushort x, ushort y) => x > y);

        public static Expression<Func<ushort, ushort, bool>> gteq16u()
            => f((ushort x, ushort y) => x >= y);
    }
}