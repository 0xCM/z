//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Bytes;

    [ApiHost]
    public class Cli : WfSvc<Cli>
    {
        const NumericKind Closure = UnsignedInts;


        ApiMd ApiMd => Wf.ApiMd();

        public void EmitIl(IApiPack dst)
            => EmitMsil(ApiMd.ApiHosts, dst);

        public void EmitIl(IApiCatalog src, IApiPack dst)
            => EmitMsil(src.PartHosts(), dst);



        MsilPipe MsilSvc => Wf.MsilSvc();

        public ReadOnlySeq<AssemblyRefInfo> ReadAssemblyRefs()
        {
            var components = ApiMd.Assemblies;
            var count = components.Length;
            var dst = list<AssemblyRefInfo>();
            for(var i=0; i<count; i++)
            {
                ref readonly var assembly = ref skip(components,i);
                var path = FS.path(assembly.Location);
                if(ClrModules.valid(path))
                {
                    using var reader = PeReader.create(path);
                    var refs = reader.ReadAssemblyRefs();
                    iter(refs,r => dst.Add(r));
                }
            }
            dst.Sort();
            return dst.ToArray();
        }

        public void EmitMsil(CollectedHost src, IApiPack dst)
        {
            ref readonly var resolved = ref src.Resolved;
            if(resolved.IsNonEmpty)
            {
                var buffer = text.buffer();
                for(var j=0; j<resolved.Count; j++)   
                    MsilSvc.RenderCode(resolved[j].Msil, buffer);
                FileEmit(buffer.Emit(), resolved.Count, dst.MsilPath(src.Host), TextEncodingKind.Unicode);
            }
        }

        public void EmitMsil(ReadOnlySpan<IApiHost> src, IApiPack dst)
        {
            var buffer = text.buffer();
            var k = 0u;
            var emitted = cdict<ApiHostUri,FilePath>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var host = ref skip(src, i);
                var members = ClrJit.members(host, Emitter);
                var count = members.Length;
                if(members.Count == 0)
                    continue;

                for(var j=0; j<members.Count; j++)
                {
                    MsilSvc.RenderCode(members[j].Msil, buffer);
                    k++;
                }

                var path = dst.MsilPath(host.HostUri);
                FileEmit(buffer.Emit(), members.Count, path, TextEncodingKind.Unicode);
                emitted[host.HostUri] = path;
            }
        }

        public bool Reader(Assembly src, out CliReader dst)
        {
            dst = CliReader.create(src);
            return true;
        }

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='Assembly'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static CliTableSource<T> source<T>(Assembly src)
            where T : struct, IRecord<T>
                => new CliTableSource<T>(src);

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='MetadataReader'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static CliTableSource<T> source<T>(MetadataReader src)
            where T : struct, IRecord<T>
                => new CliTableSource<T>(src);

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='MemorySeg'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static CliTableSource<T> source<T>(MemorySeg src)
            where T : struct, IRecord<T>
                => new CliTableSource<T>(src);

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='PEMemoryBlock'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static CliTableSource<T> source<T>(PEMemoryBlock src)
            where T : struct, IRecord<T>
                => new CliTableSource<T>(src);

        /// <summary>
        /// Defines a <see cref='CliDataSource'/> over a specified <see cref='Assembly'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static CliDataSource source(Assembly src)
            => new CliDataSource(src);

        /// <summary>
        /// Defines a <see cref='CliDataSource'/> over a specified <see cref='MetadataReader'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static CliDataSource source(MetadataReader src)
            => new CliDataSource(src);

        /// <summary>
        /// Defines a <see cref='CliDataSource'/> over a specified <see cref='MemorySeg'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static CliDataSource source(MemorySeg src)
            => new CliDataSource(src);

        /// <summary>
        /// Defines a <see cref='CliDataSource'/> over a specified <see cref='PEMemoryBlock'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static CliDataSource source(PEMemoryBlock src)
            => new CliDataSource(src);

        [MethodImpl(Inline), Op]
        public static CliRowKey key(Handle src)
        {
            var data = CliHandleData.from(src);
            return new CliRowKey(data.Table, data.RowId);
        }

        [MethodImpl(Inline), Op]
        public static CliRowKey key(EntityHandle src)
        {
            var dat = CliHandleData.from(src);
            return new CliRowKey(dat.Table, dat.RowId);
        }

        [MethodImpl(Inline)]
        public static CliRowKey<K> key<K,T>(T handle, K k = default)
            where K : unmanaged, ICliTableKind<K>
            where T : unmanaged
                => uint32(handle);

        [MethodImpl(Inline), Op]
        public static CliTableKind table(Handle handle)
            => CliHandleData.from(handle).Table;

        [MethodImpl(Inline), Op]
        public static CliTableKind table(Type src)
            => (CliTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static CliTableKind table(MethodInfo src)
            => (CliTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static CliTableKind table(EventInfo src)
            => (CliTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static CliTableKind table(FieldInfo src)
            => (CliTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static CliTableKind table(PropertyInfo src)
             => (CliTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static uint row(Type src)
            => u32(src.MetadataToken) & 0xFFFFFF;

        [MethodImpl(Inline), Op]
        public static uint row(MethodInfo src)
            => u32(src.MetadataToken) & 0xFFFFFF;

        [MethodImpl(Inline), Op]
        public static uint row(EventInfo src)
            => u32(src.MetadataToken) & 0xFFFFFF;

        [MethodImpl(Inline), Op]
        public static uint row(EntityHandle src)
            => uint32(src) & 0xFFFFFF;

        public static Index<byte,CliTableKind> TableKinds()
        {
            const byte MaxTableId = (byte)CliTableKind.CustomDebugInformation;
            var values = Enums.literals<CliTableKind,byte>().Where(x => x < MaxTableId).Sort().View;
            var src = recover<CliTableKind>(values);
            var buffer = alloc<CliTableKind>(MaxTableId + 1);
            ref var dst = ref first(buffer);
            for(byte i=0; i<values.Length; i++)
                seek(dst,skip(values,i)) = (CliTableKind)i;
            return buffer;
        }

        public static CliRowKeys keys<K,T>(ReadOnlySpan<T> handles, K k = default)
            where T : unmanaged
            where K : unmanaged, ICliTableKind<K>
        {
            var count = handles.Length;
            var buffer = alloc<CliRowKey>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) = key<K,T>(skip(handles,i));
            return buffer;
        }

        public static void visualize(FilePath src, FilePath dst)
            => Mdv.run(src.Name, dst.Name);

        /// <summary>
        /// Unpacks a compressed integer in blob storage and returns the number of bytes consumed
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The data target</param>
        /// <remarks>Algorithm taken from https://github.com/microsoft/winmd/src/impl/winmd_reader/signature.h</remarks>
        [MethodImpl(Inline), Op]
        public static byte unpack(in byte src, out uint dst)
        {
            dst = default;
            var length = z8;
            if((src & 0x80) == 0)
            {
                length = 1;
                dst = src;
            }
            else if((src & 0xC0) == 0x80)
            {
                length = 2;
                dst = sll(and(skip(src,0), 0x3f), 8);
                dst |= skip(src, 1);
            }
            else if((src & 0xE0) == 0xC0)
            {
                length = 4;
                dst = sll(and(skip(src,0), 0x1f), 24);
                dst |= sll(skip(src, 1), 16);
                dst |= sll(skip(src, 2), 8);
                dst |= skip(src, 3);
            }

            return length;
        }

        public static string heapinfo<T>(T src)
            where T : ICliHeap
                => string.Format("{0,-20} | {1} | {2}", src.HeapKind, src.BaseAddress, src.Size);

        public static Index<CliBlobHeap> blobs(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<CliBlobHeap>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = CliReader.create(component);
                seek(dst,i) = reader.BlobHeap();
            }
            return buffer;
        }

        public static Index<CliGuidHeap> guids(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<CliGuidHeap>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = CliReader.create(component);
                seek(dst,i) = reader.GuidHeap();
            }
            return buffer;
        }

        public static Index<CliStringHeap> strings(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<CliStringHeap>(count*2);
            ref var dst = ref first(buffer);
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = CliReader.create(component);
                seek(dst,j++) = reader.StringHeap(CliStringKind.System);
                seek(dst,j++) = reader.StringHeap(CliStringKind.User);
            }
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static unsafe uint count(in CliStringHeap src)
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
        public static unsafe uint terminators(in CliStringHeap src, Span<uint> dst)
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

        public static Index<uint> terminators(in CliStringHeap src)
        {
            var dst = alloc<uint>(count(src));
            terminators(src,dst);
            return dst;
        }
    }
}