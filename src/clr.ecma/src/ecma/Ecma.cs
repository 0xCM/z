//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Commands;

    using static sys;
    using static Bytes;

    [ApiHost]
    public class Ecma : WfSvc<Ecma>
    {
        public static EcmaDb db(IWfRuntime wf, IDbArchive root)
            => new EcmaDb(wf,root);

        public static IEnumerable<AssemblyRef> refs(AssemblyFile src)
        {
            using var ecma = EcmaFile.open(src.Path);
            return ecma.EcmaReader().ReadAssemblyRefs2();            
        }

        public static ReadOnlySeq<AssemblyRefInfo> refs(Assembly src)
            => EcmaReader.create(src).ReadAssemblyRefs();

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

        ApiMd ApiMd => Wf.ApiMd();

        public void EmitMsil(IDbArchive dst)
            => EmitMsil(ApiMd.ApiHosts, dst);

        MsilSvc MsilSvc => Wf.MsilSvc();

        FilePath MsilPath(ApiHostUri src, IDbArchive dst)
            => dst.Path(ApiFiles.hostfile(src, FileKind.Il));

        public void EmitMsil(CollectedHost src, IDbArchive dst)
        {
            ref readonly var resolved = ref src.Resolved;
            if(resolved.IsNonEmpty)
            {
                var buffer = text.buffer();
                for(var j=0; j<resolved.Count; j++)   
                    MsilSvc.RenderCode(resolved[j].Msil, buffer);
                Channel.FileEmit(buffer.Emit(), resolved.Count, MsilPath(src.Host, dst), TextEncodingKind.Unicode);
            }
        }

        public void EmitMsil(ReadOnlySeq<IApiHost> src, IDbArchive dst)
        {
            var buffer = text.buffer();
            var k = 0u;
            var emitted = cdict<ApiHostUri,FilePath>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var host = ref src[i];
                var members = ClrJit.members(host, Channel);
                var count = members.Length;
                if(members.Count == 0)
                    continue;

                for(var j=0; j<members.Count; j++)
                {
                    MsilSvc.RenderCode(members[j].Msil, buffer);
                    k++;
                }

                var path = MsilPath(host.HostUri, dst);
                Channel.FileEmit(buffer.Emit(), members.Count, path, TextEncodingKind.Unicode);
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
                    var members = ClrJit.members(host, Channel);
                    var buffer = text.buffer();

                    for(var j=0; j<members.Count; j++)
                        MsilSvc.RenderCode(members[j].Msil, buffer);

                    if(members.Count != 0)
                    {
                        var path = MsilPath(host.HostUri, dst);
                        Channel.FileEmit(buffer.Emit(), members.Count, path, TextEncodingKind.Unicode);
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
   }

    partial class XTend
    {
        public static EcmaReader MetadataReader(this MappedAssembly src)
            => Z0.EcmaReader.create(src.BaseAddress, src.FileSize);
    }
}