//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class UnmanagedFormatter<T> : BinaryFormatter<T>
        where T : unmanaged
    {
        public override uint Decode(ReadOnlySpan<byte> src, uint offset, out T dst)
        {
            dst = sys.first(sys.recover<T>(sys.slice(src,offset)));
            return sys.size<T>();
        }

        public override uint Encode(T src, uint offset, Span<byte> dst)
        {
            sys.first(sys.recover<T>(sys.slice(dst,offset))) = src;
            return sys.size<T>();
        }
    }
}