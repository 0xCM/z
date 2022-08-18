//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    public readonly struct HexStrings<K>
        where K : unmanaged
    {
        readonly Index<HexString<K>> Refs;

        [MethodImpl(Inline)]
        public HexStrings(params HexString<K>[] src)
        {
            Refs = src;
        }

        [MethodImpl(Inline)]
        public unsafe ReadOnlySpan<char> Chars(uint index)
        {
            ref var src = ref Refs[index];
            return cover(src.BaseAddress.Pointer<char>(), src.Length);
        }

        [MethodImpl(Inline)]
        public unsafe string String(uint index)
           => Refs[index].Text;

        public unsafe string this[uint index]
        {
            [MethodImpl(Inline)]
            get => String(index);
        }

        public static HexStrings<K> Empty
            => new HexStrings<K>(HexString<K>.Empty);
    }
}