// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline)]
        public static void broadcast<K,T>(T src, Index<K,T> dst)
            where K : unmanaged
        {
            var edit = dst.Edit;
            for(var i=0; i<edit.Length; i++)
                seek(edit,i) = src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void broadcast<T>(T src, Index<T> dst)
        {
            var edit = dst.Edit;
            for(var i=0; i<edit.Length; i++)
                seek(edit,i) = src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void broadcast<T>(T src, Span<T> dst)
        {
            for(var i=0; i<dst.Length; i++)
                seek(dst,i) = src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void broadcast<T>(T src, T[] dst)
        {
            for(var i=0; i<dst.Length; i++)
                seek(dst,i) = src;
        }
    }
}