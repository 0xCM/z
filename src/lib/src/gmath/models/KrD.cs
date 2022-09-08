//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static gmath;

    [ApiHost]
    public readonly struct KrD
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static KrD<T> init<T>(T i, T j)
            where T : unmanaged, IEquatable<T>
                => new KrD<T>(i,j);

        public static Index<KrD<T>> seq<T>(T i0, T i1, T j0, T j1)
            where T : unmanaged, IEquatable<T>
        {
            var dst = default(Index<KrD<T>>);
            if(lt(i0,i1) && lt(j0,j1))
            {
                var iD = sub(i1,i0);
                var jD = sub(j1,j0);
                var count = mul(u32(iD), u32(jD));
                dst = alloc<KrD<T>>(count);
                seq(i0, i1, j0, j1, dst);
            }
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint seq<T>(T i0, T i1, T j0, T j1, Span<KrD<T>> dst)
            where T : unmanaged, IEquatable<T>
        {
            var i = i0;
            var j = j0;
            var k = 0u;
            while(lt(i, i1))
            {
                while(lt(j, j1))
                {
                    seek(dst, k++) = init(i, j);
                    gmath.inc(ref j);
                }
                gmath.inc(ref i);
            }
            return k;
        }
    }

    public struct KrD<T> : IEquatable<KrD<T>>
        where T : unmanaged, IEquatable<T>
    {
        public T I;

        public T J;

        [MethodImpl(Inline)]
        public KrD(T i, T j)
        {
            I = i;
            J = j;
        }

        [MethodImpl(Inline)]
        public bit Evaluate()
            => I.Equals(J);

        public string Format()
            => string.Format("({0},{1}):{2}", I, J, Evaluate());

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)alg.hash.combine(u32(I), u32(J));

        [MethodImpl(Inline)]
        public bool Equals(KrD<T> src)
            => I.Equals(src.I) && J.Equals(src.J);

        public override bool Equals(object src)
            => src is KrD<T> x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator bit(KrD<T> src)
            => src.I.Equals(src.J);

        [MethodImpl(Inline)]
        public static bool operator==(KrD<T> a, KrD<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(KrD<T> a, KrD<T> b)
            => !a.Equals(b);
    }
}