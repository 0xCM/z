//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    [Free, ApiHost]
    public partial class Heaps
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static HeapEntry<K,O,L> convert<K,O,L>(ReadOnlySpan<byte> src, out HeapEntry<K,O,L> dst)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
        {
            dst = @as<HeapEntry<K,O,L>>(src);
            return dst;
        }
   }
}