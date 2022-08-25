//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    unsafe partial struct memory
    {
        [Op]
        public static unsafe Span<byte> load(in BinaryCode src, BufferToken dst)
        {
            @check(src,dst);
            var source = sys.span(src.Storage);
            var target = sys.clear(cover(dst.Address.Pointer<byte>(), dst.BufferSize));
            return sys.copy(source,target);
        }

        [Op, Closures(Closure)]
        public static unsafe Span<T> load<T>(ReadOnlySpan<T> src, BufferToken dst)
            where T : unmanaged
        {
            @check(src,dst);
            var target = sys.clear(cover(dst.Address.Pointer<T>(), dst.BufferSize/size<T>()));
            return sys.copy(src,target);
        }

        [Op]
        static void @check(in BinaryCode src, BufferToken dst)
        {
            var srcSize = src.Length;
            var dstSize = dst.BufferSize;
            if(src.Length > dst.BufferSize)
                sys.@throw("The buffer is too small");
        }

        [Op, Closures(Closure)]
        static void @check<T>(ReadOnlySpan<T> src, BufferToken dst)
            where T : unmanaged
        {
            var srcSize = src.Length;
            var dstSize = dst.BufferSize;
            if(src.Length > dst.BufferSize)
                sys.@throw("The buffer is too small");
        }
    }
}