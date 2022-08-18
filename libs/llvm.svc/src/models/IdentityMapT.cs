//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public sealed class IdentityMap<T>
        where T : unmanaged, IEquatable<T>, IComparable<T>
    {
        readonly ConcurrentDictionary<string,ClosedInterval<T>> Data;

        public readonly Index<string> Keys;

        public readonly Index<ClosedInterval<T>> Values;

        public readonly uint EntryCount;

        public readonly Pairings<string,ClosedInterval<T>> Pairs;

        public readonly uint LineCount;

        public IdentityMap()
        {
            Data = new();
            EntryCount = 0;
            Keys = sys.empty<string>();
            Values = sys.empty<ClosedInterval<T>>();
        }

        IdentityMap(uint count, ConcurrentDictionary<string,ClosedInterval<T>> data, string[] keys, ClosedInterval<T>[] values, Pairings<string,ClosedInterval<T>> pairs)
        {
            LineCount = count;
            EntryCount = (uint)keys.Length;
            Data = data;
            Keys = keys;
            Values = values;
            Pairs = pairs;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => EntryCount != 0;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => EntryCount == 0;
        }

        public ref readonly Paired<string,ClosedInterval<T>> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Pairs[index];
        }

        [MethodImpl(Inline)]
        public ref readonly ClosedInterval<T> Interval(uint index)
            => ref Values[index];

        [MethodImpl(Inline)]
        public ref readonly string Name(uint index)
            => ref Keys[index];

        public bool Include(string key, ClosedInterval<T> value)
            => text.nonempty(key) ? Data.TryAdd(key ?? EmptyString, value) : false;

        public bool Find(string key, out ClosedInterval<T> value)
            => Data.TryGetValue(key ?? EmptyString, out value);

        public IdentityMap<T> Seal()
        {
            var src = Data;
            var keys = Data.Keys.Index();
            var values = src.Values.Index();
            var comparer = Intervals.comparer<T>();
            Array.Sort(values.Storage, comparer);
            var count = keys.Count;
            var lines = 0ul;
            var pairs = alloc<Paired<string, ClosedInterval<T>>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var value = ref values[i];
                seek(pairs,i) = paired(keys[i], value);
                lines += value.Width;
            }
            return new IdentityMap<T>((uint)lines, src, keys, values, pairs);
        }
    }
}