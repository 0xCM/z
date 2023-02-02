//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Storage
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T broadcast<S,T>(in S src, out T dst)
            where T : unmanaged, IStorageBlock<T>
            where S : unmanaged
        {
            dst = default;
            var szs = sys.size<S>();
            var szt = sys.size<T>();
            var div = szt/szs;
            var mod =  szt % szs;
            for(var i=0; i<div; i++)
                seek(@as<S>(dst.Bytes),i) = src;

            if(mod != 0)
            {
                var a = bytes(src);
                var offset = div*szs;
                var j=0;
                for(var i=offset; i<szt; i++)
                    seek(dst.Bytes,i) = skip(a,j++);
            }

            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ByteBlock8 broadcast<T>(in T src, W64 w)
            where T : unmanaged
        {
            var x = cpu.vbroadcast(w128, uint8(src));
            vcpu.vstore(x, ref ByteBlocks.alloc(n16, out var dst));
            return @as<ByteBlock16,ByteBlock8>(dst);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ByteBlock16 broadcast<T>(in T src, W128 w)
            where T : unmanaged
        {
            var x = cpu.vbroadcast(w, uint8(src));
            vcpu.vstore(x, ref ByteBlocks.alloc(n16, out var dst));
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ByteBlock32 broadcast<T>(in T src, W256 w)
            where T : unmanaged
        {
            var x = cpu.vbroadcast(w, uint8(src));
            cpu.vstore(x, ref ByteBlocks.alloc(n32, out var dst));
            return dst;
        }
    }
}