//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Refs;
    using static Spans;
    using static Scalars;

    using M = math;

    [ApiHost]
    public struct value
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<byte> vector<T>(W64 w, value<T> src)
            where T : unmanaged
                => cpu.v8u(cpu.vscalar(w128, uint64(src.Data)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<byte> vector<T>(W128 w, value<T> src)
            where T : unmanaged
                => cpu.vload(w, src.Bytes);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<byte> vector<T>(W256 w, value<T> src)
            where T : unmanaged
                => cpu.vload(w, src.Bytes);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 hash<T>(value<T> src)
            where T : unmanaged
        {
            if(Refs.size<T>() == 8)
                return uint8(src.Data);
            else if(size<T>() == 16)
                return uint16(src.Data);
            else if(size<T>() == 32)
                return uint32(src.Data);
            else
                return HashCodes.hash(src.Bytes);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> from<T>(ReadOnlySpan<byte> src)
            where T : unmanaged
                => new value<T>(sys.first(sys.recover<T>(src)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit eq<T>(value<T> a, value<T> b)
            where T : unmanaged
                => size<T>() <= 64 ? eq0(a,b) : eq1(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> and<T>(value<T> a, value<T> b)
            where T : unmanaged
                => new value<T>(and(a.Data,b.Data));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> or<T>(value<T> a, value<T> b)
            where T : unmanaged
                => new value<T>(or(a.Data,b.Data));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> xor<T>(value<T> a, value<T> b)
            where T : unmanaged
                => new value<T>(xor(a.Data,b.Data));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> negate<T>(value<T> a)
            where T : unmanaged
                => new value<T>(negate(a.Data));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> invert<T>(value<T> a)
            where T : unmanaged
                => new value<T>(invert(a.Data));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cmp<T>(value<T> a, value<T> b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return M.cmp(uint8(a), uint8(b));
            else if(size<T>() == 2)
                return M.cmp(uint16(a), uint16(b));
            else if(size<T>() == 4)
                return M.cmp(uint32(a), uint32(b));
            else if(size<T>() == 8)
                return M.cmp(uint64(a), uint64(b));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit lt<T>(value<T> a, value<T> b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return M.lt(uint8(a.Data), uint8(b.Data));
            else if(size<T>() == 2)
                return M.lt(uint16(a.Data), uint16(b.Data));
            else if(size<T>() == 4)
                return M.lt(uint32(a.Data), uint32(b.Data));
            else if(size<T>() == 8)
                return M.lt(uint64(a.Data), uint64(b.Data));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit gt<T>(value<T> a, value<T> b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return M.gt(uint8(a.Data), uint8(b.Data));
            else if(size<T>() == 2)
                return M.gt(uint16(a.Data), uint16(b.Data));
            else if(size<T>() == 4)
                return M.gt(uint32(a.Data), uint32(b.Data));
            else if(size<T>() == 8)
                return M.gt(uint64(a.Data), uint64(b.Data));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit gteq<T>(value<T> a, value<T> b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return M.gteq(uint8(a.Data), uint8(b.Data));
            else if(size<T>() == 2)
                return M.gteq(uint16(a.Data), uint16(b.Data));
            else if(size<T>() == 4)
                return M.gteq(uint32(a.Data), uint32(b.Data));
            else if(size<T>() == 8)
                return M.gteq(uint64(a.Data), uint64(b.Data));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit lteq<T>(value<T> a, value<T> b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return M.lteq(uint8(a.Data), uint8(b.Data));
            else if(size<T>() == 2)
                return M.lteq(uint16(a.Data), uint16(b.Data));
            else if(size<T>() == 4)
                return M.lteq(uint32(a.Data), uint32(b.Data));
            else if(size<T>() == 8)
                return M.lteq(uint64(a.Data), uint64(b.Data));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> sll<T>(value<T> a, byte count)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return new value<T>(sys.@as<T>(M.sll(uint8(a.Data), count)));
            else if(size<T>() == 2)
                return new value<T>(@as<T>(M.sll(uint16(a.Data), count)));
            else if(size<T>() == 4)
                return new value<T>(@as<T>(M.sll(uint32(a.Data), count)));
            else if(size<T>() == 8)
                return new value<T>(@as<T>(M.sll(uint64(a.Data), count)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> srl<T>(value<T> a, byte count)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return new value<T>(@as<T>(M.srl(uint8(a.Data), count)));
            else if(size<T>() == 2)
                return new value<T>(@as<T>(M.srl(uint16(a.Data), count)));
            else if(size<T>() == 4)
                return new value<T>(@as<T>(M.srl(uint32(a.Data), count)));
            else if(size<T>() == 8)
                return new value<T>(@as<T>(M.srl(uint64(a.Data), count)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> add<T>(value<T> a, value<T> b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return new value<T>(@as<T>(M.add(uint8(a.Data), uint8(b.Data))));
            else if(size<T>() == 2)
                return new value<T>(@as<T>(M.add(uint16(a.Data), uint16(b.Data))));
            else if(size<T>() == 4)
                return new value<T>(@as<T>(M.add(uint32(a.Data), uint32(b.Data))));
            else if(size<T>() == 8)
                return new value<T>(@as<T>(M.add(uint64(a.Data), uint64(b.Data))));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> sub<T>(value<T> a, value<T> b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return new value<T>(@as<T>(M.sub(uint8(a.Data), uint8(b.Data))));
            else if(size<T>() == 2)
                return new value<T>(@as<T>(M.sub(uint16(a.Data), uint16(b.Data))));
            else if(size<T>() == 4)
                return new value<T>(@as<T>(M.sub(uint32(a.Data), uint32(b.Data))));
            else if(size<T>() == 8)
                return new value<T>(@as<T>(M.sub(uint64(a.Data), uint64(b.Data))));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> div<T>(value<T> a, value<T> b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return new value<T>(@as<T>(M.div(uint8(a.Data), uint8(b.Data))));
            else if(size<T>() == 2)
                return new value<T>(@as<T>(M.div(uint16(a.Data), uint16(b.Data))));
            else if(size<T>() == 4)
                return new value<T>(@as<T>(M.div(uint32(a.Data), uint32(b.Data))));
            else if(size<T>() == 8)
                return new value<T>(@as<T>(M.div(uint64(a.Data), uint64(b.Data))));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> mod<T>(value<T> a, value<T> b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return new value<T>(@as<T>(M.mod(uint8(a.Data), uint8(b.Data))));
            else if(size<T>() == 2)
                return new value<T>(@as<T>(M.mod(uint16(a.Data), uint16(b.Data))));
            else if(size<T>() == 4)
                return new value<T>(@as<T>(M.mod(uint32(a.Data), uint32(b.Data))));
            else if(size<T>() == 8)
                return new value<T>(@as<T>(M.mod(uint64(a.Data), uint64(b.Data))));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> inc<T>(value<T> a)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return new value<T>(@as<T>(M.inc(uint8(a.Data))));
            else if(size<T>() == 2)
                return new value<T>(@as<T>(M.inc(uint16(a.Data))));
            else if(size<T>() == 4)
                return new value<T>(@as<T>(M.inc(uint32(a.Data))));
            else if(size<T>() == 8)
                return new value<T>(@as<T>(M.inc(uint64(a.Data))));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static value<T> dec<T>(value<T> a)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return new value<T>(@as<T>(M.dec(uint8(a.Data))));
            else if(size<T>() == 2)
                return new value<T>(@as<T>(M.dec(uint16(a.Data))));
            else if(size<T>() == 4)
                return new value<T>(@as<T>(M.dec(uint32(a.Data))));
            else if(size<T>() == 8)
                return new value<T>(@as<T>(M.dec(uint64(a.Data))));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static bit eq0<T>(value<T> a, value<T> b)
            where T : unmanaged
                => eq0(a.Data,b.Data);

        [MethodImpl(Inline)]
        static bit eq0<T>(T a, T b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return M.eq(uint8(a), uint8(b));
            else if(size<T>() == 2)
                return M.eq(uint16(a), uint16(b));
            else if(size<T>() == 4)
                return M.eq(uint32(a), uint32(b));
            else if(size<T>() == 8)
                return M.eq(uint64(a), uint64(b));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static bit eq<T>(W128 w, value<T> a, value<T> b)
            where T : unmanaged
                => cpu.vsame(cpu.vload(w, a.Bytes), cpu.vload(w, b.Bytes));

        [MethodImpl(Inline), Op, Closures(Closure)]
        static bit eq<T>(W256 w, value<T> a, value<T> b)
            where T : unmanaged
                => cpu.vsame(cpu.vload(w, a.Bytes), cpu.vload(w, b.Bytes));

        [MethodImpl(Inline), Op, Closures(Closure)]
        static bit eq<T>(W512 w, value<T> a, value<T> b)
            where T : unmanaged
        {
            var a0 = cpu.vload(w256, a.Bytes);
            var b0 = cpu.vload(w256, b.Bytes);
            var result = cpu.vsame(a0,b0);

            var a1 = cpu.vload(w256, slice(a.Bytes, 32));
            var b1 = cpu.vload(w256, slice(b.Bytes, 32));
            result &= cpu.vsame(a1,b1);
            return result;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static bit eq1<T>(value<T> a, value<T> b)
            where T : unmanaged
        {
            if(size<T>() > 512)
                return eq3(a,b);
            else
            {
                if(size<T>() == 128)
                    return eq(w128, a, b);
                else if(size<T>() == 256)
                    return eq(w256, a, b);
                else if(size<T>() == 512)
                    return eq(w512, a, b);
                else
                    return eq2(a,b);
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static bit eq2<T>(value<T> a, value<T> b)
            where T : unmanaged
        {
            return false;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static bit eq3<T>(value<T> a, value<T> b)
            where T : unmanaged
        {
            return false;
        }

        [MethodImpl(Inline)]
        static T and<T>(T a, T b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return @as<T>(M.and(uint8(a), uint8(b)));
            else if(size<T>() == 2)
                return @as<T>(M.and(uint16(a), uint16(b)));
            else if(size<T>() == 4)
                return @as<T>(M.and(uint32(a), uint32(b)));
            else if(size<T>() == 8)
                return @as<T>(M.and(uint64(a), uint64(b)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T or<T>(T a, T b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return @as<T>(M.or(uint8(a), uint8(b)));
            else if(size<T>() == 2)
                return @as<T>(M.or(uint16(a), uint16(b)));
            else if(size<T>() == 4)
                return @as<T>(M.or(uint32(a), uint32(b)));
            else if(size<T>() == 8)
                return @as<T>(M.or(uint64(a), uint64(b)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T xor<T>(T a, T b)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return @as<T>(M.xor(uint8(a), uint8(b)));
            else if(size<T>() == 2)
                return @as<T>(M.xor(uint16(a), uint16(b)));
            else if(size<T>() == 4)
                return @as<T>(M.xor(uint32(a), uint32(b)));
            else if(size<T>() == 8)
                return @as<T>(M.xor(uint64(a), uint64(b)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T negate<T>(T a)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return @as<T>(M.negate(uint8(a)));
            else if(size<T>() == 2)
                return @as<T>(M.negate(uint16(a)));
            else if(size<T>() == 4)
                return @as<T>(M.negate(uint32(a)));
            else if(size<T>() == 8)
                return @as<T>(M.negate(uint64(a)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T invert<T>(T a)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return @as<T>(M.not(uint8(a)));
            else if(size<T>() == 2)
                return @as<T>(M.not(uint16(a)));
            else if(size<T>() == 4)
                return @as<T>(M.not(uint32(a)));
            else if(size<T>() == 8)
                return @as<T>(M.not(uint64(a)));
            else
                throw no<T>();
        }
    }
}