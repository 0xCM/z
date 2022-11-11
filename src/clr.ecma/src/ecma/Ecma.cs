//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Bytes;

    [ApiHost]
    public class Ecma : WfSvc<Ecma>
    {
        public static ReadOnlySeq<AssemblyRefInfo> refs(Assembly src)
            => EcmaReader.create(src).ReadAssemblyRefs();

        [MethodImpl(Inline), Op]
        public static MemberInfo member(Module src, EcmaToken token)
            => src.ResolveMember((int)token);

        [MethodImpl(Inline), Op]
        public static FieldInfo field(Module src, EcmaToken token)
            => src.ResolveField((int)token);

        [MethodImpl(Inline), Op]
        public static EcmaFieldRow row(FieldInfo src)
        {
            var data = Clr.adapt(src);
            var dst = new EcmaFieldRow();
            dst.Key = ClrArtifacts.reference(src);
            dst.DeclaringType = data.DeclaringType.Token;
            dst.CilType = data.FieldType.Token;
            dst.Attributes = data.Attributes;
            dst.Address = data.Address;
            dst.IsStatic = data.IsStatic;
            return dst;
        }

        public static ReadOnlySpan<EcmaSig> sigs(MethodInfo[] src)
        {
            var count = src.Length;
            if(count==0)
                return default;

            var dst = alloc<EcmaSig>(count);
            sigs(src, dst);
            return dst;
        }

        [Op]
        public static void sigs(MethodInfo[] src, Span<EcmaSig> dst)
        {
            var k = min(sys.count(src), sys.count(dst));
            if(k != 0)
            {
                ref readonly var input = ref first(src);
                ref var output = ref first(dst);
                for(var i=0; i<k; i++)
                    seek(output,i) = sig(skip(input,i));
            }
        }

        [MethodImpl(Inline), Op]
        public static EcmaSig sig(MemberInfo src)
        {
            sig(src, out EcmaSig dst);
            return dst;
        }

        public static bool sig(MemberInfo src, out EcmaSig dst)
        {
            try
            {
                dst = src.Module.ResolveSignature(src.MetadataToken);
                return true;
            }
            catch
            {
                dst = EcmaSig.Empty;
                return false;
            }
        }

        [Parser]
        public static bool parse(string src, out EcmaToken dst)
        {
            var i = text.index(src, Chars.Colon);
            var outcome = Outcome.Empty;
            dst = EcmaToken.Empty;
            if(i != NotFound)
            {
                outcome = Hex.parse8u(src.LeftOfIndex(i), out var table);
                if(!outcome)
                    return outcome;

                outcome = Hex.parse32u(text.right(src,i), out var row);
                if(!outcome)
                    return outcome;

                dst = EcmaTokens.token((TableIndex)table, row);
                return true;
            }
            else
            {
                outcome = Hex.parse32u(src, out var token);
                if(!outcome)
                    return outcome;
                dst = token;
                return true;
            }
        }

        [MethodImpl(Inline), Op]
        public static Handle ecmahandle(EcmaHandleData src)
            => @as<EcmaHandleData,Handle>(src);

        [MethodImpl(Inline), Op]
        public Handle ecmahandle(EcmaToken src)
            => ecmahandle(new EcmaHandleData(src.Table, src.Row));

        [MethodImpl(Inline), Op]
        public static EcmaHandleData datahandle(Handle src)
            => @as<Handle,EcmaHandleData>(src);

        [MethodImpl(Inline), Op]
        public static EcmaHandleData datahandle(EntityHandle src)
        {
            var row = uint32(src) & 0xFFFFFF;
            var kind = (EcmaTableKind)(uint32(src) >> 24);
            return new EcmaHandleData(kind,row);
        }

        [MethodImpl(Inline), Op]
        public static EcmaRowKey key(Handle src)
        {
            var data = datahandle(src);
            return new EcmaRowKey(data.Table, data.RowId);
        }

        [MethodImpl(Inline), Op]
        public static EcmaRowKey key(EntityHandle src)
        {
            var data = datahandle(src);
            return new EcmaRowKey(data.Table, data.RowId);
        }

        [MethodImpl(Inline), Op]
        public static EcmaHandle<RuntimeMethodHandle> MethodHandle(Module src, EcmaToken token)
            => new EcmaHandle<RuntimeMethodHandle>(ClrArtifactKind.Method, token, src.ModuleHandle.GetRuntimeMethodHandleFromMetadataToken((int)token));

        [MethodImpl(Inline), Op]
        public static EcmaHandle<RuntimeFieldHandle> FieldHandle(Module src, EcmaToken token)
            => new EcmaHandle<RuntimeFieldHandle>(ClrArtifactKind.Field, token, src.ModuleHandle.GetRuntimeFieldHandleFromMetadataToken((int)token));

        [MethodImpl(Inline), Op]
        public static EcmaHandle<RuntimeTypeHandle> TypeHandle(Module src, EcmaToken token)
            => new EcmaHandle<RuntimeTypeHandle>(ClrArtifactKind.Type, token, src.ModuleHandle.GetRuntimeTypeHandleFromMetadataToken((int)token));

        [Op]
        public static TableIndex? index(EntityHandle handle)
        {
            if(MetadataTokens.TryGetTableIndex(handle.Kind, out var table))
                return table;
            else
                return null;
        }

        [Op]
        public static TableIndex? index(Handle handle)
        {
            if(MetadataTokens.TryGetTableIndex(handle.Kind, out var table))
                return table;
            else
                return null;
        }

        [MethodImpl(Inline), Op]
        public static EcmaTableKind table(Handle handle)
            => EcmaHandleData.from(handle).Table;

        [MethodImpl(Inline), Op]
        public static uint row(EntityHandle src)
            => uint32(src) & 0xFFFFFF;

        [MethodImpl(Inline), Op]
        public static Type type(Module src, EcmaToken token)
            => src.ResolveType((int)token);

        [MethodImpl(Inline), Op]
        public static bool type(in EcmaTypeLookup src, string name, out Type dst)
        {
            dst = default;
            for(var i=0u; i<src.Count; i++)
            {
                ref readonly var x = ref skip(src.Pairs,i);
                if(x.Value.Name == name)
                {
                    dst = x.Value;
                    return true;
                }
            }
            return false;
        }

        const NumericKind Closure = UnsignedInts;

        ApiMd ApiMd => Wf.ApiMd();

        public void EmitIl(IApiPack dst)
            => EmitMsil(ApiMd.ApiHosts, dst);

        MsilSvc MsilSvc => Wf.MsilSvc();

        FilePath MsilPath(ApiHostUri src, IDbArchive dst)
            => dst.Path(ApiFiles.hostfile(src, FileKind.Il));

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

        public void EmitMsil(ReadOnlySeq<IApiHost> src, IApiPack dst)
        {
            var buffer = text.buffer();
            var k = 0u;
            var emitted = cdict<ApiHostUri,FilePath>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var host = ref src[i];
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

        public void EmitMsil(IReadOnlyDictionary<Assembly,IApiHost[]> src, IDbArchive dst)
        {
            dst.Delete();
            var k = 0u;
            var emitted = cdict<ApiHostUri,FilePath>();
            
            iter(src, part => {
                
                var hosts = bag<IApiHost>();
                iter(part.Value, host => {
                    var members = ClrJit.members(host, Emitter);
                    var buffer = text.buffer();

                    for(var j=0; j<members.Count; j++)
                        MsilSvc.RenderCode(members[j].Msil, buffer);

                    if(members.Count != 0)
                    {
                        var path = MsilPath(host.HostUri, dst);
                        FileEmit(buffer.Emit(), members.Count, path, TextEncodingKind.Unicode);
                        emitted.TryAdd(host.HostUri, path);
                    }
                });

            }, true);
        }

        public bool Reader(Assembly src, out EcmaReader dst)
        {
            dst = EcmaReader.create(src);
            return true;
        }

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='Assembly'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static EcmaTableSource<T> source<T>(Assembly src)
            where T : struct, IRecord<T>
                => new EcmaTableSource<T>(src);

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='MetadataReader'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static EcmaTableSource<T> source<T>(MetadataReader src)
            where T : struct, IRecord<T>
                => new EcmaTableSource<T>(src);

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='MemorySeg'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static EcmaTableSource<T> source<T>(MemorySeg src)
            where T : struct, IRecord<T>
                => new EcmaTableSource<T>(src);

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='PEMemoryBlock'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static EcmaTableSource<T> source<T>(PEMemoryBlock src)
            where T : struct, IRecord<T>
                => new EcmaTableSource<T>(src);

        /// <summary>
        /// Defines a <see cref='EcmaDataSource'/> over a specified <see cref='Assembly'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static EcmaDataSource source(Assembly src)
            => new EcmaDataSource(src);

        /// <summary>
        /// Defines a <see cref='EcmaDataSource'/> over a specified <see cref='MetadataReader'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static EcmaDataSource source(MetadataReader src)
            => new EcmaDataSource(src);

        /// <summary>
        /// Defines a <see cref='EcmaDataSource'/> over a specified <see cref='MemorySeg'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static EcmaDataSource source(MemorySeg src)
            => new EcmaDataSource(src);

        /// <summary>
        /// Defines a <see cref='EcmaDataSource'/> over a specified <see cref='PEMemoryBlock'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static EcmaDataSource source(PEMemoryBlock src)
            => new EcmaDataSource(src);


        [MethodImpl(Inline)]
        public static EcmaRowKey<K> key<K,T>(T handle, K k = default)
            where K : unmanaged, IEcmaTableKind<K>
            where T : unmanaged
                => uint32(handle);


        [MethodImpl(Inline), Op]
        public static EcmaTableKind table(Type src)
            => (EcmaTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static EcmaTableKind table(MethodInfo src)
            => (EcmaTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static EcmaTableKind table(EventInfo src)
            => (EcmaTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static EcmaTableKind table(FieldInfo src)
            => (EcmaTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static EcmaTableKind table(PropertyInfo src)
             => (EcmaTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static uint row(Type src)
            => u32(src.MetadataToken) & 0xFFFFFF;

        [MethodImpl(Inline), Op]
        public static uint row(MethodInfo src)
            => u32(src.MetadataToken) & 0xFFFFFF;

        [MethodImpl(Inline), Op]
        public static uint row(EventInfo src)
            => u32(src.MetadataToken) & 0xFFFFFF;


        public static Index<byte,EcmaTableKind> TableKinds()
        {
            const byte MaxTableId = (byte)EcmaTableKind.CustomDebugInformation;
            var values = Enums.literals<EcmaTableKind,byte>().Where(x => x < MaxTableId).Sort().View;
            var src = recover<EcmaTableKind>(values);
            var buffer = alloc<EcmaTableKind>(MaxTableId + 1);
            ref var dst = ref first(buffer);
            for(byte i=0; i<values.Length; i++)
                seek(dst,skip(values,i)) = (EcmaTableKind)i;
            return buffer;
        }

        public static EcmaRowKeys keys<K,T>(ReadOnlySpan<T> handles, K k = default)
            where T : unmanaged
            where K : unmanaged, IEcmaTableKind<K>
        {
            var count = handles.Length;
            var buffer = alloc<EcmaRowKey>(count);
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
            where T : IEcmaHeap
                => string.Format("{0,-20} | {1} | {2}", src.HeapKind, src.BaseAddress, src.Size);

        public static Index<EcmaBlobHeap> blobs(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<EcmaBlobHeap>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = EcmaReader.create(component);
                seek(dst,i) = reader.ReadBlobHeap();
            }
            return buffer;
        }

        public static Index<EcmaGuidHeap> guids(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<EcmaGuidHeap>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = EcmaReader.create(component);
                seek(dst,i) = reader.ReadGuidHeap();
            }
            return buffer;
        }

        public static Index<EcmaStringHeap> strings(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<EcmaStringHeap>(count*2);
            ref var dst = ref first(buffer);
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = EcmaReader.create(component);
                seek(dst,j++) = reader.ReadStringHeap(EcmaStringKind.System);
                seek(dst,j++) = reader.ReadStringHeap(EcmaStringKind.User);
            }
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static unsafe uint count(in EcmaStringHeap src)
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
        public static unsafe uint terminators(in EcmaStringHeap src, Span<uint> dst)
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

        public static Index<uint> terminators(in EcmaStringHeap src)
        {
            var dst = alloc<uint>(count(src));
            terminators(src,dst);
            return dst;
        }
    }
}