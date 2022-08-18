//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Spans;

    partial class HashCodes
    {
        public static bool perfect(ReadOnlySpan<string> src, out HashEntry<string>[] dst)
        {
            dst = sys.empty<HashEntry<string>>();
            var count = (uint)src.Length;
            var n = Pow2.test(count) ? count : (uint)Pow2.next(count);
            var result = perfect(src, x => x, out var hashed);
            if(result)
            {
                var codes = hashed.Codes;
                dst = sys.alloc<HashEntry<string>>(n);
                ref var records = ref first(dst);
                for(var j=0u; j<count; j++)
                {
                    ref readonly var hash = ref Spans.skip(codes,j);
                    ref var record = ref dst[j];
                    record.Seq = hash.Hash % n;
                    record.Code = hash.Hash;
                    record.Content = hash.Source;
                }
                dst.Sort();
            }

            return result;
        }

        public static bool perfect<T>(ReadOnlySpan<T> src, Func<T,string> f, out HashedIndex<T> dst)
            where T : IEquatable<T>
        {
            var count = src.Length;
            var buffer = alloc<HashCode<T>>(count);
            var accumulator = new HashSet<uint>();
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref Spans.skip(src,i);
                var computed = hash(f(input));
                seek(buffer,i) = (input, computed);
                accumulator.Add(computed);
            }
            var collisions = count - (uint)accumulator.Count;
            dst = new HashedIndex<T>(buffer, t => hash(f(t)));
            return collisions == 0;
        }
    }
}