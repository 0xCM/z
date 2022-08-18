//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class HashedIndex<T>
        where T : IEquatable<T>
    {
        readonly T[] _Data;

        readonly HashCode<T>[] _Codes;

        readonly Func<T,uint> HashFunction;

        internal HashedIndex(HashCode<T>[] src, Func<T,uint> fx)
        {
            var count = src.Length;
            HashFunction = fx;
            _Data = sys.alloc<T>(count);
            _Codes = src;
            ref var target = ref first(_Data);
            ref readonly var source = ref first(src);
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(source,i);
                var index = code.Hash % count;
                seek(target,index) = code.Source;
            }
        }

        [MethodImpl(Inline)]
        public ref readonly HashCode<T> Code(uint index)
            => ref _Codes[index];

        [MethodImpl(Inline)]
        public ref readonly T Item(uint index)
            => ref _Data[index];

        [MethodImpl(Inline)]
        public uint? Index(in T src)
        {
            var h = HashFunction(src);
            if(h < _Codes.Length)
                return (uint)(h % _Data.Length);
            else
                return null;
        }

        [MethodImpl(Inline)]
        public bool Contains(in T src)
            => HashFunction(src) < _Codes.Length;

        public ReadOnlySpan<HashCode<T>> Codes
        {
            [MethodImpl(Inline)]
            get => _Codes;
        }
    }

}