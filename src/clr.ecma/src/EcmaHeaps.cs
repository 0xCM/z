//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class EcmaHeaps
    {
        public static void describe(IWfChannel channel)
        {
            var heaps = EcmaHeaps.strings(ApiAssemblies.Parts);
            var count = heaps.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var heap = ref heaps[i];
                var data = heap.Data;
                var size = heap.Size;
                var dst = text.emitter();
                dst.Append(heap.BaseAddress.Format());
                for(var j=0; j<size; j++)
                    dst.AppendFormat(" {0:X2}", skip(data,j));
                channel.Write(dst.Emit());
            }
        }

        public static string heapinfo<T>(T src)
            where T : IEcmaHeap
                => string.Format("{0,-20} | {1} | {2}", src.HeapKind, src.BaseAddress, src.Size);

        public static Index<EcmaHeap> blobs(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<EcmaHeap>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = EcmaReader.create(component);
                seek(dst,i) = reader.ReadBlobHeap();
            }
            return buffer;
        }

        public static Index<EcmaHeap> guids(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<EcmaHeap>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = EcmaReader.create(component);
                seek(dst,i) = reader.ReadGuidHeap();
            }
            return buffer;
        }

        public static Index<EcmaHeap> strings(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<EcmaHeap>(count*2);
            ref var dst = ref first(buffer);
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = EcmaReader.create(component);
                seek(dst,j++) = reader.StringHeapRef(EcmaStringKind.System);
                seek(dst,j++) = reader.StringHeapRef(EcmaStringKind.User);
            }
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static unsafe uint count(in EcmaHeap src)
        {
            var counter = 0u;
            var pCurrent = src.BaseAddress.Pointer<char>();
            var pLast = (src.BaseAddress + src.Size).Pointer<char>();
            while(pCurrent < pLast)
            {
                if(*pCurrent++ == Chars.Null)
                    counter++;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static unsafe uint terminators(in EcmaHeap src, Span<uint> dst)
        {
            var counter = 0u;
            var pCurrent = src.BaseAddress.Pointer<char>();
            var pLast = (src.BaseAddress + src.Size).Pointer<char>();
            var pos = 0u;
            while(pCurrent < pLast)
            {
                if(*pCurrent++ == Chars.Null)
                    seek(dst, counter++) = pos*2;
                pos++;
            }
            return counter;
        }

        public static Index<uint> terminators(in EcmaHeap src)
        {
            var dst = alloc<uint>(count(src));
            terminators(src,dst);
            return dst;
        }
    }
}